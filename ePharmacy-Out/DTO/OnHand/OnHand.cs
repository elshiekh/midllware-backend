using System.Collections.Generic;

namespace ePharmacy_Out.OnHand
{

    #region DailyBatch
    public class DailyBatchRequest
    {
        public int oracle_id { get; set; }
        public string item_code { get; set; }
        public string organization_code { get; set; }
        public string subinventory_code { get; set; }
        public int onhand_qty { get; set; }
    }


    // Response --------
    public class DailyBatchResponse
    {
        public List<ResponseDailyBatch> items_onhand { get; set; }
    }

    #endregion



    #region GET-ITEM-RESPONSE
    public class ResponseDailyBatch
    {
        public int oracle_id { get; set; }
        public string epharmacy_id { get; set; }
        public string return_status { get; set; }
        public string return_message { get; set; }
    }
    #endregion



    #region Token-RESPONSE
    public class TokenResponse
    {
        public string id { get; set; }
        public string auth_token { get; set; }
        public int expires_in { get; set; }
    }
    #endregion
}
