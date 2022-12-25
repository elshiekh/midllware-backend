﻿using System;
using System.Collections.Generic;

namespace elevatus_out.DTO
{
    public class GetOperatingUnitsRequest
    {
        public string GetSPName()
        {
            return "HMG_EXT_PORTAL_INT_IN_PKG.GET_OPERATING_UNITS";
        }
        public List<GetOperatingUnitsResponse> response { get; set; }
    }

    public class GetOperatingUnitsResponse
    {
        public Int64 ORG_ID { get; set; }
        public string ORG_NAME { get; set; }
    }
}
