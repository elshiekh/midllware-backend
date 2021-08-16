using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MohemmOut;
using MohemmOut.DTO;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Enum = MohemmOut.Enum.Enum;

namespace Mohemmout.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class MohemmoutController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public MohemmoutController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region Send Notification
        [HttpPost("SendNotification.{format}")]
        public async Task<IActionResult> SendNotification([FromBody] SendNotificationRequest request)
        {
            try
            {
                object result;
                SendNotificationResponse successResult = new SendNotificationResponse();

                using (var httpClient = new HttpClient())
                {
                    string postObject = JsonConvert.SerializeObject(request);
                    StringContent content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(_dbOption.MohemmUrlConnection, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        successResult = JsonConvert.DeserializeObject<SendNotificationResponse>(apiResponse);
                        var messageStatus = (int)Enum.Response.S;
                        if (successResult.MessageStatus == messageStatus.ToString())
                        {
                            successResult.MessageStatus = nameof(Enum.ResponseCode.S);
                            successResult.ErrorMessage = null;
                            result = successResult;
                        }
                        else {
                            successResult = JsonConvert.DeserializeObject<SendNotificationResponse>(apiResponse);
                            successResult.MessageStatus = nameof(Enum.ResponseCode.E);
                            result = successResult;
                        }
                    }
                }
                return Ok(result);
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
            HttpContext.Response.ContentType = "application/json";
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