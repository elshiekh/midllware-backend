using System.Collections.Generic;

namespace Electronic_Invoice_Out.Branch
{

    #region Compliance
    public class CsrRequest
    {
        public string csr { get; set; }
    }

    public class CsrResponse
    {
        public string requestID { get; set; }
        public string dispositionMessage { get; set; }
        public string binarySecurityToken { get; set; }
        public string secret { get; set; }
    }
    #endregion

    public class InvoiceRequest
    {
        public string invoiceHash { get; set; }
        public string uuid { get; set; }
        public string invoice { get; set; }

    }
    public class InvoiceResultModel
    {
        public string invoiceHash { get; set; }
        public string status { get; set; }
        public List<WarningModel> warnings { get; set; }
        public List<ErrorModel> errors { get; set; }
    }

    public class ComplianceInvoiceResult
    {
        public ValidationResults validationResults { get; set; }

        public string reportingStatus { get; set; }
        public string clearanceStatus { get; set; }
        public string qrSellertStatus { get; set; }
        public string qrBuyertStatus { get; set; }
    }

    public class ValidationResults
    {
        public List<ValidationInfoMessage> infoMessages { get; set; }
        public List<WarningModel> warningMessages { get; set; }
        public List<ErrorModel> errorMessages { get; set; }
        public string status { get; set; }
        // public ValidationInfoMessage infoMessages { get; set; }
    }

    public class ValidationInfoMessage
    {
        public string type { get; set; }
        public string code { get; set; }
        public string category { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }

    public class ProductionCSIDRequest
    {
        public string compliance_request_id { get; set; }
    }
    public class ProductionCSIDResponse
    {
        public string requestID { get; set; }
        public string tokenType { get; set; }
        public string dispositionMessage { get; set; }
        public string binarySecurityToken { get; set; }
        public string secret { get; set; }
        public List<WarningModel> warnings { get; set; }
        public List<ErrorModel> errors { get; set; }
    }

    public class ProductionCSIDRenewalRequest { public string csr { get; set; } }
    public class ProductionCSIDRenewalResponse
    {
        public string RequestID { get; set; }
        public string TokenType { get; set; }
        public string DispositionMessage { get; set; }
        public string BinarySecurityToken { get; set; }
        public string RequestedSecurityToken { get; set; }
        public string secret { get; set; }
    }

    public class ErrorModel
    {
        public string type { get; set; }
        public string code { get; set; }
        public string category { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }

    public class CSRErrorModel
    {
        public string code { get; set; }
        public string message { get; set; }
    }
    public class WarningModel
    {
        public string type { get; set; }
        public string code { get; set; }
        public string category { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }
    public class InfoModel
    {
        public string message { get; set; }
    }

    public class UnauthorizedModel
    {
        public string timestamp { get; set; }
        public string status { get; set; }
        public string error { get; set; }
        public string message { get; set; }
    }

    public class InternalServerErrorModel
    {
        public string code { get; set; }
        public string message { get; set; }
    }

    public class ReportingInternalServerErrorModel
    {
        public string category { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }

    public class BadRequestErrorModel
    {
        public List<CSRErrorModel> errors { get; set; }
    }
}
