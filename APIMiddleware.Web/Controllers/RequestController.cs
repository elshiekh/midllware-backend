using APIMiddleware.Core.Services.Interface;
using APIMiddleware.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace APIMiddleware.Web.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public ActionResult Index()
        {
            var requests = _requestService.GetAllRequests();
            var list = requests.Select(s => new RequestMolel
            {
                Id = s.Id,
                ProjectName = s.ProjectName,
                RequestGuid = s.RequestGuid,
                RequestTime = s.RequestTime,
                ElapsedMilliseconds = s.ElapsedMilliseconds,
                Method = s.Method,
                QueryString = s.QueryString,
                Path = s.Path,
                StatusCode = s.StatusCode,
                IsSuccess = s.IsSuccess,
            });

            return View(list);
        }

        public ActionResult Details(int id)
        {
            var request = _requestService.GetRequestsDetails(id);
            var model = new RequestMolel()
            {
                Id = request.Id,
                ProjectName = request.ProjectName,
                RequestGuid = request.RequestGuid,
                RequestTime = request.RequestTime,
                ElapsedMilliseconds = request.ElapsedMilliseconds,
                StatusCode = request.StatusCode,
                Method = request.Method,
                Path = request.Path,
                QueryString = (request.QueryString != string.Empty) ? request.QueryString : "No Parameters",
            };
            return View(model);
        }

        public ActionResult DownloadResponseBodyContent(int id)
        {
            var response = _requestService.GetRequestsDetails(id);
            if (response.ResponseBody != null)
            {
                byte[] bytes = response?.ResponseBody;
                var output = new FileContentResult(bytes, "application/octet-stream");
                output.FileDownloadName = response.RequestGuid + ".txt";

                return output;
            }

            return null;
        }

        public ActionResult DownloadRequestBodyContent(int id)
        {
            var request = _requestService.GetRequestsDetails(id);
            if (request.RequestBody != null)
            {
                byte[] bytes = request?.RequestBody;
                var output = new FileContentResult(bytes, "application/octet-stream");
                output.FileDownloadName = request.RequestGuid + ".txt";

                return output;
            }

            return null;
        }
    }
}
