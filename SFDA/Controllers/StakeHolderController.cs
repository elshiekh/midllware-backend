using Microsoft.AspNetCore.Mvc;
using StakeholderList;
using System;
using System.Threading.Tasks;

namespace SFDA.Controllers
{
    [ApiController]
    public class StakeHolderController : ControllerBase
    {
        [HttpPost("api/SFDA/GetStakeHolderList/.{format}"), FormatFilter]
        public async Task<stakeholderListServiceResponse> GetStakeHolderList([FromBody] stakeholderListServiceRequest request, string gln)
        {
            try
            {
                StakeholderListServiceClient client = new StakeholderListServiceClient();

                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getStakeholderListAsync(request);

                return result.StakeholderListServiceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}