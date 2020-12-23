using System.Collections.Generic;

namespace HMGOnBaseOut.DTO
{
    public class GetItemNameRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_ITEM_DESC";
        }
        public List<GetItemNameResponse> response { get; set; }
    }

    public class GetItemNameResponse
    {
        public string ITEM_DESCRIPTION { get; set; }
        public string ITEM_CODE { get; set; }
    }
}
