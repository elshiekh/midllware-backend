using Electronic_Invoice_Out.Branch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SDKNETFrameWorkLib.BLL;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Electronic_Invoice_Out.Extenstion.QueryExtenstion;

namespace Electronic_Invoice_Out.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class ElectronicInvoiceController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        private IHostingEnvironment _env;
        public ElectronicInvoiceController(DBOption dbOption, IHostingEnvironment env)
        {
            _dbOption = dbOption;
            _env = env;
        }
        #endregion

        #region ComplianceCSID
        [HttpPost("Compliance-CSID.{format}"), FormatFilter]
        public async Task<IActionResult> ComplianceCSID([FromBody] CSRRequest obj, string otp, string acceptVersion)
        {
            try
            {
                var result = new CSRResponse();
                var errorresult = new ErrorModel();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "compliance");
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    request.Headers.Add("OTP", otp);
                    request.Headers.Add("Accept-Version", acceptVersion);
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        result = JsonConvert.DeserializeObject<CSRResponse>(stringData);
                        return Ok(result);
                    }
                    else if (response.StatusCode == HttpStatusCode.BadRequest) {
                        errorresult = JsonConvert.DeserializeObject<ErrorModel>(stringData);
                        return BadRequest(errorresult);
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Compliance Invoice
        [HttpPost("ComplianceInvoice.{format}"), FormatFilter]
        public async Task<IActionResult> ComplianceInvoice([FromBody] InvoiceRequest obj,string acceptLanguage, string acceptVersion)
        {
            try
            {
                var result = new InvoiceResultModel();
                var errorresult = new ErrorModel();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "compliance/invoices");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    request.Headers.Add("Accept-Language", acceptLanguage);
                    request.Headers.Add("Accept-Version", acceptVersion);
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        result = JsonConvert.DeserializeObject<InvoiceResultModel>(stringData);
                        return Ok(result);
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region GenerateEInvoiceHashing
        [HttpPost("GenerateEInvoiceHashing")]
        public IActionResult GenerateEInvoiceHashing()
        {
            try
            {
                var webRoot = _env.WebRootPath;
                var xmlFilePath = System.IO.Path.Combine(webRoot, @"XMLFile\simplified_invoice_signed.xml");
                HashingValidator obj = new HashingValidator();
                var result = obj.GenerateEInvoiceHashing(xmlFilePath);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region ValidateEInvoiceHashing
        [HttpPost("ValidateEInvoiceHashing.{format}"), FormatFilter]
        public IActionResult ValidateEInvoiceHashing(string xmlFilePath)
        {
            try
            {

                HashingValidator obj = new HashingValidator();
                var result = obj.ValidateEInvoiceHashing(xmlFilePath);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region GenerateEInvoiceQRCode
        [HttpPost("GenerateEInvoiceQRCode.{format}"), FormatFilter]
        public IActionResult GenerateEInvoiceQRCode(string xmlFilePath)
        {
            try
            {
                QRValidator obj = new QRValidator();
                var result = obj.GenerateEInvoiceQRCode(xmlFilePath);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region ValidateEInvoiceQRCode
        [HttpPost("ValidateEInvoiceQRCode.{format}"), FormatFilter]
        public IActionResult ValidateEInvoiceQRCode(string xmlFilePath)
        {
            try
            {
                QRValidator obj = new QRValidator();
                var result = obj.ValidateEInvoiceQRCode(xmlFilePath);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region ValidateEInvoice
        [HttpPost("ValidateEInvoice.{format}"), FormatFilter]
        public IActionResult ValidateEInvoice(string xmlFilePath, string certificateContent, string pihContent)
        {
            try
            {
                EInvoiceValidator obj = new EInvoiceValidator();
                var result = obj.ValidateEInvoice(xmlFilePath, certificateContent, pihContent);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region SignDocument
        [HttpPost("SignDocument.{format}"), FormatFilter]
        public IActionResult SignDocument(string xmlFilePath, string certificateContent, string privateKeyContent)
        {
            try
            {
                EInvoiceSigningLogic obj = new EInvoiceSigningLogic();
                var result = obj.SignDocument(xmlFilePath, certificateContent, privateKeyContent);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Return Exception
        private IActionResult ReturnException(Exception ex)
        {
            // HttpContext.Response.ContentType = "application/json";
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