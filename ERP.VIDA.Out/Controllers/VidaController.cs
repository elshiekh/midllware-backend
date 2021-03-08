using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vida.DTO.Vida;

namespace Vida.Controllers
{

    // [Authorize]
    [ApiController]
    [Consumes("application/xml")]
    [Produces("application/xml")]
    public class VidaController : ControllerBase
    {

        #region Filed
        private readonly DBOption _dbOption;
        public VidaController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region SCMInventory
        [HttpPost("api/vida/SCMInventory"), FormatFilter]
        public async Task<IActionResult> SCMInventory([FromBody] SCMInventoryRequest request)
        {
            try
            {
                SCMInventoryResponse result = new SCMInventoryResponse();

                using (var httpClient = new HttpClient())
                {
                    string postObject = JsonConvert.SerializeObject(request);

                    StringContent content = new StringContent(postObject, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(_dbOption.VidaURLConnection, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<SCMInventoryResponse>(apiResponse);
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
