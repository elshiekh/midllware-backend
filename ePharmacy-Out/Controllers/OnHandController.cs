using ePharmacy_Out.OnHand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ePharmacy_Out.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class OnHandController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public OnHandController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region CreateBranch
        [HttpPost("NewBranch.{format}"), FormatFilter]
        public async Task<IActionResult> NewBranch([FromBody] BranchRequest obj)
        {
            try
            {
                NewResponseBranch result = new NewResponseBranch();

                using (var client = new HttpClient()) 
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
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

                    var issues = JsonConvert.SerializeObject(data.Reason).Replace("\"", "");
                    issues = issues.Replace(":", " ").Replace(",", " ");

                    result.Message = data.Identifiers.Status == "success" ? "Added Branch Successfully" : issues;
                    result.Status = data.Identifiers.Status;
                    result.RequestId = data.Identifiers.RequestId;

                    //result.Reasons = JsonConvert.SerializeObject(data.Reason).ToString();3                                        

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
