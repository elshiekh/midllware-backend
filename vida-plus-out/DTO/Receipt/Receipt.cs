using System.Collections.Generic;

namespace vida_plus_out.Receipt
{

    #region ArReceipts
    public class ArReceiptsRequest
    {
        public string oracleId { get; set; }
        public string receiptId { get; set; }
        public string operatingUnitCode { get; set; }
        public string hisCustomerNumber { get; set; }
        public string receiptNumber { get; set; }
        public string receiptAmount { get; set; }
        public string receiptDate { get; set; }
    }


    // Response --------
    public class ArReceiptsResponse
    {
        public string vidaplusId { get; set; }
        public string responseStatus { get; set; }
        public string responseMsg { get; set; }
    }
    #endregion

}
