using System;
using System.Collections.Generic;

namespace HMGOnBaseOut.DTO
{
    public class GetHrEmployeeDocumentsResquest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG. GET_EMPLOYEE_DOCUMENTS";
        }
    }

    public class GetHrEmployeeDocumentsResponse
    {
        public string EMPLOYEE_NUMBER { get; set; }
        public string FULL_NAME { get; set; }
        public string PAYROLL_NAME { get; set; }
        public string POSITION_TITLE { get; set; }
        public string JOB_CATEGORY { get; set; }
        public string NATIONALITY { get; set; }
        public DateTime HIRE_DATE { get; set; }
        public string EMPLOYEE_ORGANIZATION { get; set; }
        public List<ROW> EMPLOYEE_DOCUMENTS { get; set; }
    }

    public class CacheHrEmployeeDocumentRequest
    {
        public string GetKey()
        {
            return "GetHrEmployeeDocumentResponse";
        }
        public List<GetHrEmployeeDocumentsResponse> value { get; set; }
    }
}
