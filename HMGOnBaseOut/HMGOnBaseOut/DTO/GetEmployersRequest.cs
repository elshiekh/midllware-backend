using System.Collections.Generic;

namespace HMGONBaseController.DTO
{
    public class GetEmployersResponse
    {
        public string EMPLOYER_NAME { get; set; }
    }

    public class GetEmployersRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG. GET_EMPLOYERS";
        }
        public List<GetEmployersResponse> response { get; set; }
    }
}
