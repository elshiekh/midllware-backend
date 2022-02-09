using elevatus_out.OrganizationGroup;
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
    public class OrganizationGroupController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public OrganizationGroupController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region GetOrganizationGroup
        [HttpGet("GetOrganizationGroups.{format}"), FormatFilter]
        public async Task<IActionResult> GetOrganizationGroups(int limit = 30, int page = 1)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    var request = new HttpRequestMessage(HttpMethod.Get, baseAddress + "/api/v1/service/organization/group?limit=" + limit + "&page=" + page);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    request.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<GetOrganizationGroupResponse>(stringData);
                    return Ok(data.IntegrateAccount.ExtraData);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region CreateOrganizationGroup
        [HttpPost("NewOrganizationGroup.{format}"), FormatFilter]
        public async Task<IActionResult> NewOrganizationGroup([FromBody] OrganizationGroupRequest obj)
        {
            try
            {
                CreateResponseOrganizationGroup result = new CreateResponseOrganizationGroup();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "api/v1/service/organization/group");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<NewOrganizationGroupResponse>(stringData);
                    var issues = JsonConvert.SerializeObject(data.Reason).Replace("\"", "");
                    issues = issues.Replace(":", " ").Replace(",", " ");
                    result.Message = data.Identifiers.Status == "success" ? "Added organization group Successfully" : issues;
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

        #region UpdateOrganizationGroup
        [HttpPut("UpdateOrganizationGroup.{format}"), FormatFilter]
        public async Task<IActionResult> UpdateOrganizationGroup([FromBody] OrganizationGroupRequest obj)
        {
            try
            {
                UpdateResponseOrganizationGroup result = new UpdateResponseOrganizationGroup();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Put, baseAddress+ "api/v1/service/organization/group");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<UpdateOrganizationGroupResponse>(stringData);
                    var issues = JsonConvert.SerializeObject(data.Reason).Replace("\"", "");
                    issues = issues.Replace(":", " ").Replace(",", " ");
                    result.Message = data.Identifiers.Status == "success" ? "Updated organization group Successfully" : issues;
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

        #region DeleteOrganizationGroup
        [HttpDelete("DeleteOrganizationGroup.{format}"), FormatFilter]
        public async Task<IActionResult> DeleteOrganizationGroup([FromBody] DeleteOrganizationGroupRequest obj)
        {
            try
            {
                DeleteResponseOrganizationGroup result = new DeleteResponseOrganizationGroup();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Delete, baseAddress+ "api/v1/service/organization/group");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<DeleteOrganizationGroupResponse>(stringData);
                    result.Message = data.Identifiers.Status == "success" ? "Delete organization group Successfully" : "Falid to delete record!";
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