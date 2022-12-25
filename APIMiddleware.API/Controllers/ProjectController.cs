using APIMiddleware.API.Models;
using APIMiddleware.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace APIMiddleware.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(IProjectService requestService, ILogger<ProjectController> logger)
        {
            _projectService = requestService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _projectService.GetAllProjects();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = await _projectService.GetProjectsDetails(id);
            var model = new ProjectModel()
            {
                Id = request.ProjectId,
                Code = request.ProjectCode,
                Name = request.ProjectName,
            };
            return Ok(model);
        }
    }
}
