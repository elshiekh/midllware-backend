using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMGOnBaseIn.DTO
{
    public class GetLedgersRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG. GET_LEDGERS";
        }

        public List<GetLedgersResponse> response { get; set; }
    }
    public class GetLedgersResponse
    {
        public Int64 LEDGER_ID { get; set; }
        public string LEDGER_NAME { get; set; }
    }
}
