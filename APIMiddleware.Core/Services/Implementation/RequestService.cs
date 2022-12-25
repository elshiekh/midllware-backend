using APIMiddleware.Core.DBContext;
using APIMiddleware.Core.DTO;
using APIMiddleware.Core.Entities;
using APIMiddleware.Core.Extenstion;
using APIMiddleware.Core.Filter;
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
                    ProjectId = requestDTO.ProjectId,
                    RequestTime = requestDTO.RequestTime,
                    RequestBody = requestDTO.RequestBody,
                    ElapsedMilliseconds = requestDTO.ElapsedMilliseconds,
                    ResponseCode = requestDTO.ResponseCode,
                    RequestStatus = requestDTO.ResponseCode == 200 ? "S" : "F",
                    RequestMethod = requestDTO.RequestMethod,
                    RequestFunction = requestDTO.RequestFunction,
                    RequestFormat = requestDTO.RequestFormat,
                    ResponseFormat = requestDTO.ResponseFormat,
                    UserName = requestDTO.UserName,
                    RequestUrl = requestDTO.RequestUrl,
                    IP_Address = requestDTO.IP_Address,
                    QueryString = requestDTO.QueryString,
                    ResponseBody = requestDTO.ResponseBody,
                    Created_By = requestDTO.UserName,
                    Creation_Date = DateTime.Now,
                    Last_Updated_By = requestDTO.UserName,
                    Last_Update_Date = DateTime.Now,
                    RowVersion = requestDTO.RowVersion,
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
                var request = _dbContext.Requests.FirstOrDefault(s => s.RequestId == id);
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
                var requests = _dbContext.Requests.Include(s => s.Project);

                return await requests.Select(request => new RequestDTO
                {
                    Id = request.RequestId,
                    ProjectName = request.Project.ProjectName,
                    ProjectId = request.ProjectId,
                    RequestGuid = request.RequestGuid,
                    RequestTime = request.RequestTime,
                    RequestDate = request.RequestTime,
                    RequestStart = request.RequestTime.ToString("MM/dd/yyyy HH:mm:ss"),
                    ResponseFinish = request.RequestTime.AddMilliseconds(request.ElapsedMilliseconds).ToString("MM/dd/yyyy HH:mm:ss"),
                    Date = request.RequestTime.ToString("dd/MM/yyyy"),
                    Time = request.RequestTime.ToString("HH:mm"),
                    RequestStatus = (request.ResponseCode).ToString(),
                    ElapsedMilliseconds = request.ElapsedMilliseconds,
                    ResponseCode = request.ResponseCode,
                    RequestMethod = request.RequestMethod,
                    RequestUrl = request.RequestUrl,
                    QueryString = request.QueryString,
                    Created_By = request.Created_By,
                    Creation_Date = request.Creation_Date,
                    IP_Address = request.IP_Address,
                    Last_Updated_By = request.Last_Updated_By,
                    Last_Update_Date = request.Last_Update_Date,
                    //RequestBody = request.RequestBody,
                    //ResponseBody = request.ResponseBody,
                    RequestFormat = request.RequestFormat,
                    ResponseFormat = request.ResponseFormat,
                    RequestFunction = request.RequestFunction,
                    UserName = request.UserName,
                    RowVersion = request.RowVersion
                }).OrderByDescending(s => s.RequestTime).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<RequestDTO>> GetRequests(PaginationFilter filter, int? projectId
         , string function, int? statusCode, int? requestReceiveId,
         string ipAddress, string userName, string fromDate, string toDate)
        {
            try
            {
                // var requests = _dbContext.Requests.Include(s => s.Project);
                var requests = _dbContext.Requests.Include(s => s.Project)
                   .Skip((filter.PageNumber - 1) * filter.PageSize)
                   .Take(filter.PageSize);
                var from_Date = DateExtension.GetDateFromString(fromDate);
                var to_Date = DateExtension.GetDateFromString(toDate);
                // var requests = _dbContext.Requests.Include(s => s.Project);
                if (projectId > 0)
                {
                    requests = requests.Where(x => x.ProjectId == projectId).OrderByDescending(z => z.RequestTime);
                }
                if (function != null)
                {
                    requests = requests.Where(x => x.RequestFunction == function).OrderByDescending(z => z.RequestTime);
                }
                if (statusCode != null)
                {
                    requests = requests.Where(x => x.ResponseCode == statusCode).OrderByDescending(z => z.RequestTime);
                }
                if (userName != null)
                {
                    requests = requests.Where(x => x.UserName == userName).OrderByDescending(z => z.RequestTime);
                }
                if (ipAddress != null)
                {
                    requests = requests.Where(x => x.IP_Address == ipAddress).OrderByDescending(z => z.RequestTime);
                }
                //if (requestReceiveId > 0)
                //{
                //    if (requestReceiveId == (int)GenericEnum.RequestReceive.Week)
                //    {
                //        requests = requests.Where(x => x.RequestTime.Date >= x.RequestTime.Date && x.RequestTime.Date <= x.RequestTime.Date.AddDays(7)).OrderByDescending(z => z.RequestTime); ;
                //    }
                //    if (requestReceiveId == (int)GenericEnum.RequestReceive.Month)
                //    {
                //        requests = requests.Where(x => x.RequestTime.Date >= x.RequestTime.Date && x.RequestTime.Date <= x.RequestTime.Date.AddMonths(1)).OrderByDescending(z => z.RequestTime); ;
                //    }
                //    if (requestReceiveId == (int)GenericEnum.RequestReceive.ThreeMonth)
                //    {
                //        requests = requests.Where(x => x.RequestTime.Date >= x.RequestTime.Date && x.RequestTime.Date <= x.RequestTime.Date.AddMonths(3)).OrderByDescending(z => z.RequestTime);
                //    }
                //    if (requestReceiveId == (int)GenericEnum.RequestReceive.SixMontth)
                //    {
                //        requests = requests.Where(x => x.RequestTime.Date >= x.RequestTime.Date && x.RequestTime.Date <= x.RequestTime.Date.AddMonths(6)).OrderByDescending(z => z.RequestTime);
                //    }
                //}
                else
                {
                    if (fromDate != null || toDate != null)
                    {
                        requests = requests.Where(x => x.RequestTime.Date >= from_Date && x.RequestTime.Date <= to_Date).OrderByDescending(z => z.RequestTime);
                    }
                }

                return await requests.Select(request => new RequestDTO
                {
                    Id = request.RequestId,
                    ProjectName = request.Project.ProjectName,
                    ProjectId = request.ProjectId,
                    RequestGuid = request.RequestGuid,
                    RequestTime = request.RequestTime,
                    RequestDate = request.RequestTime,
                    RequestStart = request.RequestTime.ToString("MM/dd/yyyy HH:mm:ss"),
                    ResponseFinish = request.RequestTime.AddMilliseconds(request.ElapsedMilliseconds).ToString("MM/dd/yyyy HH:mm:ss"),
                    Date = request.RequestTime.ToString("dd/MM/yyyy"),
                    Time = request.RequestTime.ToString("HH:mm"),
                    RequestStatus = request.RequestStatus,
                    ElapsedMilliseconds = request.ElapsedMilliseconds,
                    ResponseCode = request.ResponseCode,
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
                    UserName = request.UserName,
                    RowVersion = request.RowVersion
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<RequestDTO>> GetAllWithFilter(int? requestId, int? projectId, int? function, int? responseCode, string requestStatus,
        string ipAddress, string userName, string fromDate, string toDate)
        {
            try
            {
                var from_Date = DateExtension.ToDate(fromDate);
                var to_Date = DateExtension.ToDate(toDate);
                var functionName = "";
                var requestFunction = _dbContext.Functions.FirstOrDefault(x => x.ProjectId == projectId && x.FunctionId == function);
                if (requestFunction != null) { functionName = requestFunction.FunctionName; }
                var requests = _dbContext.Requests.Include(s => s.Project);
                if (requestId > 0)
                {
                    requests = requests.Where(x => x.RequestId == requestId).Include(s => s.Project);
                }
                if (projectId > 0)
                {
                    requests = requests.Where(x => x.ProjectId == projectId).Include(s => s.Project);
                }
                if (!string.IsNullOrEmpty(functionName))
                {
                    requests = requests.Where(x => x.RequestFunction == functionName).Include(s => s.Project);
                }
                if (responseCode > 0)
                {
                    requests = requests.Where(x => x.ResponseCode == responseCode).Include(s => s.Project);
                }
                if (!string.IsNullOrEmpty(requestStatus) && requestStatus != "0")
                {
                    requests = requests.Where(x => x.RequestStatus == requestStatus).Include(s => s.Project);
                }
                if (!string.IsNullOrEmpty(userName))
                {
                    requests = requests.Where(x => x.UserName == userName).Include(s => s.Project);
                }
                if (!string.IsNullOrEmpty(ipAddress))
                {
                    requests = requests.Where(x => x.IP_Address == ipAddress).Include(s => s.Project);
                }
                if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
                {
                    requests = requests.Where(x => x.RequestTime >= from_Date && x.RequestTime <= to_Date).Include(s => s.Project);
                }

                return await requests.Select(request => new RequestDTO
                {
                    Id = request.RequestId,
                    ProjectName = request.Project.ProjectName,
                    ProjectId = request.ProjectId,
                    RequestGuid = request.RequestGuid,
                    RequestTime = request.Creation_Date,
                    RequestDate = request.RequestTime,
                    RequestStart = request.Creation_Date.ToString("MM/dd/yyyy HH:mm:ss"),
                    ResponseFinish = request.Creation_Date.AddMilliseconds(request.ElapsedMilliseconds).ToString("MM/dd/yyyy HH:mm:ss"),
                    Date = request.Creation_Date.ToString("dd/MM/yyyy"),
                    Time = request.Creation_Date.ToString("HH:mm"),
                    ElapsedMilliseconds = request.ElapsedMilliseconds,
                    ResponseCode = request.ResponseCode,
                    RequestMethod = request.RequestMethod,
                    RequestUrl = request.RequestUrl,
                    QueryString = request.QueryString,
                    Created_By = request.Created_By,
                    Creation_Date = request.Creation_Date,
                    IP_Address = request.IP_Address,
                    Last_Updated_By = request.Last_Updated_By,
                    Last_Update_Date = request.Last_Update_Date,
                    //RequestBody = request.RequestBody,
                    //ResponseBody = request.ResponseBody,
                    RequestFormat = request.RequestFormat,
                    ResponseFormat = request.ResponseFormat,
                    RequestFunction = request.RequestFunction,
                    RequestStatus = request.RequestStatus,
                    UserName = request.UserName,
                    RowVersion = request.RowVersion
                }).OrderByDescending(s => s.Creation_Date).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PurgeAllWithFilter
        public bool PurgeAllWithFilter(int? requestId, int? projectId
         , int? function, int? responseCode, string requestStatus,
         string ipAddress, string userName, string fromDate, string toDate)
        {
            try
            {
                var from_Date = DateExtension.ToDate(fromDate);
                var to_Date = DateExtension.ToDate(toDate);
                var functionName = "";
                var requestFunction = _dbContext.Functions.FirstOrDefault(x => x.ProjectId == projectId && x.FunctionId == function);
                if (requestFunction != null) { functionName = requestFunction.FunctionName; }
                var requests = _dbContext.Requests.Include(s => s.Project);
                if (requestId > 0)
                {
                    requests = requests.Where(x => x.RequestId == requestId).Include(s => s.Project);
                }
                if (projectId > 0)
                {
                    requests = requests.Where(x => x.ProjectId == projectId).Include(s => s.Project);
                }
                if (!string.IsNullOrEmpty(functionName))
                {
                    requests = requests.Where(x => x.RequestFunction == functionName).Include(s => s.Project);
                }
                if (responseCode > 0)
                {
                    requests = requests.Where(x => x.ResponseCode == responseCode).Include(s => s.Project);
                }
                if (!string.IsNullOrEmpty(requestStatus))
                {
                    requests = requests.Where(x => x.RequestStatus == requestStatus).Include(s => s.Project);
                }
                if (!string.IsNullOrEmpty(userName))
                {
                    requests = requests.Where(x => x.UserName == userName).Include(s => s.Project);
                }
                if (!string.IsNullOrEmpty(ipAddress))
                {
                    requests = requests.Where(x => x.IP_Address == ipAddress).Include(s => s.Project);
                }
                if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
                {
                    requests = requests.Where(x => x.RequestTime >= from_Date && x.RequestTime <= to_Date).Include(s => s.Project);
                }
                _dbContext.RemoveRange(requests);
                _dbContext.SaveChanges();

                return true;
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
                return await _dbContext.Requests.CountAsync();
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
                var request = await _dbContext.Requests.Include(s => s.Project).FirstOrDefaultAsync(s => s.RequestId == id);
                return new RequestDTO()
                {
                    Id = request.RequestId,
                    ProjectName = request.Project.ProjectName,
                    ProjectId = request.ProjectId,
                    RequestGuid = request.RequestGuid,
                    RequestTime = request.Creation_Date,
                    RequestDate = request.Creation_Date,
                    RequestStart = request.Creation_Date.ToString("MM/dd/yyyy HH:mm:ss"),
                    ResponseFinish = request.Creation_Date.AddMilliseconds(request.ElapsedMilliseconds).ToString("MM/dd/yyyy HH:mm:ss"),
                    Date = request.Creation_Date.ToString("dd/MM/yyyy"),
                    Time = request.Creation_Date.ToString("HH:mm"),
                    ElapsedMilliseconds = request.ElapsedMilliseconds,
                    ResponseCode = request.ResponseCode,
                    RequestMethod = request.RequestMethod,
                    UserName = request.UserName,
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
                    RequestStatus = request.ResponseCode == 200 ? "Success" : "Failure"
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
            var failerCount = _dbContext.Requests.Count(s => s.RequestUrl == path && s.RequestStatus == "Failure");

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

            var failerCount = _dbContext.Requests.Count(s => s.RequestUrl == path && dueDate <= s.RequestTime && s.RequestStatus == "Failure");

            if (failerCount >= limitFailerCount)
            {
                return false;
            }

            return true;
        }
    }
}
