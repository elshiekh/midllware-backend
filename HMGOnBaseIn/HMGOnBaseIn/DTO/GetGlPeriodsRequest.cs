using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMGOnBaseIn.DTO
{
    public class GetGlPeriodsRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_GL_PERIODS";
        }
    }

    public class GetGlPeriodsResponse
    {
        public string PERIOD_NAME { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime END_DATE { get; set; }
    }
}
