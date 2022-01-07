using System.Collections.Generic;

namespace elevatus_out.Payroll
{

    #region New-Payroll
    public class PayrollRequest
    {
        public string system_id { get; set; }
        public string system_name_en { get; set; }
        public string system_name_ar { get; set; }
        public bool system_status { get; set; }
    }
    public class DeletePayrollRequest
    {
        public List<string> system_id { get; set; }
    }
    // Response --------
    public class NewPayrollResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountPayroll IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class UpdatePayrollResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountPayroll IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class DeletePayrollResponse {
        public IdentifierDeleteResponse Identifiers { get; set; }
    }
    #endregion

    #region GET-Payroll-RESPONSE

    public class GetPayrollRequest
    {
    }
    public class GetPayrollResponse {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccount IntegrateAccount { get; set; }
    }
    public class Identifiers
    {
        public string RequestId { get; set; }
        public string ApplicationId { get; set; }
        public string Status { get; set; }
        public string StatusCode { get; set; }
        public Paginate Paginate { get; set; }
    }

    public class IdentifierDeleteResponse
    {
        public string RequestId { get; set; }
        public string ApplicationId { get; set; }
        public List<IdentifierDeleteResponseAction> Action { get; set; }
        public string Status { get; set; }
        public string StatusCode { get; set; }
    }
    public class IdentifierDeleteResponseAction
    {
        public string System_Id { get; set; }
        public string Status { get; set; }
    }
    public class Paginate
    {
        public string Page { get; set; }
        public string Limit { get; set; }
        public string Total { get; set; }
    }
    public class IntegrateAccount {
        public List<ExtraData> ExtraData { get; set; }
    }

    public class IntegrateAccountPayroll
    {
        public ExtraData ExtraData { get; set; }
    }
    public class ExtraData
    {
        public string SystemId { get; set; }
        public string SystemNameEn { get; set; }
        public string SystemNameAr { get; set; }
        public bool SystemStatus { get; set; }
        public bool CanDelete { get; set; }
    }
    public class Reason
    {
        public string Filed { get; set; }
        public string Type { get; set; }
        public string error { get; set; }
    }

    public class Parent {}
  
    public class CreateResponsePayroll
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
    }

    public class UpdateResponsePayroll
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
    }

    public class DeleteResponsePayroll
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
    }
    #endregion
}
