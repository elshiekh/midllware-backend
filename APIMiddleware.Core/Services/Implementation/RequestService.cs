﻿using APIMiddleware.Core.DBContext;
using APIMiddleware.Core.DBContext.Entities;
using APIMiddleware.Core.DTO;
using APIMiddleware.Core.Services.Interface;
using APIMiddleware.Notification.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMiddleware.Core.Services.Implementation
{
    public class RequestService : IRequestService
    {
        private readonly APIMiddlewareContext _dbContext;
        private readonly ISystemPreferenceService _systemPreferenceService;
        private readonly IEmailService _emailService;

        public RequestService(ISystemPreferenceService systemPreferenceService, IEmailService emailService)
        {
            _systemPreferenceService = systemPreferenceService;
            _emailService = emailService;
            _dbContext = new APIMiddlewareContext();
        }

        public bool AddRequest(RequestDTO requestDTO)
        {
            try
            {
                if (requestDTO.Path.Contains("/swagger/"))
                    return true;


                _dbContext.Add(new Request()
                {
                    RequestGuid = Guid.NewGuid().ToString(),
                    ProjectCode = requestDTO.ProjectCode,
                    RequestTime = requestDTO.RequestTime,
                    RequestBody = requestDTO.RequestBody,
                    ElapsedMilliseconds = requestDTO.ElapsedMilliseconds,
                    StatusCode = requestDTO.StatusCode,
                    Method = requestDTO.Method,
                    Path = requestDTO.Path,
                    Host = requestDTO.Host,
                    IsSuccess = (requestDTO.StatusCode == 201 || requestDTO.StatusCode == 200),
                    QueryString = requestDTO.QueryString,
                    ResponseBody = requestDTO.ResponseBody,
                });

                _dbContext.SaveChanges();
                CheckFailureAPI(requestDTO.Path);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveRequest(int id)
        {
            try
            {
                var request = _dbContext.Requests.FirstOrDefault(s => s.Id == id);
                _dbContext.Remove(request);

                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<RequestDTO>> GetAllRequests()
        {
            try
            {
                var requests =  _dbContext.Requests.Include(s => s.Project);

                return  await requests.Select(request => new RequestDTO
                {
                    Id = request.Id,
                    ProjectName = request.Project.ProjectName,
                    ProjectCode = request.ProjectCode,
                    RequestGuid = request.RequestGuid,
                    RequestTime = request.RequestTime,
                    RequestDate = request.RequestTime,
                    Date = request.RequestTime.ToString("dd/MM/yyyy"),
                    Time = request.RequestTime.ToString("HH:mm"),
                    IsSuccess = (request.StatusCode == 201 || request.StatusCode == 200),
                    ElapsedMilliseconds = request.ElapsedMilliseconds,
                    StatusCode = request.StatusCode,
                    Method = request.Method,
                    Path = request.Path,
                    QueryString = request.QueryString,
                }).OrderByDescending(s => s.RequestTime).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetAllRequestCounts()
        {
            try
            {
                return  await _dbContext.Requests.CountAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RequestDTO> GetRequestsDetails(int id)
        {
            try
            {
                var request =  _dbContext.Requests.Include(s => s.Project).FirstOrDefault(s => s.Id == id);

                return new RequestDTO()
                {
                    Id = request.Id,
                    ProjectName = request.Project.ProjectName,
                    RequestGuid = request.RequestGuid,
                    RequestTime = request.RequestTime,
                    Date = request.RequestTime.ToString("dd/MM/yyyy"),
                    Time = request.RequestTime.ToString("HH:mm"),
                    ElapsedMilliseconds = request.ElapsedMilliseconds,
                    StatusCode = request.StatusCode,
                    IsSuccess = (request.StatusCode == 201 || request.StatusCode == 200),
                    Method = request.Method,
                    Path = request.Path,
                    QueryString = request.QueryString,
                    RequestBody = request.RequestBody,
                    ResponseBody = request.ResponseBody,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CheckFailureAPI(string path)
        {
            if (!CheckAPIFailerCount(path) || !CheckAPIFailerCountInTime(path))
            {
                var content = _systemPreferenceService.GetSystemPreferences().EmailBody;
                var subject = _systemPreferenceService.GetSystemPreferences().EmailSubject;

                var notificationMetadata = _systemPreferenceService.GetNotificationMetadata();
                var emailMessage = new Notification.Models.EmailMessage { Content = content, Subject = subject };

                _emailService.SendEmail(emailMessage, notificationMetadata);
            }
        }

        public bool CheckAPIFailerCount(string path)
        {
            var limitFailerCount = _systemPreferenceService.GetSystemPreferences().FaildedAPI;
            var failerCount = _dbContext.Requests.Count(s => s.Path == path && !s.IsSuccess);

            if (failerCount >= limitFailerCount)
            {
                return false;
            }

            return true;
        }

        public bool CheckAPIFailerCountInTime(string path)
        {
            var limitFailerCount = _systemPreferenceService.GetSystemPreferences().FaildedAPICount;
            var faildedAPITime = _systemPreferenceService.GetSystemPreferences().FaildedAPITime;
            DateTime dueDate = DateTime.Now.AddMinutes(-faildedAPITime);

            var failerCount = _dbContext.Requests.Count(s => s.Path == path && dueDate <= s.RequestTime && !s.IsSuccess);

            if (failerCount >= limitFailerCount)
            {
                return false;
            }

            return true;
        }
    }
}
