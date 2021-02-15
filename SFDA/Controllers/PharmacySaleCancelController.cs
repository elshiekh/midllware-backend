using Microsoft.AspNetCore.Mvc;
using Pharmacy_SaleService;
using PharmacyProductSaleCancelService;
using System;
using System.Threading.Tasks;

namespace SFDA.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PharmacyController : ControllerBase
    {
        [HttpPost("api/SFDA/PharmacySale/.{format}"), FormatFilter]
        public async Task<pharmacySaleServiceResponse> PharmacySaleCancel([FromBody]pharmacySaleServiceRequest request, string gln)
        {
            try
            {
                PharmacySaleServiceClient client = new PharmacySaleServiceClient();
                var postRequest = new notifyPharmacySaleRequest { PharmacySaleServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyPharmacySaleAsync(postRequest);

                return result.PharmacySaleServiceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("api/SFDA/PharmacySaleCancel/.{format}"), FormatFilter]
        public async Task<pharmacySaleCancelServiceResponse> PharmacySaleCancel([FromBody]pharmacySaleCancelServiceRequest request, string gln)
        {
            try
            {
                PharmacySaleCancelServiceClient client = new PharmacySaleCancelServiceClient();
                var postRequest = new notifyPharmacySaleCancelRequest { PharmacySaleCancelServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyPharmacySaleCancelAsync(postRequest);

                return result.PharmacySaleCancelServiceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}