using System.Collections.Generic;

namespace HMGOnBaseOut.DTO
{
    public class GetItemCodeRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_ITEM_CODE";
        }
        public List<GetItemCodeResponse> response { get; set; }
    }

    public class GetItemCodeResponse
    {
        public string SEGMENT1 { get; set; }
    }
}

