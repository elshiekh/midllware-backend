using System;

namespace HMGOnBaseIn.DTO
{
    public class GetBanksRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_BANKS";
        }
    }

    public class GetBanksResponse
    {
        public string COUNTRY { get; set; }
        public Int64 BANK_ID { get; set; }
        public string BANK_NAME { get; set; }
    }
}
