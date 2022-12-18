using Fusion_Out.FusionOut;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Fusion_Out.Mapper;

namespace Fusion_Out.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class FusionOutController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public FusionOutController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion


        #region UpdateStatusCallback
        [HttpPost("UpdateStatusCallback.{format}"), FormatFilter]
        public async Task<IActionResult> UpdateStatusCallback([FromBody] List<UpdateStatusCallbackRequest> obj)
        {
            try
            {
                var client = new HttpClient();

                var baseAddress = new Uri(_dbOption.BaseAddress);
                client.Timeout = TimeSpan.FromMinutes(5);

                byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                var request = new HttpRequestMessage(HttpMethod.Post, "https://OICTest-hmgmobility.integration.ocp.oraclecloud.com:443/ic/api/integration/v1/flows/rest/INT_EBS_CALL_BACK/1.0/updateTransactionStatus");


                request.Headers.Authorization = new BasicAuthenticationHeaderValue("Ahmad.Majed@cloudsolution-sa.com", "Cloud123456789");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));

                var postObject = JsonConvert.SerializeObject(obj);

                request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);

                var response = await client.SendAsync(request);

                string stringData = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<UpdateStatusCallbackResponse>(stringData);

                return Ok(data);
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
