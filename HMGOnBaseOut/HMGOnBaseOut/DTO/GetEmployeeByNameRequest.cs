using System.Collections.Generic;

namespace HMGOnBaseOut.DTO
{
    public class GetEmployeeByNameRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_EMPLOYEE_NAME";
        }
        public List<GetEmployeeByNameResponse> response { get; set; }
    }

    public class GetEmployeeByNameResponse
    {
        public string FULL_NAME { get; set; }
    }
}
