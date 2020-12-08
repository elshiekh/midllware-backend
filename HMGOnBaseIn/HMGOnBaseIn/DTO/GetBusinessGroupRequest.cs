using System.Collections.Generic;

namespace HMGOnBaseIn.DTO
{
    public class GetBusinessGroupRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_BUSINESS_GROUP";
        }
        public List<GetBusinessGroupResponse> response { get; set; }
    }

    public class GetBusinessGroupResponse
    {
        public string LEGAL_ENTITY { get; set; }
    }
}
