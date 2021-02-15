using System.Collections.Generic;

namespace HMGONBaseController.DTO
{
    public class GetJobTitlesResponse
    {
        public string JOB_TITLE { get; set; }
    }

    public class GetJobTitlesRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_JOB_TITLES";
        }
        public List<GetJobTitlesResponse> response { get; set; }
    }
}
