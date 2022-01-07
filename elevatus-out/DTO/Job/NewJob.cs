using System.Collections.Generic;

namespace elevatus_out.Job
{

    #region New-Job
    public class JobRequest
    {
        public string system_id { get; set; }
        public int system_branch_id { get; set; }
        public bool system_job_status { get; set; }
        public string system_job_category_id { get; set; }
        public bool system_job_category_status { get; set; }
        public string system_job_title_id { get; set; }
        public bool system_job_title_status { get; set; }
    }
    public class DeleteJobRequest
    {
        public List<string> system_id { get; set; }
    }
    // Response --------
    public class NewJobResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountJob IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class UpdateJobResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountJob IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class DeleteJobResponse {
        public IdentifierDeleteResponse Identifiers { get; set; }
    }
    #endregion

    #region GET-Job-RESPONSE

    public class GetJobRequest
    {
    }
    public class GetJobResponse {
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

    public class IntegrateAccountJob
    {
        public ExtraData ExtraData { get; set; }
    }
    public class ExtraData
    {
        public int SystemId { get; set; }
        public int SystemBranchId { get; set; }
        public string systemJobTitleId { get; set; }
        public bool systemJobTitleStatus { get; set; }
        public string systemJobCategoryId { get; set; }
        public bool systemJobCategoryStatus { get; set; }
        public bool systemJobStatus { get; set; }
        public bool CanDelete { get; set; }
    }
    public class Reason
    {
        public string Filed { get; set; }
        public string Type { get; set; }
        public string error { get; set; }
    }

    public class Parent {}
  
    public class CreateResponseJob
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
    }

    public class UpdateResponseJob
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
    }

    public class DeleteResponseJob
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
    }
    #endregion
}
