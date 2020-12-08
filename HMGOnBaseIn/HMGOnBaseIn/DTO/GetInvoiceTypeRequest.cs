using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMGOnBaseIn.DTO
{
    public class GetInvoiceTypeRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_INVOICE_TYPE";
        }
        public List<GetInvoiceTypeResponse> response { get; set; }
    }

    public class GetInvoiceTypeResponse {
        public string INVOICE_CODE { get; set; }
        public string MEAINING { get; set; }
    }
}
