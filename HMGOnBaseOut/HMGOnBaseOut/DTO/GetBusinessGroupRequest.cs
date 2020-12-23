using System;
using System.Collections.Generic;

namespace HMGOnBaseOut.DTO
{
    public class GetBusinessGroupRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_BUSINESS_GROUPS";
        }
        public List<GetBusinessGroupResponse> response { get; set; }
    }

    public class GetBusinessGroupResponse
    {
        public Int64 BUSINESS_GROUP_ID { get; set; }
        public string BUSINESS_GROUP_NAME { get; set; }
    }
}
