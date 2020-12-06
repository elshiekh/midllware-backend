
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vida.DTO.Vida;

namespace Vida.Controllers
{
    [Route("[controller]"), ApiController, Authorize]
    public class VidaController : ControllerBase
    {
        private readonly DBOption _dbOption;
        public VidaController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }

        [HttpPost("api/vida/SCMInventory.{format}"), FormatFilter]
        public async Task<IActionResult> AddReservation([FromBody] SCMInventoryRequest reservation)
        {
            try
            {
                SCMInventoryResponse result = new SCMInventoryResponse();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(_dbOption.VidaURLConnection, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<SCMInventoryResponse>(apiResponse);
                    }
                }
                return Ok(result);
            }
            catch (System.Exception e)
            {
                throw;
            }
        }
    }
}
