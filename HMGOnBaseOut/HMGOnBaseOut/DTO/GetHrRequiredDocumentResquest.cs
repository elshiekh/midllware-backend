using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMGOnBaseOut.DTO
{
    public class GetHrRequiredDocumentResquest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_HR_REQUIRED_DOCUMENT";
        }
    }

    public class GetHrRequiredDocumentResponse
    {
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
        public DateTime TERMINATION_DATE { get; set; }
        public string NATIONALITY { get; set; }
        public string EMPLOYEE_ORGANIZATION { get; set; }
        public string REQUIRED_DOCUMENT { get; set; }
        public List<ROW> REQUIRED_DOCUMENTS { get; set; }
    }

    public class ROW
    {
        public string DOCUMENT_TYPE { get; set; }
    }
}
