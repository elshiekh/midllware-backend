﻿using elevatus_out.Branch;
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
    public class BranchController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public BranchController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region GetBranch
        [HttpGet("GetBranches.{format}"), FormatFilter]
        public async Task<IActionResult> GetBranches(int limit = 30, int page = 1)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Get, baseAddress + "api/v1/service/branch?limit=" + limit + "&page=" + page);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    request.Content = new StringContent(string.Empty, Encoding.UTF8);
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<GetBranchResponse>(stringData);
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region CreateBranch
        [HttpPost("NewBranch.{format}"), FormatFilter]
        public async Task<IActionResult> NewBranch([FromBody] BranchRequest obj)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "api/v1/service/branch");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<NewBranchResponse>(stringData);
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region UpdateBranch
        [HttpPut("UpdateBranch.{format}"), FormatFilter]
        public async Task<IActionResult> UpdateBranch([FromBody] BranchRequest obj)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var baseAddress =  new Uri(_dbOption.BaseAddress);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Put, baseAddress + "api/v1/service/branch");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<UpdateBranchResponse>(stringData);
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region DeleteBranch
        [HttpDelete("DeleteBranch.{format}"), FormatFilter]
        public async Task<IActionResult> DeleteBranch([FromBody] DeleteBranchRequest obj)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    var request = new HttpRequestMessage(HttpMethod.Delete, baseAddress + "api/v1/service/branch");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<DeleteBranchResponse>(stringData);
                    return Ok(data);
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