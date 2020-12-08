using System.Collections.Generic;

namespace HMGOnBaseIn.DTO
{
    public class GetPositionTitleRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_POSITION_TITLE";
        }
        public List<GetPositionTitleResponse> response { get; set; }
    }

    public class GetPositionTitleResponse
    {
        public string POSITION_TITLE { get; set; }
    }
}
