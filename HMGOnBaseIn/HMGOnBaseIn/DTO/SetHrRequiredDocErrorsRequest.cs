namespace HMGOnBaseIn.DTO
{
    public class SetHrRequiredDocErrorsRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.SET_HR_EMP_REQUIRED_DOC_ERR";
        }
        public int P_EMPLOYEE_NUM { get; set; }
        public string P_STATUS { get; set; }
        public string P_DESCRIPTION { get; set; }
    }
    public class SetHrRequiredDocErrorsResponse
    {

    }
 }
