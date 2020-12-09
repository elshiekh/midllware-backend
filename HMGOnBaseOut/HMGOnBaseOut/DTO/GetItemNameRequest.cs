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
        public string DESCRIPTION { get; set; }
    }
}
