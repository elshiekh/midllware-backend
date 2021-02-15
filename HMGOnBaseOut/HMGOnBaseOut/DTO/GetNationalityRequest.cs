using System.Collections.Generic;

namespace HMGOnBaseOut.DTO
{
    public class GetNationalityRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG. GET_NATIONALITY";
        }
        public List<GetNationalityResponse> response { get; set; }
    }

    public class GetNationalityResponse
    {
        public string NATIONALITY { get; set; }
    }
}
