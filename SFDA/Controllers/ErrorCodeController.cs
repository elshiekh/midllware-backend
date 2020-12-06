using ErrorCodeService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace SFDA.Controllers
{
    [ApiController]
    public class ErrorCodeController : ControllerBase
    {
        [HttpPost("api/SFDA/GetErrorCodeList/.{format}"), FormatFilter]
        public async Task<IActionResult> GetErrorCodeList([FromBody] getErrorCodeListRequest request, string gln)
        {
            try
            {
                ErrorCodeListServiceClient client = new ErrorCodeListServiceClient();

                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getErrorCodeListAsync(request);

                return Ok(result.ErrorCodeListServiceResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}