using APIMiddleware.Core.Services.Interface;
using APIMiddleware.Web.Extensions;
using APIMiddleware.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

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
            return View();
        }

        public async Task<JsonResult> LoadTable([FromBody] DtParameters dtParameters)
        {
            var searchBy = dtParameters.Search?.Value;
            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;

            if (dtParameters.Order != null)
            {
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "asc";
            }
            else
            {
                orderCriteria = "RequestId";
                orderAscendingDirection = true;
            }

            var result = await _requestService.GetAllRequests();

            if (!string.IsNullOrEmpty(searchBy))
            {
                result =  result.Where(r => r.ProjectName != null && r.ProjectName.ToUpper().Contains(searchBy.ToUpper()) ||
                                           r.RequestUrl != null && r.RequestUrl.ToUpper().Contains(searchBy.ToUpper()) ||
                                           r.RequestMethod != null && r.RequestMethod.ToUpper().Contains(searchBy.ToUpper()) ||
                                           r.RequestDate != null && r.RequestDate.ToString("dd/MM/yyyy").Contains(searchBy) ||
                                             r.RequestTime != null && r.RequestTime.ToString("HH:mm").Contains(searchBy) ||
                                           r.ResponseCode != 0 && r.ResponseCode.ToString().Contains(searchBy) ||
                                           r.ElapsedMilliseconds != 0 && r.ElapsedMilliseconds.ToString().Contains(searchBy) ||
                                           r.RequestStatus.ToString().Contains(searchBy)
                                          )
                    .ToList();
            }

            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, DtOrderDir.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, DtOrderDir.Desc).ToList();

            var filteredResultsCount = result.Count();
            var totalResultsCount = await _requestService.GetAllRequestCounts();

            return Json(new
            {
                draw = dtParameters.Draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = result
            });
        }

        public async Task<ActionResult> Details(int id)
        {
            var request = await _requestService.GetRequestsDetails(id);
            var model = new RequestMolel()
            {
                Id = request.Id,
                ProjectName = request.ProjectName,
                RequestGuid = request.RequestGuid,
                RequestTime = request.RequestTime,
                ElapsedMilliseconds = request.ElapsedMilliseconds,
                StatusCode = request.ResponseCode,
                Method = request.RequestMethod,
                Path = request.RequestUrl,
                QueryString = (request.QueryString != string.Empty) ? request.QueryString : "No Parameters",
            };
            return View(model);
        }

        public async Task<ActionResult> DownloadResponseBodyContent(int id)
        {
            var response = await _requestService.GetRequestsDetails(id);
            if (response.ResponseBody != null)
            {
                byte[] bytes = response?.ResponseBody;
                var output = new FileContentResult(bytes, "application/octet-stream");
                output.FileDownloadName = response.RequestGuid + ".txt";

                return output;
            }

            return null;
        }

        public async Task<ActionResult> DownloadRequestBodyContent(int id)
        {
            var request = await _requestService.GetRequestsDetails(id);
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
