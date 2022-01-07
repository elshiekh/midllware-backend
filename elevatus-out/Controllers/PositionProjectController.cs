using elevatus_out.PositionProject;
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
    public class PositionProjectController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public PositionProjectController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region GetPositionProject
        [HttpGet("GetPositionProjects.{format}"), FormatFilter]
        public async Task<IActionResult> GetPositionProjects(int limit = 30, int page = 1)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    var request = new HttpRequestMessage(HttpMethod.Get, baseAddress + "/api/v1/service/position/project?limit=" + limit + "&page=" + page);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    request.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<GetPositionProjectResponse>(stringData);
                    return Ok(data.IntegrateAccount.ExtraData);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region CreatePositionProject
        [HttpPost("NewPositionProject.{format}"), FormatFilter]
        public async Task<IActionResult> NewPositionProject([FromBody] PositionProjectRequest obj)
        {
            try
            {
                CreateResponsePositionProject result = new CreateResponsePositionProject();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "api/v1/service/position/project");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<NewPositionProjectResponse>(stringData);
                    var issues = JsonConvert.SerializeObject(data.Reason).Replace("\"", "");
                    issues = issues.Replace(":", " ").Replace(",", " ");
                    result.Message = data.Identifiers.Status == "success" ? "Added Position Project Successfully" : issues;
                    result.Status = data.Identifiers.Status;
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

        #region UpdatePositionProject
        [HttpPut("UpdatePositionProject.{format}"), FormatFilter]
        public async Task<IActionResult> UpdatePositionProject([FromBody] PositionProjectRequest obj)
        {
            try
            {
                UpdateResponsePositionProject result = new UpdateResponsePositionProject();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Put, baseAddress+ "api/v1/service/position/project");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<UpdatePositionProjectResponse>(stringData);
                    var issues = JsonConvert.SerializeObject(data.Reason).Replace("\"", "");
                    issues = issues.Replace(":", " ").Replace(",", " ");
                    result.Message = data.Identifiers.Status == "success" ? "Updated Position Project Successfully" : issues;
                    result.Status = data.Identifiers.Status;
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

        #region DeletePositionProject
        [HttpDelete("DeletePositionProject.{format}"), FormatFilter]
        public async Task<IActionResult> DeletePositionProject([FromBody] DeletePositionProjectRequest obj)
        {
            try
            {
                DeleteResponsePositionProject result = new DeleteResponsePositionProject();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Delete, baseAddress+ "api/v1/service/position/project");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<DeletePositionProjectResponse>(stringData);
                    result.Message = data.Identifiers.Status == "success" ? "Delete Position Project Successfully" : "Falid to delete record!";
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