using APIMiddleware.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace APIMiddleware.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FunctionController : ControllerBase
    {
        private readonly IFunctionService _functionService;
        private readonly ILogger<FunctionController> _logger;

        public FunctionController(IFunctionService functionService, ILogger<FunctionController> logger)
        {
            _functionService = functionService;
            _logger = logger;
        }

        [HttpGet("GetAllFunctions")]
        public async Task<IActionResult> GetAllFunctions()
        {
            var result = await _functionService.GetAllFunctions();
            return Ok(result);
        }
        [HttpGet("GetAllFunctionsByProject")]
        public async Task<IActionResult> GetAllFunctionsByProject(int projectId)
        {
            var result = await _functionService.GetAllFunctionsByProject(projectId);
            return Ok(result);
        }


        [HttpGet("GetFunctionById")]
        public async Task<IActionResult> GetFunctionById(int id)
        {
            var request = await _functionService.GetFunctionsDetails(id);
            return Ok(request);
        }
    }
}
