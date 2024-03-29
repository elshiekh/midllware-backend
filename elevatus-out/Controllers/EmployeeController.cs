﻿using elevatus_out.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace elevatus_out.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class EmployeeController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public EmployeeController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region GetEmployee
        [HttpGet("GetEmployees.{format}"), FormatFilter]
        public async Task<IActionResult> GetEmployees(int limit = 30, int page = 1)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    var request = new HttpRequestMessage(HttpMethod.Get, baseAddress + "/api/v1/service/employee?limit=" + limit + "&page=" + page);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    request.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<GetEmployeeResponse>(stringData);
                    return Ok(data.IntegrateAccount.ExtraData);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Get Employee Type
        [HttpPost("EmployeeType.{format}"), FormatFilter]
        public async Task<IActionResult> EmployeeType([FromBody] EmployeeTypeRequest obj)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    ResponseEmployeeType result = new ResponseEmployeeType();
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    var request = new HttpRequestMessage(HttpMethod.Get, baseAddress + "/api/v1/service/employee/type");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<EmployeeTypeResponse>(stringData);
                    var issues = JsonConvert.SerializeObject(data.Reason).Replace("\"", "");
                    issues = issues.Replace(":", " ").Replace(",", " ");
                    result.Message = data.Identifiers.Status == "success" ? data.IntegrateAccount.ExtraData.Type.ToString() : issues;
                    result.Status = data.Identifiers.Status;
                    result.RequestId = data.Identifiers.RequestId;
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Enable Employee
        [HttpPost("EnableEmployee.{format}"), FormatFilter]
        public async Task<IActionResult> EnableEmployee([FromBody] EmployeeEnableRequest obj)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    EmployeeResponseEnable result = new EmployeeResponseEnable();
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    var request = new HttpRequestMessage(HttpMethod.Put, baseAddress + "/api/v1/service/employee/toggle");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<EmployeeEnableResponse>(stringData);
                    var issues = JsonConvert.SerializeObject(data.Reason).Replace("\"", "");
                    issues = issues.Replace(":", " ").Replace(",", " ");
                    if (data.Identifiers.Status == "success")
                    {
                        result.SystemId = data.IntegrateAccount.ExtraData.SystemId;
                        result.SystemStatus = data.IntegrateAccount.ExtraData.SystemStatus;
                        result.Message = "Employee is Enabled";
                        result.Status = data.Identifiers.Status;
                        result.RequestId = data.Identifiers.RequestId;
                        return Ok(result);
                    }
                    else
                    {
                        result.Message = issues;
                        result.Status = data.Identifiers.Status;
                        result.RequestId = data.Identifiers.RequestId;
                        return Ok(result);
                    }
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region CreateEmployee
        [HttpPost("NewEmployee.{format}"), FormatFilter]
        public async Task<IActionResult> NewEmployee([FromBody] EmployeeRequest obj)
        {
            try
            {
                CreateResponseEmployee result = new CreateResponseEmployee();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "api/v1/service/employee");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<NewEmployeeResponse>(stringData);
                    var issues = JsonConvert.SerializeObject(data.Reason).Replace("\"", "");
                    issues = issues.Replace(":", " ").Replace(",", " ");
                    result.Message = data.Identifiers.Status == "success" ? "Added employee Successfully" : issues;
                    result.Status = data.Identifiers.Status;
                    result.RequestId = data.Identifiers.RequestId;
                    //result.Reasons = JsonConvert.SerializeObject(data.Reason).ToString();
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region UpdateEmployee
        [HttpPost("UpdateEmployee.{format}"), FormatFilter]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeRequest obj)
        {
            try
            {
                UpdateResponseEmployee result = new UpdateResponseEmployee();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Put, baseAddress + "api/v1/service/employee");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<UpdateEmployeeResponse>(stringData);
                    var issues = JsonConvert.SerializeObject(data.Reason).Replace("\"", "");
                    issues = issues.Replace(":", " ").Replace(",", " ");
                    result.Message = data.Identifiers.Status == "success" ? "Updated employee Successfully" : issues;
                    result.Status = data.Identifiers.Status;
                    result.RequestId = data.Identifiers.RequestId;
                    //result.Reasons = JsonConvert.SerializeObject(data.Reason).ToString();
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region DeleteEmployee
        [HttpDelete("DeleteEmployee.{format}"), FormatFilter]
        public async Task<IActionResult> DeleteEmployee([FromBody] DeleteEmployeeRequest obj)
        {
            try
            {
                DeleteResponseEmployee result = new DeleteResponseEmployee();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Delete, baseAddress + "api/v1/service/employee");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<DeleteEmployeeResponse>(stringData);
                    result.Message = data.Identifiers.Status == "success" ? "Delete employee Successfully" : "Falid to delete record!";
                    result.Status = data.Identifiers.Status;
                    result.RequestId = data.Identifiers.RequestId;
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Connect employee with applicant
        [HttpPost("ConnectEmployeeApplicant.{format}"), FormatFilter]
        public async Task<IActionResult> ConnectEmployeeApplicant([FromBody] ConnectEmployeeApplicantRequest obj)
        {
            try
            {
                ConnectResponseApplicantEmployee result = new ConnectResponseApplicantEmployee();
                ConnectEmployeeApplicant_Response result1 = new ConnectEmployeeApplicant_Response();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Put, baseAddress + "api/v1/service/employee/applicant/connect");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    ConnectEmployeeApplicantErrorResponse errordata;
                    ConnectEmployeeApplicant_Response data;
                    if (response.IsSuccessStatusCode)
                    {
                        data = JsonConvert.DeserializeObject<ConnectEmployeeApplicant_Response>(stringData);
                        result.Message = "Connect Employee With Applicant Successfully";
                        result.Status = data.Identifiers.Status;
                        result.RequestId = data.Identifiers.RequestId;
                        return Ok(result);
                    }
                    else
                    {
                        errordata = JsonConvert.DeserializeObject<ConnectEmployeeApplicantErrorResponse>(stringData);
                        var issues = JsonConvert.SerializeObject(errordata.Reason).Replace("\"", "");
                        issues = issues.Replace(":", " ").Replace(",", " ");
                        result.Message = issues;
                        result.Status = errordata.Identifiers.Status;
                        result.RequestId = errordata.Identifiers.RequestId;
                        return BadRequest(result);
                    }
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Return Exception
        private IActionResult ReturnException(Exception ex)
        {
            // HttpContext.Response.ContentType = "application/json";
            HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return StatusCode(HttpContext.Response.StatusCode, JsonConvert.SerializeObject(new
            {
                error = new
                {
                    message = ex.Message,
                    exception = ex.GetType().Name
                }
            }));
        }
        #endregion
    }
}