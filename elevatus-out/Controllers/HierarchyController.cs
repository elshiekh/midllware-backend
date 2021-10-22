using elevatus_out.Hierarchy;
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
    public class HierarchyController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public HierarchyController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region GetHierarchy
        [HttpPost("GetHierarchys.{format}"), FormatFilter]
        public async Task<IActionResult> GetHierarchys([FromBody] GetHierarchyRequest obj)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    var request = new HttpRequestMessage(HttpMethod.Get, baseAddress + "/api/v1/service/hierarchy");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<GetHierarchyResponse>(stringData);
                    return Ok(data.IntegrateAccount.ExtraData);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region CreateHierarchy
        [HttpPost("NewHierarchy.{format}"), FormatFilter]
        public async Task<IActionResult> NewHierarchy([FromBody] HierarchyRequest obj)
        {
            try
            {
                CreateResponseHierarchy result = new CreateResponseHierarchy();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "api/v1/service/hierarchy");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<NewHierarchyResponse>(stringData);
                    result.Message = data.Identifiers.Status == "success" ? "Added Hierarchy Successfully" : "";
                    result.Status = data.Identifiers.Status;
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region UpdateHierarchy
        [HttpPut("UpdateHierarchy.{format}"), FormatFilter]
        public async Task<IActionResult> UpdateHierarchy([FromBody] HierarchyRequest obj)
        {
            try
            {
                UpdateResponseHierarchy result = new UpdateResponseHierarchy();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Put, baseAddress+ "api/v1/service/hierarchy");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<UpdateHierarchyResponse>(stringData);
                    result.Message = data.Identifiers.Status == "success" ? "Updated Hierarchy Successfully" : "";
                    result.Status = data.Identifiers.Status;
                    result.Reasons = data.Reason;
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region DeleteHierarchy
        [HttpDelete("DeleteHierarchy.{format}"), FormatFilter]
        public async Task<IActionResult> DeleteHierarchy([FromBody] DeleteHierarchyRequest obj)
        {
            try
            {
                DeleteResponseHierarchy result = new DeleteResponseHierarchy();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Delete, baseAddress+ "api/v1/service/hierarchy");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<DeleteHierarchyResponse>(stringData);
                    result.Message = data.Identifiers.Status == "success" ? "Delete Hierarchy Successfully" : "";
                    result.Status = data.Identifiers.Status;
                    return Ok(result);
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