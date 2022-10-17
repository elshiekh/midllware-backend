using System.Collections.Generic;

namespace elevatus_out.Hierarchy
{

    #region New-Hierarchy
    public class HierarchyRequest
    {
        public int system_branch_id { get; set; }
        public string system_id { get; set; }
        public string system_level_id { get; set; }
        public string system_name_en { get; set; }
        public string system_hr_name_en { get; set; }
        public string system_name_ar { get; set; }
        public string system_hr_name_ar { get; set; }
        public bool system_status { get; set; }
        public int? system_parent_id { get; set; }
        public string system_organization_group_id { get; set; }
    }
    public class DeleteHierarchyRequest
    {
        public int system_branch_id { get; set; }
        public List<int> system_id { get; set; }
    }
    // Response --------
    public class NewHierarchyResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountHierarchy IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class UpdateHierarchyResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountHierarchy IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class DeleteHierarchyResponse
    {
        public IdentifierDeleteResponse Identifiers { get; set; }
    }
    #endregion

    #region GET-Hierarchy-RESPONSE
    public class GetHierarchyRequest
    {
        public string system_branch_id { get; set; }
    }
    public class GetHierarchyResponse
    {
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
    public class IntegrateAccount
    {
        public List<ExtraData> ExtraData { get; set; }
    }

    public class IntegrateAccountHierarchy
    {
        public ExtraData ExtraData { get; set; }
    }
    public class ExtraData
    {
        public string SystemBranchId { get; set; }
        public string SystemLevelId { get; set; }
        public int SystemId { get; set; }
        public string SystemNameEn { get; set; }
        public string SystemHrNameEn { get; set; }
        public string SystemNameAr { get; set; }
        public string SystemHrNameAr { get; set; }
        public bool SystemStatus { get; set; }
        public bool CanDelete { get; set; }
        //public object [] Parent { get; set; }
    }
    public class Reason
    {
        public string Filed { get; set; }
        public string Type { get; set; }
        public string error { get; set; }
    }

    public class Parent { }

    public class TranslateHierarchy
    {
        public TranslateHierarchyArabic ar { get; set; }
        public TranslateHierarchyEnglish en { get; set; }
    }

    public class TranslateHierarchyArabic
    {
        public string system_name { get; set; }
    }

    public class TranslateHierarchyEnglish
    {
        public string system_name { get; set; }
    }

    public class CreateResponseHierarchy
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }

    public class UpdateResponseHierarchy
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }

    public class DeleteResponseHierarchy
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }
    #endregion
}
