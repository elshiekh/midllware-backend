using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMGOnBaseIn.DTO
{
    public class GetItemNameRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_ITEM_NAME";
        }
        public List<GetItemNameResponse> response { get; set; }
    }

    public class GetItemNameResponse
    {
        public string ITEM_NAME { get; set; }
    }
}
