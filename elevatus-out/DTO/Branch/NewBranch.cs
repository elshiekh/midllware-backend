using System.Collections.Generic;

namespace elevatus_out.Branch
{

    #region New-Branch
    public class BranchRequest
    {
        public string system_id { get; set; }
        public string system_payroll_id { get; set; }
        public string system_name_en { get; set; }
        public string system_name_ar { get; set; }
        public bool system_status { get; set; }
        public string system_business_group_id { get; set; }
    }

    public class Translate {
        public TranslateArabic ar { get; set; }
        public TranslateEnglish en { get; set; }
    }

    public class TranslateArabic
    {
        public string system_name { get; set; }
    }
    public class TranslateEnglish
    {
        public string system_name { get; set; }
    }

    public class DeleteBranchRequest
    {
        public List<string> system_id { get; set; }
    }
    // Response --------
    public class NewBranchResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountBranch IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class UpdateBranchResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountBranch IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class DeleteBranchResponse
    {
        public IdentifierDeleteResponse Identifiers { get; set; }
    }
    #endregion

    #region GET-BRANCH-RESPONSE
    public class GetBranchRequest { }
    public class GetBranchResponse {
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
    public class IdentifierDeleteResponseAction {
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

    public class IntegrateAccountBranch
    {
        public ExtraData ExtraData { get; set; }
    }
    public class ExtraData {
        public int SystemId { get; set; }
        public string SystemNameAr { get; set; }
        public string SystemNameEn { get; set; }
        public string SystemPayrollId { get; set; }
        public string SystemBusinessGroupId { get; set; }
        public bool SystemStatus { get; set; }
        public bool  CanDelete { get; set; }
    }
    public class Reason
    {
        public string Filed { get; set; }
        public string Type { get; set; }
        public string error { get; set; }
    }

    public class NewResponseBranch
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }

    public class UpdateResponseBranch
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }

    public class DeleteResponseBranch
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }

    #endregion
}
