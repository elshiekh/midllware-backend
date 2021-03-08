using APIMiddleware.Core.DBContext;
using APIMiddleware.Core.DBContext.Entities;
using APIMiddleware.Core.DTO;
using APIMiddleware.Core.Enum;
using APIMiddleware.Core.Extenstion;
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
                if (requestDTO.RequestUrl.Contains("/swagger/"))
                    return true;


                _dbContext.Add(new Request()
                {
                    RequestGuid = Guid.NewGuid().ToString(),
                    ProjectCode = requestDTO.ProjectCode,
                    RequestTime = requestDTO.RequestTime,
                    RequestBody = requestDTO.RequestBody,
                    ElapsedMilliseconds = requestDTO.ElapsedMilliseconds,
                    ResponseStatus = requestDTO.ResponseStatus,
                    RequestMethod = requestDTO.RequestMethod,
                    RequestFunction = requestDTO.RequestFunction,
                    RequestFormat = requestDTO.RequestFormat,
                    ResponseFormat = requestDTO.ResponseFormat,
                    UserName = requestDTO.UserName,
                    RequestUrl = requestDTO.RequestUrl,
                    IP_Address = requestDTO.IP_Address,
                    IsSuccess = (requestDTO.ResponseStatus == 201 || requestDTO.ResponseStatus == 200),
                    QueryString = requestDTO.QueryString,
                    ResponseBody = requestDTO.ResponseBody,
                    Created_By = requestDTO.UserName,
                    Creation_Date = DateTime.Now,
                    Last_Updated_By = requestDTO.UserName,
                    Last_Update_Date = DateTime.Now,
                    RowVersion = requestDTO.RowVersion,
                   // RequestStatus = 
                });

                _dbContext.SaveChanges();
                CheckFailureAPI(requestDTO.RequestUrl);

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
                    RequestStart = request.RequestTime.ToString("MM/dd/yyyy HH:mm:ss"),
                    ResponseFinish = request.RequestTime.AddMilliseconds(request.ElapsedMilliseconds).ToString("MM/dd/yyyy HH:mm:ss"),
                    Date = request.RequestTime.ToString("dd/MM/yyyy"),
                    Time = request.RequestTime.ToString("HH:mm"),
                    IsSuccess = (request.ResponseStatus == 201 || request.ResponseStatus == 200),
                    ElapsedMilliseconds = request.ElapsedMilliseconds,
                    ResponseStatus = request.ResponseStatus,
                    RequestMethod = request.RequestMethod,
                    RequestUrl = request.RequestUrl,
                    QueryString = request.QueryString,
                    Created_By = request.Created_By,
                    Creation_Date = request.Creation_Date,
                    IP_Address = request.IP_Address,
                    Last_Updated_By = request.Last_Updated_By,
                    Last_Update_Date = request.Last_Update_Date,
                    RequestBody = request.RequestBody,
                    ResponseBody = request.ResponseBody,
                    RequestFormat = request.RequestFormat,
                    ResponseFormat = request.ResponseFormat,
                    RequestFunction = request.RequestFunction,
                    RequestStatus = request.RequestStatus,
                    UserName = request.UserName,
                    RowVersion = request.RowVersion
                }).OrderByDescending(s => s.RequestTime).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<RequestDTO>> GetAllWithFilter(int? projectId
             ,string function, int? statusCode, int? requestReceiveId,
             string ipAddress, string userName, string fromDate, string toDate)
        {
            try
            {
                var from_Date = DateExtension.GetDateFromString(fromDate);
                var to_Date = DateExtension.GetDateFromString(toDate);
                var requests = _dbContext.Requests.Include(s => s.Project);
                if (projectId > 0) {
                    requests = requests.Where(x => x.ProjectCode == projectId).Include(s => s.Project);
                }
                if (function != null)
                {
                    requests = requests.Where(x => x.RequestFunction == function).Include(s => s.Project);
                }
                if (statusCode != null)
                {
                    requests = requests.Where(x => x.ResponseStatus == statusCode).Include(s => s.Project);
                }
                if (userName != null)
                {
                    requests = requests.Where(x => x.UserName == userName).Include(s => s.Project);
                }
                if (ipAddress != null)
                {
                    requests = requests.Where(x => x.IP_Address == ipAddress).Include(s => s.Project);
                }
                if (requestReceiveId > 0) {
                    if (requestReceiveId == (int)GenericEnum.RequestReceive.Week) {
                        requests = requests.Where(x => x.RequestTime.Date >= x.RequestTime.Date && x.RequestTime.Date <= x.RequestTime.Date.AddDays(7)).Include(s => s.Project);
                    }
                    if (requestReceiveId == (int)GenericEnum.RequestReceive.Month) {
                        requests = requests.Where(x => x.RequestTime.Date >= x.RequestTime.Date && x.RequestTime.Date <= x.RequestTime.Date.AddMonths(1)).Include(s => s.Project);
                    }
                    if (requestReceiveId == (int)GenericEnum.RequestReceive.ThreeMonth) {
                        requests = requests.Where(x => x.RequestTime.Date >= x.RequestTime.Date && x.RequestTime.Date <= x.RequestTime.Date.AddMonths(3)).Include(s => s.Project);
                    }
                    if (requestReceiveId == (int)GenericEnum.RequestReceive.SixMontth) {
                        requests = requests.Where(x => x.RequestTime.Date >= x.RequestTime.Date && x.RequestTime.Date <= x.RequestTime.Date.AddMonths(6)).Include(s => s.Project);
                    }
                }
                else { 
                   if (fromDate!= "null" || toDate != "null")
                   {
                       requests = requests.Where(x => x.RequestTime.Date >= from_Date && x.RequestTime.Date <= to_Date).Include(s => s.Project);
                   }
                }

                return await requests.Select(request => new RequestDTO
                {
                    Id = request.Id,
                    ProjectName = request.Project.ProjectName,
                    ProjectCode = request.ProjectCode,
                    RequestGuid = request.RequestGuid,
                    RequestTime = request.RequestTime,
                    RequestDate = request.RequestTime,
                    RequestStart = request.RequestTime.ToString("MM/dd/yyyy HH:mm:ss"),
                    ResponseFinish = request.RequestTime.AddMilliseconds(request.ElapsedMilliseconds).ToString("MM/dd/yyyy HH:mm:ss"),
                    Date = request.RequestTime.ToString("dd/MM/yyyy"),
                    Time = request.RequestTime.ToString("HH:mm"),
                    IsSuccess = (request.ResponseStatus == 201 || request.ResponseStatus == 200),
                    ElapsedMilliseconds = request.ElapsedMilliseconds,
                    ResponseStatus = request.ResponseStatus,
                    RequestMethod = request.RequestMethod,
                    RequestUrl = request.RequestUrl,
                    QueryString = request.QueryString,
                    Created_By = request.Created_By,
                    Creation_Date = request.Creation_Date,
                    IP_Address = request.IP_Address,
                    Last_Updated_By = request.Last_Updated_By,
                    Last_Update_Date = request.Last_Update_Date,
                    RequestBody = request.RequestBody,
                    ResponseBody = request.ResponseBody,
                    RequestFormat = request.RequestFormat,
                    ResponseFormat = request.ResponseFormat,
                    RequestFunction = request.RequestFunction,
                    RequestStatus = request.RequestStatus,
                    UserName = request.UserName,
                    RowVersion = request.RowVersion
                }).OrderByDescending(s => s.RequestTime).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
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
                var request = await _dbContext.Requests.Include(s => s.Project).FirstOrDefaultAsync(s => s.Id == id);
                return new RequestDTO()
                {
                    Id = request.Id,
                    ProjectName = request.Project.ProjectName,
                    ProjectCode = request.ProjectCode,
                    RequestGuid = request.RequestGuid,
                    RequestTime = request.RequestTime,
                    RequestDate = request.RequestTime,
                    RequestStart = request.RequestTime.ToString("MM/dd/yyyy HH:mm:ss"),
                    ResponseFinish = request.RequestTime.AddMilliseconds(request.ElapsedMilliseconds).ToString("MM/dd/yyyy HH:mm:ss"),
                    Date = request.RequestTime.ToString("dd/MM/yyyy"),
                    Time = request.RequestTime.ToString("HH:mm"),
                    IsSuccess = (request.ResponseStatus == 201 || request.ResponseStatus == 200),
                    ElapsedMilliseconds = request.ElapsedMilliseconds,
                    ResponseStatus = request.ResponseStatus,
                    RequestMethod = request.RequestMethod,
                    RequestUrl = request.RequestUrl,
                    QueryString = request.QueryString,
                    Created_By = request.Created_By,
                    Creation_Date = request.Creation_Date,
                    IP_Address = request.IP_Address,
                    Last_Updated_By = request.Last_Updated_By,
                    Last_Update_Date = request.Last_Update_Date,
                    RequestBody = request.RequestBody,
                    ResponseBody = request.ResponseBody,
                    RequestFormat = request.RequestFormat,
                    ResponseFormat = request.ResponseFormat,
                    RequestFunction = request.RequestFunction,
                    RequestStatus = request.RequestStatus
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
            var failerCount = _dbContext.Requests.Count(s => s.RequestUrl == path && !s.IsSuccess);

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

            var failerCount = _dbContext.Requests.Count(s => s.RequestUrl == path && dueDate <= s.RequestTime && !s.IsSuccess);

            if (failerCount >= limitFailerCount)
            {
                return false;
            }

            return true;
        }
    }
}
