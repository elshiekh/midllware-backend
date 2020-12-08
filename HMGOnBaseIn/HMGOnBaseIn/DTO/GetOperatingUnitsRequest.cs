using System;

namespace HMGONBaseController.DTO
{
    public class GetOperatingUnitsRequest
    {
        public string GetSPName()
        {
            return "APPS.HMG_ONBASE_INT_IN_PKG.GET_OPERATING_UNITS";
        }
    }
    public class GetOperatingUnitsResponse
    {
        public Int64 ORGANIZATION_ID { get; set; }
        public string OPERATING_UNIT { get; set; }
    }
}

