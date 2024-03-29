﻿using Electronic_Invoice_Out.Branch;
using Electronic_Invoice_Out.Service;
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
using UblLarsen.Ubl2;
using UblLarsen.Ubl2.Cac;
using UblLarsen.Ubl2.Udt;

namespace Electronic_Invoice_Out.Controllers
{

    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class ElectronicInvoiceController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        private IHostingEnvironment _env;
        public readonly IInvoiceService _invoiceService;
        public ElectronicInvoiceController(DBOption dbOption, IHostingEnvironment env , IInvoiceService invoiceService)
        {
            _dbOption = dbOption;
            _env = env;
            _invoiceService = invoiceService;
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
        [HttpPost("ValidateEInvoiceHashing")]
        public IActionResult ValidateEInvoiceHashing()
        {
            try
            {
                var webRoot = _env.WebRootPath;
                var xmlFilePath = System.IO.Path.Combine(webRoot, @"XMLFile\simplified_invoice_signed.xml");
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
        [HttpPost("GenerateEInvoiceQRCode")]
        public IActionResult GenerateEInvoiceQRCode()
        {
            try
            {
                var webRoot = _env.WebRootPath;
                var xmlFilePath = System.IO.Path.Combine(webRoot, @"XMLFile\simplified_invoice_signed.xml");
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
        [HttpPost("ValidateEInvoiceQRCode")]
        public IActionResult ValidateEInvoiceQRCode()
        {
            try
            {
                var webRoot = _env.WebRootPath;
                var xmlFilePath = System.IO.Path.Combine(webRoot, @"XMLFile\simplified_invoice_signed.xml");
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
        [HttpPost("ValidateEInvoice")]
        public IActionResult ValidateEInvoice()
        {
            try
            {
                var webRoot = _env.WebRootPath;
                var xmlFilePath = System.IO.Path.Combine(webRoot, @"XMLFile\simplified_invoice_signed.xml");
                var certificateContent = System.IO.Path.Combine(webRoot, @"XMLFile\cert.pem");
                var pihContent = System.IO.Path.Combine(webRoot, @"XMLFile\pih.txt");
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
        [HttpPost("SignDocument")]
        public IActionResult SignDocument()
        {
            try
            {
                var webRoot = _env.WebRootPath;
                var xmlFilePath = System.IO.Path.Combine(webRoot, @"XMLFile\simplified_invoice_signed.xml");
                var certificateContent = System.IO.Path.Combine(webRoot, @"XMLFile\cert.pem");
                var privateKeyContent = System.IO.Path.Combine(webRoot, @"XMLFile\ec-secp256k1-priv-key.pem");
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

        #region GenerateXML 
        [HttpPost("GenerateXML")]
        public IActionResult GenerateXML([FromBody] Object req )
        {
            try
            {
                Func<decimal, AmountType> newAmountType = v => new AmountType { Value = v, currencyID = "SAR" };
                var taxVAT = new TaxSchemeType { ID = "VAT" };

                var obj = new InvoiceType() ;
               var result = _invoiceService.GenerateXML(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion 

        #region Clearance Invoice
        [HttpPost("ClearanceInvoice.{format}"), FormatFilter]
        public async Task<IActionResult> ClearanceInvoice([FromBody] InvoiceRequest obj, string acceptLanguage, string clearanceStatus )
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
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "/invoices/clearance/single");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    request.Headers.Add("Accept-Language", acceptLanguage);
                    request.Headers.Add("Clearance-Status", clearanceStatus);
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

        //Clearance 
        #endregion

        #region Reporting Invoice 
        [HttpPost("ReportingInvoice.{format}"), FormatFilter]
        public async Task<IActionResult> ReportingInvoice([FromBody] InvoiceRequest obj, string acceptLanguage, string clearanceStatus)
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
                    var request = new HttpRequestMessage(HttpMethod.Post, baseAddress + "/invoices/clearance/single");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    request.Headers.Add("Accept-Language", acceptLanguage);
                    request.Headers.Add("Clearance-Status", clearanceStatus);

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

        //Reporting 
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