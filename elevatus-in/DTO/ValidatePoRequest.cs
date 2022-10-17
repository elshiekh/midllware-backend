using System.Collections.Generic;

namespace elevatus_in.DTO
{
    public class ValidateLoginRequest
    {
        public string GetSPName()
        {
            return "HMG_ELEVATUS_INT_IN_PKG.VALIDATE_LOGIN";
        }
        public string P_USER_NAME { get; set; }
        public string P_LANGUAGE { get; set; }
        public string P_PASSWORD { get; set; }
    }

    public class ValidateLoginResponse
    {
        public string P_MOBILE_NUMBER { get; set; }
        public string P_EMAIL_ADDRESS { get; set; }
        public string P_PASSWORD_EXPIRED { get; set; }
        public string P_PASSWORD_EXPIRED_MSG { get; set; }
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MSG { get; set; }
    }

    public class ValidateOfferRequest
    {
        public string GetSPName()
        {
            return "HMG_ELEVATUS_INT_IN_PKG.VALIDATE_OFFER";
        }
        public RequestIdentifiers identifiers { get; set; }
        public List<Dictionary<string, string>> body { get; set; }
    }
    public class RequestIdentifiers
    {
        public string request_uuid { get; set; }
        public string branch_id { get; set; }
        public string position_id { get; set; }
        public string position_title_id { get; set; }
        public bool is_budgeted { get; set; }
        public string nationality_code { get; set; }
        public string language_code { get; set; }

    }

    public class BodyFiled
    {
        public List<Dictionary<string, string>> Body { get; set; }
    }

    public class OfferResponse
    {
        public ResponseIdentifiers identifiers { get; set; }
        public List<ResponseFiled> results { get; set; }
    }
    public class ValidateOfferResponse
    {
        public ResponseIdentifiers identifiers { get; set; }
        public List<ResponseFiled> results { get; set; }
        // public OfferResponse Result { get; set; }
        //public string ReturnStatus { get; set; }
        //public string ReturnMessage { get; set; }
    }

    public class ResponseIdentifiers
    {
        public string request_uuid { get; set; }
    }
    public class ResponseFiled
    {
        public string field { get; set; }
        public bool is_valid { get; set; }
        public string message { get; set; }
    }

    public class UpdateRequisitionRequest
    {
        public string GetSPName()
        {
            return "HMG_ELEVATUS_INT_IN_PKG. UPDATE_REQUISITION";
        }
        public int P_POSITION_ID { get; set; }
        public int P_NUM_OF_REQUISITION { get; set; }
    }
    public class UpdateRequisitionResponse
    {
        public decimal P_ORACLE_ID { get; set; }
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MSG { get; set; }
    }

    public class IsPositionVacantRequest
    {
        public string GetSPName()
        {
            return "HMG_ELEVATUS_INT_IN_PKG. IS_POSITION_VACANT";
        }
        public int P_POSITION_ID { get; set; }
    }
    public class IsPositionVacantResponse
    {
        public string P_VACANT_POSITION_FLAG { get; set; }
    }


    public class CreateSecurityRequest
    {
        public string GetSPName()
        {
            return "HMG_ELEVATUS_INT_IN_PKG.CREATE_SECURITY";
        }
        public List<Security> Security { get; set; }

    }

    public class CreateSecurityResponse
    {
        public string security_id { get; set; }
        public string oracle_id { get; set; }
        public bool return_status { get; set; }
        public string return_msg { get; set; }
    }

    public class Security
    {
        public int security_id { get; set; }
        public int person_id { get; set; }
        public string operand { get; set; }
        public int? job_catgeory_id { get; set; }
        public int branch_id { get; set; }
        public int? organization_id { get; set; }
        public string organization_group { get; set; }
        public int? hierarchy_id { get; set; }
        public int? position_title_id { get; set; }
    }

    public class DeleteSecurity
    {
        public int security_id { get; set; }
    }

    public class UpdateSecurityRequest
    {
        public string GetSPName()
        {
            return "HMG_ELEVATUS_INT_IN_PKG.UPDATE_SECURITY";
        }
        public List<Security> Security { get; set; }
    }
    public class DeleteSecurityRequest
    {
        public string GetSPName()
        {
            return "HMG_ELEVATUS_INT_IN_PKG.DELETE_SECURITY";
        }
        public List<DeleteSecurity> Security { get; set; }
    }


    public class CrudSecurityResponse
    {
        public string security_id { get; set; }
        public string oracle_id { get; set; }
        public bool return_status { get; set; }
        public string return_msg { get; set; }
    }
    public class SecurityResponse
    {
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MSG { get; set; }
    }


    public class CreateApplicantRequest
    {
        public string GetSPName()
        {
            return "HMG_ELEVATUS_INT_IN_PKG. CREATE_APPLICANT";
        }
        public P_APPLICANT_DETAILS P_APPLICANT_DETAILS { get; set; }
    }

    public class CreateApplicantResponce
    {
        public decimal P_ORACLE_ID { get; set; }
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MSG { get; set; }
    }

    public class P_APPLICANT_DETAILS
    {
        public Employee Employee { get; set; }
    }

    public class Employee
    {
        public int BUSINESS_GROUP_ID { get; set; }
        public string APPLICANT_NUMBER { get; set; }
        public string TITLE { get; set; }
        public string FIRST_NAME { get; set; }
        public string FATHER_NAME { get; set; }
        public string GRANDFATHER_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string FIRST_NAME_AR { get; set; }
        public string FATHER_NAME_AR { get; set; }
        public string GRANDFATHER_NAME_AR { get; set; }
        public string LAST_NAME_AR { get; set; }
        public string GENDER { get; set; }
        public string DATE_OF_BIRTH { get; set; }
        public string MARITAL_STATUS { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public string MOBILE_NUMBER { get; set; }
        public string BLOOD_TYPE { get; set; }
        public string NATIONALITY { get; set; }
        public string NATIONAL_IDENTIFIER { get; set; }
        public string EDUCATION_LEVEL { get; set; }
        public string HIRE_DATE { get; set; }
        public string ID_ISSUE_DATE { get; set; }

        public string EMER_CONTACT_PER { get; set; }
        public string EMER_CONTACT_PHONE { get; set; }
        public int DISABILITY_FLAG { get; set; }
        public int STUDENT_FLAG { get; set; }
        public int HRDF_FLAG { get; set; }
        public int RECRUITMENT_SOURCE { get; set; }
        public int RECRUITER_ID { get; set; }
        public int WORK_ASSIGNMENT_FORM { get; set; }

        public int POSITION_ID { get; set; }
        public string EMPLOYEMENT_CATEGORY { get; set; }
        public int SUPERVISOR_ID { get; set; }
        public int PROBATION_PERIOD { get; set; }

        public string PROBATION_UNIT { get; set; }
        public int NOTICE_PERIOD { get; set; }
        public string NOTICE_PERIOD_UOM { get; set; }
        public int PAY_BASIS_ID { get; set; }
        public int ANNUITIES { get; set; }

        public string ANNUITIES_JOINING_DATE { get; set; }
        public int HAZARDS { get; set; }
        public string HAZARDS_JOINING_DATE { get; set; }

        public int MOQEEM_STATUS { get; set; }
        public int BENEFIT_GROUP { get; set; }
        public int CONTRACT_MAT_STATUS { get; set; }
        public int TICKET_ROUTE { get; set; }
        public string DOC_QUALIFICATION { get; set; }

        public int GOSI_EMPLOYER { get; set; }
        public string GOSI_NUM { get; set; }
        public int HOUSING_TYPE { get; set; }
        public int TRANS_TYPE { get; set; }

        public int BASIC_SALARY { get; set; }
        public int HOUSING_ALLOWANCE { get; set; }
        public int COLA_ALLOWANCE { get; set; }
        public int FOOD_ALLOWANCE { get; set; }
        public int TELEPHONE_ALLOWANCE { get; set; }
        public int SUBSIDIARY_ALLOWANCE { get; set; }

        public int CRITICAL_ALLOWANCE { get; set; }
        public int OVERRIDE_CRITICAL_ALLOWANCE { get; set; }
        public int SPECIAL_ALLOWANCE { get; set; }

        public int OVERRIDE_SPECIAL_ALLOWANCE { get; set; }
        public int ADMIN_PROF_ALLOWANCE { get; set; }
        public int EXTRA_TASK_ALLOWANCE { get; set; }
        public int DR_PROFISSIONAL { get; set; }
        public int DR_MGI { get; set; }
        public int DR_SPECIALITY { get; set; }

        public string DR_SPECIALITY_DESC { get; set; }
        public int PROJECT_ALLOWANCE { get; set; }
        public int TRANS_ALLOWANCE { get; set; }
        public int OVERTIME { get; set; }

        public int EXP_ALLOWANCE { get; set; }
        public int OTHER_ALLOWANCE { get; set; }
        public int SUPERVISION_ALLOWANCE { get; set; }
        public int CHILD_ALLOWANCE { get; set; }
        public int FAMILY_COVERAGE_ALLOWANCE { get; set; }
        public int INPATIENT_ALLOWANCE { get; set; }
        public int PATIENT_CARE_ALLOWANCE { get; set; }
        public int RISK_ALLOWANCE { get; set; }

        public string RELIGION { get; set; }
        public string PASSPORT_NUMBER { get; set; }
        public string PASS_PROFESSION { get; set; }
        public string PAAS_ISSUE_DATE { get; set; }
        public string PASS_EXPIRY_DATE { get; set; }
        public string PASS_PLACE_OF_ISSUE { get; set; }
        public string RECRUITMENT_AGENCY { get; set; }

        public int TICKET_EXPENSE { get; set; }
        public int VISA_EXPENSE { get; set; }
        public int EMPLOYER_SHARE { get; set; }
        public int EMPLOYEE_SHARE { get; set; }
        public int NO_OF_INSTALLMENT { get; set; }

        public string TICKET_ENTITLEMENT { get; set; }
        public int ANNUAL_VAC_DAYS { get; set; }
        public string REC_RECOVERY_PERIOD { get; set; }
        public int CASH_ADVNACE_AMOUNT { get; set; }
        public string CASH_COMMENTS { get; set; }
        public string CASH_RECOVERY_PERIOD { get; set; }
    }

}
