using System.Collections.Generic;

namespace elevatus_out.Employee
{

    #region New-Employee
    public class EmployeeRequest
    {
        public string system_id { get; set; }
        public int system_branch_id { get; set; }
        public string system_category_id { get; set; }
        public string system_employee_number { get; set; }
        public string system_first_name { get; set; }
        public string system_second_name { get; set; }
        public string system_third_name { get; set; }
        public string system_last_name { get; set; }
        public string system_supervisor_id { get; set; }
        public string system_hod_person_id { get; set; }
        public string system_email_address { get; set; }
        public string system_civil_id { get; set; }
        public string system_mobile_number { get; set; }
        public string system_absence_rep_person_id { get; set; }
        public string system_term_rep_person_id { get; set; }
        public string system_absence_start_date { get; set; }
        public string system_absence_end_date { get; set; }
        public bool system_absence_status { get; set; }
        public string system_termination_date { get; set; }
        public bool system_status { get; set; }
        public string system_position_id { get; set; }

    }
    public class DeleteEmployeeRequest
    {
        public List<string> system_id { get; set; }
    }
    // Response --------
    public class NewEmployeeResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountEmployee IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class UpdateEmployeeResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountEmployee IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class DeleteEmployeeResponse
    {
        public IdentifierDeleteResponse Identifiers { get; set; }
    }
    #endregion

    #region GET-Employee-RESPONSE

    public class GetEmployeeRequest
    {
    }
    public class GetEmployeeResponse
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

    public class IntegrateAccountEmployee
    {
        public ExtraData ExtraData { get; set; }
    }
    public class ExtraData
    {
        public int SystemId { get; set; }
        public int SystemBranchId { get; set; }
        public string SystemEmployeeNumber { get; set; }
        public string SystemFullName { get; set; }
        public string SystemSupervisorId { get; set; }
        public string SystemHodPersonId { get; set; }
        public string SystemEmailAddress { get; set; }
        public string SystemMobileNumber { get; set; }
        public string SystemCivilId { get; set; }
        public string SystemOrganizationId { get; set; }
        public string SystemAbsenceRepPersonId { get; set; }
        public string SystemTeamRepPersonId { get; set; }
        public string SystemAbsenceStartDate { get; set; }
        public string SystemAbsenceEnDate { get; set; }
        public string SystemTerminationDate { get; set; }
        public bool SystemAbsenceStatus { get; set; }
        public bool SystemStatus { get; set; }
        public bool CanDelete { get; set; }
    }
    public class Reason
    {
        public string Filed { get; set; }
        public string Type { get; set; }
        public string error { get; set; }
    }

    public class Parent { }

    public class CreateResponseEmployee
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string  RequestId { get; set; }
    }

    public class ResponseEmployeeType
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }

    public class UpdateResponseEmployee
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }

    public class DeleteResponseEmployee
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }
    #endregion

    #region Employee Type 
    public class EmployeeTypeRequest
    {
        public int system_id { get; set; }
    }
    public class EmployeeTypeResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountEmployeeType IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class IntegrateAccountEmployeeType
    {
        public ExtraDataType ExtraData { get; set; }
    }
    public class ExtraDataType
    {
        public bool Type { get; set; }
    }
    #endregion

    #region Connect Employee Applicant 
    public class ConnectEmployeeApplicantRequest
    {
        public string system_id { get; set; }
        public string applicant_id { get; set; }
        public string status { get; set; }
        public string meesage { get; set; }
    }
    public class ConnectEmployeeApplicantErrorResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountConnectEmployeeApplicant IntegrateAccount { get; set; }
        public List<ConnectEmployeeApplicantReason> Reason { get; set; }
    }

    public class ConnectEmployeeApplicant_Response
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountConnectEmployeeApplicant IntegrateAccount { get; set; }
    }

    public class ConnectEmployeeApplicantReason
    {
        public string message { get; set; }
    }
    public class IntegrateAccountConnectEmployeeApplicant
    {
        public ExtraDataConnectEmployeeApplicant ExtraData { get; set; }
    }
    public class ExtraDataConnectEmployeeApplicant
    {
        public bool Type { get; set; }
    }

    public class ConnectResponseApplicantEmployee
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }
    #endregion

    #region Enable/Disable User 
    public class EmployeeEnableRequest
    {
        public string system_id { get; set; }
        public bool system_status { get; set; }
    }
    public class EmployeeEnableResponse
    {
        public Identifiers Identifiers { get; set; }
        public IntegrateAccountEmployeeEnable IntegrateAccount { get; set; }
        public List<Reason> Reason { get; set; }
    }
    public class EmployeeResponseEnable
    {
        public string SystemId { get; set; }
        public bool SystemStatus { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string Reasons { get; set; }
        public string RequestId { get; set; }
    }
    public class IntegrateAccountEmployeeEnable
    {
        public ExtraDataEnable ExtraData { get; set; }
    }
    public class ExtraDataEnable
    {
        public string SystemId { get; set; }
        public bool SystemStatus { get; set; }
    }
    #endregion
}
