using System;
using System.Collections.Generic;

namespace Vida.DTO
{
    public class ProcessTransactionsRequest
    {
        public string GetSPName()
        {
            return "HMG_VIDA_INV_INT_IN_PKG.PROCESS_TRANSACTIONS ";
        }

        public int P_VIDA_ID { get; set; }
        public string P_ORGANIZATION_CODE { get; set; }
        public string P_SUBINVENTORY_CODE { get; set; }
        public string P_TRANSACTION_TYPE { get; set; }
        public DateTime P_TRANSACTION_DATE { get; set; } = DateTime.Now;
        public int P_TRANSACTION_QUANTITY { get; set; }
        public string P_LOT_NUMBER { get; set; }
        public string P_COST_CENTER { get; set; }
        public string P_TRANSACTION_REFERENCE { get; set; }
        public int P_LINE_NUMBER { get; set; }
        public string P_ITEM_CODE { get; set; }
        public P_TRX_SERIALS_XML P_TRX_SERIALS_XML { get; set; }
    }

    public class ProcessTransactionsResponce
    {
        public decimal P_ORACLE_ID { get; set; }
        public string P_RESPONSE_STATUS { get; set; }
        public string P_RESPONSE_MSG { get; set; }
    }

    public class P_TRX_SERIALS_XML
    {
        public List<SERIAL> SERIAL { get; set; }
    }

    public class SERIAL { 
        public string SFDA_BARCODE { get; set; }
        public string GTIN { get; set; }
        public string SERIAL_NUMBER { get; set; }
    }
}
