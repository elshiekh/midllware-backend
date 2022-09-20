using System.Collections.Generic;

namespace ePharmacy_Out.Item
{

    #region New-Item
    public class ItemRequest
    {
        public int oracle_id { get; set; }
        public string item_code { get; set; }
        public string description_us { get; set; }
        public string system_name_ar { get; set; }
        public string description_ar { get; set; }
        public string long_description_us { get; set; }
        public string long_description_ar { get; set; }
        public string primary_unit_of_measure { get; set; }
        public string ecommerce_category_id { get; set; }
        public string group_subgroup_category_id { get; set; }
        public string unit_weight { get; set; }
        public string weight_uom_code { get; set; }
        public string sfda_code { get; set; }
        public string short_description_us { get; set; }
        public string short_description_ar { get; set; }
        public string brand_us { get; set; }
        public string brand_ar { get; set; }
        public string storage_us { get; set; }
        public string storage_ar { get; set; }
        public string composition { get; set; }
        public string spf { get; set; }
        public string manufacturer_country_code { get; set; }
        public string manufacturer_country_name_us { get; set; }
        public string manufacturer_country_name_ar { get; set; }
        public string sales_price { get; set; }
        public string vat_rate { get; set; }
    }


    // Response --------
    public class ItemResponse
    {
        public List<ResponseItem> items { get; set; }
    }
    #endregion



    #region GET-ITEM-RESPONSE
    public class ResponseItem
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
