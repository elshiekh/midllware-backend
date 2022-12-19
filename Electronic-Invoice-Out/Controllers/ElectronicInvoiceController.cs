using Electronic_Invoice_Out.Branch;
using Electronic_Invoice_Out.DTO;
using Electronic_Invoice_Out.Extenstion;
using Electronic_Invoice_Out.Helper;
using Electronic_Invoice_Out.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_Invoice_Out.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class EInvoiceController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public readonly IInvoiceService _invoiceService;
        private readonly ILogger<EInvoiceController> _logger;
        public EInvoiceController(DBOption dbOption, IInvoiceService invoiceService, ILogger<EInvoiceController> logger)
        {
            _dbOption = dbOption;
            _logger = logger;
            _invoiceService = invoiceService;
        }
        #endregion

        #region ComplianceCSID
        [AllowAnonymous]
        [HttpPost("Compliance-CSID.{format}"), FormatFilter]
        public async Task<IActionResult> ComplianceCSID([FromBody] CsrRequest obj, string otp, string acceptVersion)
        {
            try
            {
                var result = new CsrResponse();
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

                    if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var internalServalErrorResult = JsonConvert.DeserializeObject<InternalServerErrorModel>(stringData);
                        return StatusCode(500, internalServalErrorResult);
                    }
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var badRequestErrorResult = JsonConvert.DeserializeObject<BadRequestErrorModel>(stringData);
                        return BadRequest(badRequestErrorResult);
                    }
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        var unauthResult = JsonConvert.DeserializeObject<UnauthorizedModel>(stringData);
                        return Unauthorized(unauthResult);
                    }

                    result = JsonConvert.DeserializeObject<CsrResponse>(stringData);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Compliance Invoice
        [DisableRequestSizeLimit]
        [HttpPost("ComplianceInvoice.{format}"), FormatFilter]
        public async Task<IActionResult> ComplianceInvoice([FromBody] InvoiceRequest obj, [FromQuery] ComplianceInvoiceQuery parmas)
        {
            try
            {
                var result = new ComplianceInvoiceResult();
                var errorresult = new ErrorModel();
                var username = ""; var password = "";
                SetComplianceAuthentication(parmas, ref username, ref password);
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(username + ":" + password);
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "compliance/invoices");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var c = parmas.Company.ToString();
                    request.Headers.Add("Accept-Language", parmas.Language);
                    request.Headers.Add("Accept-Version", parmas.Version);
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var internalServalErrorResult = JsonConvert.DeserializeObject<InternalServerErrorModel>(stringData);
                        return StatusCode(500, internalServalErrorResult);
                    }
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var badRequestErrorResult = JsonConvert.DeserializeObject<ComplianceInvoiceResult>(stringData);
                        return BadRequest(badRequestErrorResult);
                    }
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        var unauthResult = JsonConvert.DeserializeObject<UnauthorizedModel>(stringData);
                        return Unauthorized(unauthResult);
                    }
                    else
                    {
                        result = JsonConvert.DeserializeObject<ComplianceInvoiceResult>(stringData);
                        return Ok(result);
                    }
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Reporting 
        [HttpPost("Reporting.{format}"), FormatFilter]
        public async Task<IActionResult> Reporting([FromBody] InvoiceRequest obj, [FromQuery] InvoiceQuery parmas)
        {
            try
            {
                var result = new ReportingResult();
                var errorresult = new ErrorModel();
                var username = ""; var password = "";
                SetAuthentication(parmas, ref username, ref password);
                HttpClientHandler httpClientHandler = new HttpClientHandler()
                {
                    Credentials = new NetworkCredential(username, password)
                };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(username + ":" + password);
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "/invoices/reporting/single");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    request.Headers.Add("accept-language", parmas.AcceptLanguage);
                    request.Headers.Add("Clearance-Status", parmas.ClearanceStatus);
                    request.Headers.Add("Accept-Version", parmas.AcceptVersion);

                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.Accepted)
                    {
                        var acceptedResult = JsonConvert.DeserializeObject<ReportingResult>(stringData);
                        return StatusCode((int)HttpStatusCode.Accepted, acceptedResult);
                    }
                    if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var internalServalErrorResult = JsonConvert.DeserializeObject<InternalServerErrorModel>(stringData);
                        return StatusCode((int)HttpStatusCode.InternalServerError, internalServalErrorResult);
                    }
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var badRequestErrorResult = JsonConvert.DeserializeObject<ReportingResult>(stringData);
                        return BadRequest(badRequestErrorResult);
                    }
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        var unauthResult = JsonConvert.DeserializeObject<UnauthorizedModel>(stringData);
                        return Unauthorized(unauthResult);
                    }
                    else
                    {
                        result = JsonConvert.DeserializeObject<ReportingResult>(stringData);
                        result.QR = ExtensionMethods.GetQR(obj.invoice);
                        return Ok(result);
                    }
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Clearance
        [HttpPost("Clearance.{format}"), FormatFilter]
        public async Task<IActionResult> Clearance([FromBody] InvoiceRequest obj, [FromQuery] InvoiceQuery parmas)
        {
            try
            {
                var result = new ClearanceResult();
                var errorresult = new ErrorModel();
                var username = ""; var password = "";
                SetAuthentication(parmas, ref username, ref password);
                HttpClientHandler httpClientHandler = new HttpClientHandler()
                {
                    Credentials = new NetworkCredential(username, password)
                };
                using (var client = new HttpClient(httpClientHandler))
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(username + ":" + password);
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "/invoices/clearance/single");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    request.Headers.Add("Accept-Language", parmas.AcceptLanguage);
                    request.Headers.Add("Clearance-Status", parmas.ClearanceStatus);
                    request.Headers.Add("Accept-Version", parmas.AcceptVersion);
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.Accepted)
                    {
                        var acceptedResult = JsonConvert.DeserializeObject<ClearanceResult>(stringData);
                        return StatusCode((int)HttpStatusCode.Accepted, acceptedResult);
                    }
                    if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var internalServalErrorResult = JsonConvert.DeserializeObject<InternalServerErrorModel>(stringData);
                        return StatusCode((int)HttpStatusCode.InternalServerError, internalServalErrorResult);
                    }
                    if (response.StatusCode == HttpStatusCode.RedirectMethod)
                    {
                        var infoErrorResult = JsonConvert.DeserializeObject<InfoModel>(stringData);
                        return StatusCode((int)HttpStatusCode.RedirectMethod, infoErrorResult);
                    }
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var badRequestErrorResult = JsonConvert.DeserializeObject<ClearanceResult>(stringData);
                        return BadRequest(badRequestErrorResult);
                    }
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        var unauthResult = JsonConvert.DeserializeObject<UnauthorizedModel>(stringData);
                        return Unauthorized(unauthResult);
                    }
                    else
                    {
                        result = JsonConvert.DeserializeObject<ClearanceResult>(stringData);
                        result.QR = ExtensionMethods.GetQR(result.clearedInvoice);
                        return Ok(result);
                    }
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region ProductionCSID-Onboarding
        [HttpPost("ProductionCSID-Onboarding.{format}"), FormatFilter]
        public async Task<IActionResult> ProductionCSIDOnboarding([FromBody] ProductionCSIDRequest obj, string version)
        {
            try
            {
                var result = new ProductionCSIDResponse();
                var errorresult = new ErrorModel();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.HMGUserName + ":" + _dbOption.HMGPassword);
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "/production/csids");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    request.Headers.Add("Accept-Version", version);
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var internalServalErrorResult = JsonConvert.DeserializeObject<InternalServerErrorModel>(stringData);
                        return Ok(internalServalErrorResult);
                    }
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var badRequestErrorResult = JsonConvert.DeserializeObject<BadRequestErrorModel>(stringData);
                        return BadRequest(badRequestErrorResult);
                    }
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        var unauthResult = JsonConvert.DeserializeObject<UnauthorizedModel>(stringData);
                        return Unauthorized(unauthResult);
                    }

                    result = JsonConvert.DeserializeObject<ProductionCSIDResponse>(stringData);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region ProductionCSID-Renewal 
        [HttpPost("ProductionCSID-Renewal.{format}"), FormatFilter]
        public async Task<IActionResult> ProductionCSIDRenewal([FromBody] ProductionCSIDRenewalRequest obj, string acceptLanguage, string acceptVersion, string otp)
        {
            try
            {
                var result = new InvoiceResultModel();
                var errorresult = new ErrorModel();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.HMGUserName + ":" + _dbOption.HMGPassword);
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "/production/csids");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    request.Headers.Add("OTP", otp);
                    request.Headers.Add("Accept-Language", acceptLanguage);
                    request.Headers.Add("Accept-Version", acceptVersion);

                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var internalServalErrorResult = JsonConvert.DeserializeObject<InternalServerErrorModel>(stringData);
                        return Ok(internalServalErrorResult);
                    }
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var badRequestErrorResult = JsonConvert.DeserializeObject<BadRequestErrorModel>(stringData);
                        return BadRequest(badRequestErrorResult);
                    }
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        var unauthResult = JsonConvert.DeserializeObject<UnauthorizedModel>(stringData);
                        return Unauthorized(unauthResult);
                    }
                    result = JsonConvert.DeserializeObject<InvoiceResultModel>(stringData);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region GenerateXML 
        [HttpPost("GenerateXML.{format}"), FormatFilter]
        public IActionResult GenerateXML([FromBody] InvoiceModel model , [FromQuery] Company Company)
        {
            try
            {
                var result = _invoiceService.GenerateXML(model,Company);
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
        private void SetComplianceAuthentication(ComplianceInvoiceQuery parmas, ref string username, ref string password)
        {
            if (parmas.Company.ToString() == ExtensionMethods.GetEnumDescription(Company.HMG)) { username = _dbOption.HMGUserName; password = _dbOption.HMGPassword; }
            if (parmas.Company.ToString() == ExtensionMethods.GetEnumDescription(Company.FM)) { username = _dbOption.FMUserName; password = _dbOption.FMPassword; }
            if (parmas.Company.ToString() == ExtensionMethods.GetEnumDescription(Company.CS)) { username = _dbOption.CSUserName; password = _dbOption.CSPassword; }
            if (parmas.Company.ToString() == ExtensionMethods.GetEnumDescription(Company.TASW)) { username = _dbOption.TASWUserName; password = _dbOption.TASWPassword;}
        }
        private void SetAuthentication(InvoiceQuery parmas, ref string username, ref string password)
        {
            if (parmas.Company.ToString() == ExtensionMethods.GetEnumDescription(Company.HMG)) { username = _dbOption.PCSID_HMGUserName; password = _dbOption.PCSID_HMGPassword; }
            if (parmas.Company.ToString() == ExtensionMethods.GetEnumDescription(Company.FM)) { username = _dbOption.PCSID_FMUserName; password = _dbOption.PCSID_FMPassword; }
            if (parmas.Company.ToString() == ExtensionMethods.GetEnumDescription(Company.CS)) { username = _dbOption.PCSID_CSUserName; password = _dbOption.PCSID_CSPassword; }
            if (parmas.Company.ToString() == ExtensionMethods.GetEnumDescription(Company.TASW)) { username = _dbOption.PCSID_TASWUserName; password = _dbOption.PCSID_TASWPassword; }
        }
        #endregion
    }
}