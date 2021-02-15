using System.Collections.Generic;

namespace HMGONBaseController.DTO
{
    public class GetEmploymentCategoryResponse
    {
        public string EMP_CAT { get; set; }
    }

    public class GetEmploymentCategoryRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG. GET_EMPLOYMENT_CATEGORY";
        }
        public List<GetEmploymentCategoryResponse> response { get; set; }
    }
}
