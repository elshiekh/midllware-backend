using System.Collections.Generic;

namespace elevatus_out.Vacant
{

    #region New-Vacant
    public class VacantRequestObj
    {
        //public string system_id { get; set; }
        public string system_position_id { get; set; }
        public int system_branch_id { get; set; }
        public string system_overlap_start { get; set; }
        public string system_overlap_end_date { get; set; }
        public string system_number_ocp { get; set; }
        public string system_new_position { get; set; }
        public string system_number_ocpbfp { get; set; }
        public string system_number_ocpbft { get; set; }
        public string employee_person_id { get; set; }
    }
    public class VacantRequest
    {
        public string system_position_id { get; set; }
        public int system_branch_id { get; set; }
        public string system_overlap_start { get; set; }
        public string system_overlap_end_date { get; set; }
        public string system_number_ocp { get; set; }
        public string system_new_position { get; set; }
        public string system_number_ocpbfp { get; set; }
        public string system_number_ocpbft { get; set; }
        public string []  employee_person_id { get; set; }
    }
    public class DeleteVacantRequest
    {
        public List<string> system_id { get; set; }
    }
    // Response --------
    public class NewVacantResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountVacant IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class UpdateVacantResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountVacant IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class DeleteVacantResponse {
        public IdentifierDeleteResponse Identifiers { get; set; }
    }
    #endregion

    #region GET-Vacant-RESPONSE

    public class GetVacantRequest
    {
        public string system_branch_id { get; set; }
    }
    public class GetVacantResponse {
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

    public class IntegrateAccountVacant
    {
        public List<ExtraData> ExtraData { get; set; }
    }
    public class ExtraData
    {
        public int SystemPositionId { get; set; }
        public string SystemBranchId { get; set; }
        public string SystemOverlapStart { get; set; }
        public string SystemOverlapEndDate { get; set; }
        public string SystemNewPosition { get; set; }
        public string SystemNumberOcpbf { get; set; }
        public string SystemNoopbpt { get; set; }
        public string SystemObel { get; set; }
        public string SystemNumberOcp { get; set; }
        public bool CanDelete { get; set; }
    }
    public class Reason
    {
        public string Filed { get; set; }
        public string Type { get; set; }
        public string error { get; set; }
    }

    public class Parent {}
  
    public class CreateResponseVacant
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }

    public class UpdateResponseVacant
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }

    public class DeleteResponseVacant
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }
    #endregion
}
