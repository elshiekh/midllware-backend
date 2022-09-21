using System.Collections.Generic;

namespace ePharmacy_Out.Category
{

    #region New-Category
    public class CreateCategoryRequest
    {
        public int oracle_id { get; set; }
        public int category_id { get; set; }
        public string category_code { get; set; }
        public string category_name_us { get; set; }
        public string category_name_ar { get; set; }
        public bool enabled_flag { get; set; }
        public int category_parent_id { get; set; }
        public string category_type { get; set; }
    }



    // Response --------
    public class CategoryResponse
    {
        public List<ResponseCategory> categories { get; set; }
    }
    #endregion


    #region Update-Category

    public class UpdateCategoryRequest
    {
        public int oracle_id { get; set; }
        public int category_id { get; set; }
        public string category_name_us { get; set; }
        public string category_name_ar { get; set; }
        public bool enabled_flag { get; set; }
        public int category_parent_id { get; set; }
    }
    #endregion


    #region GET-CATEGORY-RESPONSE
    public class ResponseCategory
    {
        public int oracle_id { get; set; }
        public string epharmacy_id { get; set; }
        public string return_status { get; set; }
        public string return_message { get; set; }
    }
    #endregion



    #region Token-RESPONSE

    //Token
    public class TokenResponse
    {
        public string id { get; set; }
        public string auth_token { get; set; }
        public int expires_in { get; set; }
    }
    #endregion

}
