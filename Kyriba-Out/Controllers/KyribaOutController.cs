using Kyriba_Out.DTO;
using Kyriba_Out.PGB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Kyriba_Out.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    [FormatFilter]
    public class KyribaOutController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        private readonly ILogger<KyribaOutController> _logger;
        public KyribaOutController(DBOption dbOption, ILogger<KyribaOutController> logger)
        {
            _dbOption = dbOption;
            _logger = logger;
        }
        #endregion

        #region Upload File

        [HttpPost("UploadFile.{format}"), FormatFilter]
        public  IActionResult UploadFile(UploadFileRequest model)
        {
            try
            {
                //Create an FtpWebRequest
                var request = (FtpWebRequest)WebRequest.Create(_dbOption.FtpAddress + model.fileName + "." + model.fileExtension);
                //Set the method to UploadFile 
                request.Method = WebRequestMethods.Ftp.UploadFile;
                //Set the NetworkCredentials
                request.Credentials = new NetworkCredential(_dbOption.UserName, _dbOption.Password);
                request.UseBinary = false;
                request.UsePassive = true;
                request.Timeout = 500;
                request.EnableSsl = true;
                request.KeepAlive = false;

                byte[] fileInbytes = Convert.FromBase64String(model.fileByte);
                var input = fileInbytes;
                var publicKey = System.IO.File.ReadAllBytes(@"C:/inetpub/wwwroot/Services/kyriba-out/Resources/Acceptance DB63F5F673F4DC03.asc");
                var pgp = new Pgp();
                var encrBytes = pgp.Encrypt(input, publicKey);
                //System.IO.File.WriteAllBytes(@"C:/inetpub/wwwroot/Services/kyriba-out/EncryptedFiles/" + model.fileName +"."+ model.fileExtension, encrBytes);

                //Upload the 'fileContents' byte array 
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(encrBytes, 0, encrBytes.Length);
                }

                //Get the response
                // Some proper handling is needed
                var response = (FtpWebResponse)request.GetResponse();
                return Ok(response.StatusCode == FtpStatusCode.ClosingData);
            }
            catch (WebException ex)
            {
                return ReturnException(ex);
            }
        }

        #endregion

        #region Return Exception
        private IActionResult ReturnException(WebException ex)
        {
            HttpContext.Response.ContentType = "application/json";
            HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return StatusCode(HttpContext.Response.StatusCode, JsonConvert.SerializeObject(new
            {
                error = new
                {
                     message = ((FtpWebResponse)ex.Response).StatusDescription,
                    exception = ex.GetType().Name
                }
            }));
        }
        #endregion
    }
}
