using CheckStatusCodeService;
using DeactivationProuctService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Threading.Tasks;

namespace SFDA.Controllers
{
    [ApiController]
    public class CheckStatusController : ControllerBase
    {
        [HttpPost("api/SFDA/NotifyCheckStatus/.{format}"), FormatFilter]
        public async Task<checkStatusServiceResponse> NotifyCheckStatus([FromBody] checkStatusServiceRequest request, string gln)
        {
            try
            {
                CheckStatusServiceClient client = new CheckStatusServiceClient();
                var postRequest = new notifyCheckStatusRequest() { CheckStatusServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyCheckStatusAsync(postRequest);

                return result.CheckStatusServiceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}