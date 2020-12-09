using System.Collections.Generic;

namespace HMGOnBaseOut.DTO
{
    public class GetPositionTitleRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_POSITION_TITLES";
        }
        public List<GetPositionTitleResponse> response { get; set; }
    }

    public class GetPositionTitleResponse
    {
        public string POSITION_TITLE { get; set; }
    }
}
