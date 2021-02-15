using CityService;
using CountryService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Vida.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CountryController : ControllerBase
    {
        [HttpPost("api/SFDA/GetCountryList/.{format}"), FormatFilter]
        public async Task<countryListServiceResponse> GetCountryList([FromBody] countryListServiceRequest request, string gln)
        {
            try
            {
                CountryListServiceClient client = new CountryListServiceClient();
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getCountryListAsync(request);

                return result.CountryListServiceResponse;
            }
            catch (Exception)
            {
                throw ;
            }
        }

        [HttpPost("api/SFDA/GetCityList/.{format}"), FormatFilter]
        public async Task<cityListServiceResponse> GetCityList([FromBody] cityListServiceRequest request, string gln)
        {
            try
            {
                CityListServiceClient client = new CityListServiceClient();
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getCityListAsync(request);

                return result.CityListServiceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}