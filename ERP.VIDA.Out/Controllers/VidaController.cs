
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vida.DTO.Vida;
using Vida.Extenstion;

namespace Vida.Controllers
{
  
   // [Authorize]
   [ApiController]
    [Consumes("application/xml")]
    [Produces("application/xml")]
    public class VidaController : ControllerBase
    {
        private readonly DBOption _dbOption;
        public VidaController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }

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
                throw ex;
            }
        }
    }
}
