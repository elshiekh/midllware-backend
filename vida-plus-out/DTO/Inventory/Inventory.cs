using System.Collections.Generic;

namespace vida_plus_out.Inventory
{

    #region InsertInventory
    public class InsertInventoryRequest
    {
        public string oracleId { get; set; }
        public string transactionId { get; set; }
        public string itemCode { get; set; }
        public string organizationCode { get; set; }
        public string subinventory_code { get; set; }
        public string transactionDate { get; set; }
        public string transactionQuantity { get; set; }
        public string lotNumber { get; set; }
        public string lotExpirationDate { get; set; }
        public string purchasePrice { get; set; }
        public string salesPrice { get; set; }
        public string mfgBatchNumber { get; set; }
        public string gtin { get; set; }
    }


    // Response --------
    public class InsertInventoryResponse
    {
        public string vidaplusId { get; set; }
        public string responseStatus { get; set; }
        public string responseMsg { get; set; }
    }
    #endregion


    #region UpdateInventory
    public class UpdateInventoryRequest
    {
        public string oracleId { get; set; }
        public string organizationCode { get; set; }
        public string itemCode { get; set; }
        public string lotNumber { get; set; }
        public string newExpirationDate { get; set; }
    }


    // Response --------
    public class UpdateInventoryResponse
    {
        public string vidaplusId { get; set; }
        public string responseStatus { get; set; }
        public string responseMsg { get; set; }
    }
    #endregion

}
