using Kyriba_Out.DTO;
using Kyriba_Out.Helper;
using Kyriba_Out.PGB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Xunit;

namespace Kyriba_Out.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
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
        public IActionResult UploadFile([FromBody] UploadFileRequest model)
        {
            try
            {
                UploadFileResponse result = new UploadFileResponse();
                //Create an FtpWebRequest
                var request = (FtpWebRequest)WebRequest.Create(_dbOption.FtpAddress + "/in/" + model.fileName + "." + model.fileExtension);
                //Set the method to UploadFile 
                request.Method = WebRequestMethods.Ftp.UploadFile;
                //Set the NetworkCredentials
                request.Credentials = new NetworkCredential(_dbOption.UserName, _dbOption.Password);
                request.UseBinary = true;
                request.UsePassive = true;
                request.Timeout = Timeout.Infinite;
                request.KeepAlive = false;
                request.EnableSsl = true;

                var fileInbytes = ExtensionMethods.DecodeUrlBase64(model.fileByte);
                var input = fileInbytes.FileInBase64;
                if (fileInbytes.Staus)
                {
                    var publicKey = System.IO.File.ReadAllBytes(@"C:/inetpub/wwwroot/Services/kyriba-out/Resources/Acceptance DB63F5F673F4DC03.asc");
                    var pgp = new Pgp();
                    var encrBytes = pgp.Encrypt(input, publicKey);
                    //System.IO.File.WriteAllBytes(@"C:/inetpub/wwwroot/Services/kyriba-out/EncryptedFiles/" + model.fileName +"."+ model.fileExtension, encrBytes);
                    //Upload the 'fileContents' byte array 
                    using (Stream requestStream = request.GetRequestStream())
                    {
                         requestStream.Write(encrBytes, 0, encrBytes.Length);
                        //requestStream.Write(input, 0, input.Length);
                    }
                    //Get the response
                    // Some proper handling is needed
                    var response = (FtpWebResponse)request.GetResponse();
                    result.ResponseStatus = response.StatusCode == FtpStatusCode.ClosingData ? "S" : "E";
                    result.ResponseMessage = "Uploaded Successfully";
                    response.Close();
                    return Ok(result);
                }
                else
                {
                    result.ResponseStatus = "E";
                    result.ResponseMessage = fileInbytes.Message;
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        #endregion

        #region Download File
        [HttpGet("DownloadFile.{format}"), FormatFilter]
        public IActionResult DownloadFile()
        {
            try
            {
                var directoryLists = RetrieveDirectoryListingsFromFTP(null);

                DownloadFileResponse result = new DownloadFileResponse();
                var fileResponse = new List<FileResponse>();
                foreach (var file in directoryLists)
                {
                    //Create an FtpWebRequest
                    var request = (FtpWebRequest)WebRequest.Create(_dbOption.FtpAddress + "/out/" + file.Name);
                    //Set the method to UploadFile 
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    //Set the NetworkCredentials
                    request.Credentials = new NetworkCredential(_dbOption.UserName, _dbOption.Password);
                    request.UseBinary = true;
                    request.UsePassive = true;
                    request.Timeout = Timeout.Infinite;
                    request.KeepAlive = false;
                    request.EnableSsl = true;

                    //Get the response
                    // Some proper handling is needed
                    var response = (FtpWebResponse)request.GetResponse();
                    using (var responseStream = response.GetResponseStream())
                    using (var memoryStream = new MemoryStream())
                    {
                        responseStream?.CopyTo(memoryStream);
                        var privateKey = System.IO.File.OpenRead("Resources/private-cloud2022.key");
                        var decrypted = Pgp.Decrypt(memoryStream.ToArray(), privateKey, "Cloud@2022");
                        var fileStream = Convert.ToBase64String(decrypted);
                        //var fileStream = Convert.ToBase64String(memoryStream.ToArray());
                        var newFile = new FileResponse() { fileName = file.Name, fileBase64 = fileStream, LastModified = file.LastModified.ToString("dd/MM/yyyy HH:mm:ss") };
                        fileResponse.Add(newFile);
                        result.Files = fileResponse;
                    }
                    response.Close();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion
        
        #region Delete File
        [HttpDelete("DeleteFile.{format}"), FormatFilter]
        public IActionResult DeleteFile(string fileName)
        {
            try
            {
                DeleteFileResponse result = new DeleteFileResponse();
                //Create an FtpWebRequest
                var request = (FtpWebRequest)WebRequest.Create(_dbOption.FtpAddress + "/out/" + fileName);
                //Set the method to UploadFile 
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                //Set the NetworkCredentials
                request.Credentials = new NetworkCredential(_dbOption.UserName, _dbOption.Password);
                request.UseBinary = true;
                request.UsePassive = true;
                request.Timeout = Timeout.Infinite;
                request.KeepAlive = false;
                request.EnableSsl = true;

                var response = (FtpWebResponse)request.GetResponse();
                result.Status = response.StatusCode == FtpStatusCode.FileActionOK ? "S" : "E";
                result.Message = response.StatusCode == FtpStatusCode.FileActionOK ? "Delete Successfully" : "File Not Delete Successfully";
                response.Close();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }

        }
        #endregion

        #region Heleper_Method
        private List<string> GetFtpData()
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(_dbOption.FtpAddress + "//out/");
            ftpRequest.Credentials = new NetworkCredential(_dbOption.UserName, _dbOption.Password);
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            ftpRequest.UseBinary = true;
            ftpRequest.UsePassive = true;
            ftpRequest.Timeout = Timeout.Infinite;
            ftpRequest.KeepAlive = false;
            ftpRequest.EnableSsl = true;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            List<string> directories = new List<string>();

            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                directories.Add(line);
                line = streamReader.ReadLine();
            }

            streamReader.Close();
            response.Close();

            return directories;
        }
        private List<FTPItem> RetrieveDirectoryListingsFromFTP(string startingPath = null)
        {
            List<FTPItem> results = new List<FTPItem>();
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(_dbOption.FtpAddress + "//out/");
            ftpRequest.Credentials = new NetworkCredential(_dbOption.UserName, _dbOption.Password);
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            ftpRequest.UseBinary = true;
            ftpRequest.UsePassive = true;
            ftpRequest.Proxy = null;
            ftpRequest.Timeout = Timeout.Infinite;
            ftpRequest.KeepAlive = false;
            ftpRequest.EnableSsl = true;

            string pattern = @"^([\w-]+)\s+(\d+)\s+(\w+)\s+(\w+)\s+(\d+)\s+" + @"(\w+\s+\d+\s+\d+|\w+\s+\d+\s+\d+:\d+)\s+(.+)$";
            Regex regex = new Regex(pattern);
            IFormatProvider culture = CultureInfo.GetCultureInfo("en-us");
            string[] hourMinFormats = new[] { "MMM dd HH:mm", "MMM dd H:mm", "MMM d HH:mm", "MMM d H:mm" };
            string[] yearFormats = new[] { "MMM dd yyyy", "MMM d yyyy" };
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Match match = regex.Match(line);
                            //string permissions = match.Groups[1].Value;
                            //int inode = int.Parse(match.Groups[2].Value, culture);
                            //string owner = match.Groups[3].Value;
                            //string group = match.Groups[4].Value;
                            //long size = long.Parse(match.Groups[5].Value, culture);
                            string s = Regex.Replace(match.Groups[6].Value, @"\s+", " ");
                            string[] formats = (s.IndexOf(':') >= 0) ? hourMinFormats : yearFormats;
                            var modified = DateTime.ParseExact(s, formats, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
                            string name = match.Groups[7].Value;
                            FTPItem item = new FTPItem
                            {
                                //Permissions = match.Groups[1].Value,
                                //Size = int.Parse(match.Groups[5].Value, culture),
                                LastModified = DateTime.ParseExact(s, formats, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal),
                                Name = match.Groups[7].Value,
                                //FullPath = $"{ftpRequest.RequestUri}/{match.Groups[8].Value.Replace(" ", "%20")}",
                            };
                            if (match.Groups[1].Value == "d")
                            {
                                FTPDirectory dir = new FTPDirectory(item);
                                dir.SubItems = new Lazy<List<FTPItem>>(() => RetrieveDirectoryListingsFromFTP(dir.FullPath));
                                results.Add(dir);
                            }
                            else
                            {
                                FTPFile file = new FTPFile(item);
                                results.Add(file);
                            }
                        }
                    }
                }
            response.Close();

            return results;
        }
        #endregion

        #region Return Exception
        private IActionResult ReturnException(Exception ex)
        {
            HttpContext.Response.ContentType = "application/json";
            HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return StatusCode(HttpContext.Response.StatusCode, JsonConvert.SerializeObject(new
            {
                error = new
                {
                    message = (ex.Message),
                    exception = ex.GetType().Name
                }
            }));
        }
        #endregion
    }
}