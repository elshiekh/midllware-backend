using System.Collections.Generic;

namespace elevatus_out.Position
{

    #region New-Position

    public class GetPositionRequest {
        public string system_branch_id { get; set; }
    }

    public class PositionRequest
    {
        public string system_id { get; set; }
        public int system_branch_id { get; set; }
        public bool system_position_status { get; set; }
        public string system_project_id { get; set; }
        public bool system_project_status { get; set; }
        public string system_position_title_id { get; set; }
        public bool system_position_title_status { get; set; }
        public string system_sequence_number { get; set; }
        public string system_job_id { get; set; }
        public string system_organization_id { get; set; }
        public string system_position_type { get; set; }
        public string system_exchanged_position_ar { get; set; }
        public string system_exchanged_position_en { get; set; }
        public string system_mrf_number { get; set; }
        public string system_fte { get; set; }
        public string system_permanent_seasonal_flag { get; set; }
    }
    public class DeletePositionRequest
    {
        public List<string> system_id { get; set; }
    }
    // Response --------
    public class NewPositionResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountPosition IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class UpdatePositionResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountPosition IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class DeletePositionResponse {
        public IdentifierDeleteResponse Identifiers { get; set; }
    }
    #endregion

    #region GET-Position-RESPONSE

    //public class GetPositionRequest
    //{
    //}
    public class GetPositionResponse {
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

    public class IntegrateAccountPosition
    {
        public ExtraData ExtraData { get; set; }
    }
    public class ExtraData
    {
        public int SystemId { get; set; }
        public int SystemBranchId { get; set; }
        public string systemProjectId { get; set; }
        public bool systemProjectStatus { get; set; }
        public string systemOrganizationId { get; set; }
        public string systemJobId { get; set; }
        public string systemPositionTitleId { get; set; }
        public bool systemPositionTitleStatus { get; set; }
        public string systemPositionType { get; set; }
        public bool systemPositionStatus { get; set; }
        public string systemSequenceNumber { get; set; }
        public bool CanDelete { get; set; }
    }
    public class Reason
    {
        public string Filed { get; set; }
        public string Type { get; set; }
        public string error { get; set; }
    }

    public class Parent { }

    public class CreateResponsePosition
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }

    public class UpdateResponsePosition
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }

    public class DeleteResponsePosition
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }
    #endregion

    public class NumberOfRequisitionRequest {
        public string  system_id { get; set; }
        
    }
    public class NumberOfRequisitionResponse {
        public Identifiers Identifiers { get; set; }
        public NORIntegrateAccount IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class NORIntegrateAccount {
        public NORExtraData ExtraData { get; set; }
    }

    public class NORExtraData
    {
        public string SystemId { get; set; }
        public string SystemBranchId { get; set; }
        public int NumberOfRequisition { get; set; }
    }

    public class ResponseOfNumberRequisition
    {
        public string SystemId { get; set; }
        public string SystemBranchId { get; set; }
        public int NumberOfRequisition { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }
}
