using System.Collections.Generic;

namespace HMGOnBaseIn.DTO
{
    public class GetItemCodeRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_ITEM_CODE";
        }
        public List<GetItemNameResponse> response { get; set; }
    }

    public class GetItemCodeResponse
    {
        public string ITEM_CODE { get; set; }
    }
}

