using AcceptDispatchPackageService;
using AcceptProductService;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductPackageDownloadService;
using ProductPackageUploadService;
using QueryPackageService;
using SFDA.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SFDA.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PackageController : ControllerBase
    {
        //[HttpPost("api/SFDA/PackageQuery.{format}"), FormatFilter]
        //public async Task<IActionResult> PackageQuery([FromBody] packageQueryServiceRequest request, string gln)
        //{
        //    try
        //    {
        //        PackageQueryServiceClient client = new PackageQueryServiceClient();
        //        var postRequest = new packageQueryRequest(request);
        //        client.ClientCredentials.UserName.UserName = gln + "0000";
        //        client.ClientCredentials.UserName.Password = "Ahmad123456";
        //        var result = await client.packageQueryAsync(postRequest);

        //        return Ok(result.PackageQueryServiceResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ReturnException(ex);
        //    }
        //}

        //[HttpPost("api/SFDA/Accept.{format}"), FormatFilter]
        //public async Task<IActionResult> Accept([FromBody] acceptServiceRequest request, string gln)
        //{
        //    try
        //    {
        //        AcceptServiceClient client = new AcceptServiceClient();
        //        var postRequest = new AcceptProductService.notifyAcceptRequest() { AcceptServiceRequest = request };
        //        client.ClientCredentials.UserName.UserName = gln + "0000";
        //        client.ClientCredentials.UserName.Password = "Ahmad123456";
        //        var result = await client.notifyAcceptAsync(postRequest);

        //        return Ok(result.AcceptServiceResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //[HttpPost("api/SFDA/AcceptDispatch.{format}"), FormatFilter]
        //public async Task<IActionResult> AcceptDispatch([FromBody] acceptDispatchServiceRequest request, string gln)
        //{
        //    try
        //    {
        //        AcceptDispatchServiceClient client = new AcceptDispatchServiceClient();
        //        var postRequest = new AcceptDispatchPackageService.notifyAcceptRequest() { AcceptDispatchServiceRequest = request };
        //        client.ClientCredentials.UserName.UserName = gln + "0000";
        //        client.ClientCredentials.UserName.Password = "Ahmad123456";
        //        var result = await client.notifyAcceptAsync(postRequest);

        //        return Ok(result.AcceptDispatchServiceResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        
        //[HttpPost("api/SFDA/PackageDownload.{format}"), FormatFilter]
        //public async Task<IActionResult> PackageDownload([FromBody] packageDownloadServiceRequest request, string gln)
        //{
        //    try
        //    {
        //        PackageDownloadServiceClient client = new PackageDownloadServiceClient();
        //        PackageDownloadResponse response = new PackageDownloadResponse();
        //        var postRequest = new downloadFileRequest() { PackageDownloadServiceRequest = request };
        //        client.ClientCredentials.UserName.UserName = gln + "0000";
        //        client.ClientCredentials.UserName.Password = "Ahmad123456";
        //        var result = await client.downloadFileAsync(postRequest);

        //        response.MD5CHECKSUM = result.PackageDownloadServiceResponse.MD5CHECKSUM;
        //        response.FILES = GetUnCompressedFiles(result.PackageDownloadServiceResponse.FILE);

        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //[HttpPost("api/SFDA/PackageUpload.{format}"), FormatFilter]
        //public async Task<IActionResult> PackageUpload([FromBody] packageUploadServiceRequest request, string gln)
        //{
        //    try
        //    {
        //        PackageUploadServiceClient client = new PackageUploadServiceClient();
        //        var postRequest = new uploadFileRequest() { PackageUploadServiceRequest = request };
        //        client.ClientCredentials.UserName.UserName = gln + "0000";
        //        client.ClientCredentials.UserName.Password = "Ahmad123456";
        //        var result = await client.uploadFileAsync(postRequest);

        //        return Ok(result.PackageUploadServiceResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private List<FILE> GetUnCompressedFiles(byte[] data)
        //{
        //    List<FILE> result = new List<FILE>();
        //    using (var inputStream = new MemoryStream(data))
        //    {
        //        using (var zipInputStream = new ZipInputStream(inputStream))
        //        {
        //            ZipEntry entry;
        //            var ContentText = "";
        //            while ((entry = zipInputStream.GetNextEntry()) != null)
        //            {
        //                ContentText = "";
        //                var currentStream = new MemoryStream();
        //                var entryName = entry.Name;
                        
        //                zipInputStream.CopyTo(currentStream);
        //                MemoryStream stream = new MemoryStream(currentStream.ToArray());
        //                StreamReader reader = new StreamReader(stream);
        //                ContentText = reader.ReadToEnd();
        //               // ContentText = Regex.Replace(ContentText, @"\r\n", "");
        //                result.Add(new FILE() {NAME = entryName, CONTENT= ContentText.ToString() });
        //            }

        //        }

        //        return result;
        //    }
        //}

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