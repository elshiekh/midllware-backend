using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vida_plus_out.Leave
{

    #region LeaveReplacement
    public class LeaveReplacementRequest
    {
        public string oracleId { get; set; }
        public string employeeNumber { get; set; }
        public string leaveStartDate { get; set; }
        public string leaveEndDate { get; set; }
        public string replacementEmployeeNumber { get; set; }
    }


    // Response --------
    public class LeaveReplacementResponse
    {
        public string vidaplusId { get; set; }
        public string responseStatus { get; set; }
        public string responseMsg { get; set; }
    }
    #endregion

}
