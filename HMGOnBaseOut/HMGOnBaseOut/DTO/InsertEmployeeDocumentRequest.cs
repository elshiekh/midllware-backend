using System;

namespace HMGOnBaseOut.DTO
{
    public class InsertEmployeeDocumentRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.INSERT_EMPLOYEE_DOCUMENT";
        }
        public int P_DOCUMENT_HANDLE { get; set; }
        public string P_EMPLOYEE_NUMBER { get; set; }
        public string P_DOCUMENT_TYPE_NAME { get; set; }
        public DateTime? P_EXPIRY_DATE { get; set; }
        public int? P_YEAR { get; set; }
    }

    public class InsertEmployeeDocumentResponse
    {
        public decimal P_ORACLE_ID { get; set; }
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MSG { get; set; }
    }

    public class DeleteEmployeeDocumentRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.DELETE_EMPLOYEE_DOCUMENT";
        }
        public int P_DOCUMENT_HANDLE { get; set; }
    }

    public class DeleteEmployeeDocumentResponse
    {
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MSG { get; set; }
    }
}
