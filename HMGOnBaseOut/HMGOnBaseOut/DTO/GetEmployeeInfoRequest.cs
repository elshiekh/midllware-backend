using System;
using System.Collections.Generic;

namespace HMGOnBaseOut.DTO
{
    public class GetEmployeeInfoResquest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_EMPLOYEE_INFO";
        }
        public List<GetEmployeeInfoResponse> response { get; set; }
    }
    public class GetEmployeeInfoResponse
    {
        public string EMPLOYEE_NUMBER { get; set; }
        public string FULL_NAME { get; set; }
        public string PAYROLL_NAME { get; set; }
    }

    public class GetAPEmployeeInfoResquest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_AP_EMPLOYEE_INFO";
        }
        public List<GetEmployeeInfoResponse> response { get; set; }
    }
    public class GetAPEmployeeInfoResponse
    {
        public string EMPLOYEE_NUMBER { get; set; }
        public string FULL_NAME { get; set; }
        public string PAYROLL_NAME { get; set; }
    }


    public class GetPOEmployeeInfoResquest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_PO_EMPLOYEE_INFO";
        }
        public GetEmployeeInfoResponse response { get; set; }
    }
    public class GetPOEmployeeInfoResponse
    {
        public string EMPLOYEE_NUMBER { get; set; }
        public string FULL_NAME { get; set; }
        public string PAYROLL_NAME { get; set; }
        public string ORGANIZATION_NAME { get; set; }
        public DateTime HIRE_DATE { get; set; }
        public string SUPERVISORE_NUMBER { get; set; }
        public string SUPERVISOR_NAME { get; set; }
    }

    public class GetHrEmployeeInfoResquest {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_EMPLOYEE_DETAILS";
        }
        public GetHrEmployeeInfoResponse response { get; set; }
    }
    public class GetHrEmployeeInfoResponse {
        public string EMPLOYEE_NUMBER { get; set; }
        public string ASSIGNMENT_NUMBER { get; set; }
        public string FULL_NAME { get; set; }
        public string PAYROLL_NAME { get; set; }
        public string EMPLOYER { get; set; }
        public string JOB_FAMILY { get; set; }
        public string JOB_TITLE { get; set; }
        public string POSITION_TITLE { get; set; }
        public string EMPLOYMENT_CATEGORY { get; set; }
        public DateTime HIRE_DATE { get; set; }
        public string NATIONALITY { get; set; }
        public string EMPLOYEE_ORGANIZATION { get; set; }
        public string SUPERVISOR_NUMBER { get; set; }
        public string SUPERVISOR_NAME { get; set; }
        //public string  POSITION_GROUP { get; set; }
    }
}
