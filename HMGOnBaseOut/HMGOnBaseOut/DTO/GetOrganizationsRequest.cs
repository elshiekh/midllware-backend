using System.Collections.Generic;

namespace HMGOnBaseOut.DTO
{
    public class GetOrganizationsRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_ORGANIZATIONS";
        }
        public List<GetOrganizationsResponse> response { get; set; }
    }

    public class GetOrganizationsResponse
    {
        public string ORG_NAME { get; set; }
    }
}
