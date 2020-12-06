using AcceptDispatchPackageService;
using AcceptProductService;
using Microsoft.AspNetCore.Mvc;
using ProductPackageDownloadService;
using ProductPackageUploadService;
using QueryPackageService;
using System;
using System.Threading.Tasks;

namespace SFDA.Controllers
{
    [ApiController]
    public class PackageController : ControllerBase
    {
        [HttpPost("api/SFDA/PackageQuery/.{format}"), FormatFilter]
        public async Task<IActionResult> PackageQuery([FromBody] packageQueryServiceRequest request, string gln)
        {
            try
            {
                PackageQueryServiceClient client = new PackageQueryServiceClient();
                var postRequest = new packageQueryRequest(request);
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.packageQueryAsync(postRequest);

                return Ok(result.PackageQueryServiceResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("api/SFDA/Accept/.{format}"), FormatFilter]
        public async Task<IActionResult> Accept([FromBody] acceptServiceRequest request, string gln)
        {
            try
            {
                AcceptServiceClient client = new AcceptServiceClient();
                var postRequest = new AcceptProductService.notifyAcceptRequest() { AcceptServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyAcceptAsync(postRequest);

                return Ok(result.AcceptServiceResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("api/SFDA/AcceptDispatch/.{format}"), FormatFilter]
        public async Task<IActionResult> AcceptDispatch([FromBody] acceptDispatchServiceRequest request, string gln)
        {
            try
            {
                AcceptDispatchServiceClient client = new AcceptDispatchServiceClient();
                var postRequest = new AcceptDispatchPackageService.notifyAcceptRequest() { AcceptDispatchServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyAcceptAsync(postRequest);

                return Ok(result.AcceptDispatchServiceResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("api/SFDA/PackageDownload/.{format}"), FormatFilter]
        public async Task<IActionResult> PackageDownload([FromBody] packageDownloadServiceRequest request, string gln)
        {
            try
            {
                PackageDownloadServiceClient client = new PackageDownloadServiceClient();
                var postRequest = new downloadFileRequest() { PackageDownloadServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.downloadFileAsync(postRequest);

                return Ok(result.PackageDownloadServiceResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("api/SFDA/PackageUpload/.{format}"), FormatFilter]
        public async Task<IActionResult> PackageUpload([FromBody] packageUploadServiceRequest request, string gln)
        {
            try
            {
                PackageUploadServiceClient client = new PackageUploadServiceClient();
                var postRequest = new uploadFileRequest() { PackageUploadServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.uploadFileAsync(postRequest);

                return Ok(result.PackageUploadServiceResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}