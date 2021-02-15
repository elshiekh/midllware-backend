using APIMiddleware.API.Models;
using APIMiddleware.Core.Services.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace APIMiddleware.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly ILogger<RequestController> _logger;

        public RequestController(IRequestService requestService, ILogger<RequestController> logger)
        {
            _requestService = requestService;
            _logger = logger;
        }

   
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _requestService.GetAllRequests();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = await _requestService.GetRequestsDetails(id);
            var model = new RequestMolel()
            {
                Id = request.Id,
                ProjectName = request.ProjectName,
                RequestGuid = request.RequestGuid,
                RequestTime = request.RequestTime,
                Time = request.Time,
                ElapsedMilliseconds = request.ElapsedMilliseconds,
                StatusCode = request.StatusCode,
                Method = request.Method,
                Path = request.Path,
                QueryString = (request.QueryString != string.Empty) ? request.QueryString : "No Parameters",
            };
            return Ok(model);
        }

        [HttpGet("DownloadResponse/{id}")]
        public async Task<ActionResult> DownloadResponseBodyContent(int id)
        {
            var response = await _requestService.GetRequestsDetails(id);
            if (response.ResponseBody != null)
            {
                byte[] bytes = response?.ResponseBody;
                var output = new FileContentResult(bytes, "application/octet-stream");
                output.FileDownloadName = response.RequestGuid + ".txt";

                return Ok(output);
            }

            return null;
        }

        [HttpGet("DownloadRequest/{id}")]
        public async Task<ActionResult> DownloadRequestBodyContent(int id)
        {
            var request = await _requestService.GetRequestsDetails(id);
            if (request.RequestBody != null)
            {
                byte[] bytes = request?.RequestBody;
                var output = new FileContentResult(bytes, "application/octet-stream");
                output.FileDownloadName = request.RequestGuid + ".txt";

                return Ok(output);
            }

            return null;
        }

    }
}