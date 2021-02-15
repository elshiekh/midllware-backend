using DrugService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace SFDA.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DrugController : ControllerBase
    {
        [HttpPost("api/SFDA/GetDrugList/.{format}"), FormatFilter]
        public async Task<drugListServiceResponse> GetDrugList([FromBody] drugListServiceRequest request, string gln)
        {
            try
            {
                DrugListServiceClient client = new DrugListServiceClient();
                var requestedPost = new getDrugListRequest(request);
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getDrugListAsync(requestedPost);

                return result.DrugListServiceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}