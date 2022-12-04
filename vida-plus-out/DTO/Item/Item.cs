using System.Collections.Generic;

namespace vida_plus_out.Item
{

    #region InsertItem
    public class ItemRequest
    {
        public string oracleId { get; set; }
        public string itemCode { get; set; }
        public string descriptionUs { get; set; }
        public string descriptionAr { get; set; }
        public string organizationCode { get; set; }
        public string primaryUom { get; set; }
        public string itemType { get; set; }
        public string hisUomCode { get; set; }
        public string hisCatCode { get; set; }
        public string groupId { get; set; }
        public string groupDesc { get; set; }
        public string subGroupId { get; set; }
        public string subGroupDesc { get; set; }
        public string ecommerceCatId { get; set; }
        public string ecommerceCatDesc { get; set; }
        public string implantFlag { get; set; }
        public string salesPrice { get; set; }
        public string taxableStatus { get; set; }
        public string sellingRate { get; set; }
        public string sfdaCode { get; set; }
        public string insuranceCategoryId { get; set; }
        public string insuranceCategoryDesc { get; set; }
        public string sfdaEnabledFlag { get; set; }
        public string gtin { get; set; }
    }


    // Response --------
    public class ItemResponse
    {
        public string vidaplusId { get; set; }
        public string responseStatus { get; set; }
        public string responseMsg { get; set; }
    }
    #endregion

}
