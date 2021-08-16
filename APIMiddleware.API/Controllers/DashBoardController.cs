using APIMiddleware.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIMiddleware.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardService _dashboardService;
        private readonly ILogger<FunctionController> _logger;

        public DashBoardController(IDashBoardService dashboardService, ILogger<FunctionController> logger)
        {
            _dashboardService = dashboardService;
            _logger = logger;
        }
   
        [HttpGet("GetDashBoardDetails")]
        public IActionResult GetDashBoardDetails()
        {
            var result = _dashboardService.GetDashBoardDetails();
            return Ok(result);
        }
      
    }
}
