using System.Collections.Generic;

namespace Electronic_Invoice_Out.Branch
{

    #region Compliance
    public class CSRRequest
    {
        public string csr { get; set; }
    }

    public class CSRResponse
    {
        public string requestID { get; set; }
        public string dispositionMessage { get; set; }
        public string binarySecurityToken { get; set; }
        public string secret { get; set; }
        public List<ErrorModel> errors { get; set; }
    }
    #endregion

    public class InvoiceRequest {
        public string invoiceHash { get; set; }
        public string invoice { get; set; }
  
    }
    public class InvoiceResultModel {
        public string invoiceHash { get; set; }
        public string status { get; set; }
        public List<WarningModel> warnings { get; set; }
        public List<ErrorModel> errors { get; set; }
    }
  public class ErrorModel
    {
        public string category { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class WarningModel
    {
        public string category { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
    public class InfoModel
    {
        public string message { get; set; }
    }
}
