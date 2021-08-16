using APIMiddleware.API.Models;
using APIMiddleware.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
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

        [HttpGet("AllRequests")]
        public async Task<IActionResult> AllRequests()
        {
            var result = await _requestService.GetAllRequests();
            return Ok(result);
        }

        [HttpGet("GetAllWithFilter")]
        public async Task<IActionResult> GetAllWithFilter(int? requestId,int? projectId, int? function,
            int? responseCode, string requestStatus,
            string ipAddress, string userName, string fromDate, string toDate)
        {
            try
            {
                var result = await _requestService.GetAllWithFilter(requestId,projectId, function,
                responseCode, requestStatus.Trim(),
                ipAddress, userName, fromDate, toDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }

        }

        [HttpDelete("PurgeAllWithFilter")]
        public IActionResult PurgeAllWithFilter(int? requestId, int? projectId, int? function,
          int? responseCode, string requestStatus,
          string ipAddress, string userName, string fromDate, string toDate)
        {
            try
            {
                var result =  _requestService.PurgeAllWithFilter(requestId, projectId, function,
                responseCode, requestStatus.Trim(),
                ipAddress, userName, fromDate, toDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        //[HttpPost("PostFilterRequest")]
        //public async Task<IActionResult> PostFilterRequest([FromBody] RequestFilterPost request)
        //{
        //    var result = await _requestService.GetAllWithFilter(request.requestId, request.projectId, request.function,
        //      request.responseCode, request.requestStatus,
        //      request.ipAddress, request.userName, request.fromDate, request.toDate);
        //    return Ok(result);
        //}

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = await _requestService.GetRequestsDetails(id);
            return Ok(request);
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

        #region Return Exception
        private IActionResult ReturnException(Exception ex)
        {
            HttpContext.Response.ContentType = "application/json";
            HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return StatusCode(HttpContext.Response.StatusCode, JsonConvert.SerializeObject(new
            {
                error = new
                {
                    message = ex.Message,
                    exception = ex.GetType().Name
                }
            }));
        }
        #endregion
    }
}