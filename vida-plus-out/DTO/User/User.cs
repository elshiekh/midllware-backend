using System.Collections.Generic;

namespace vida_plus_out.Users
{

    #region ActivateUser
    public class ActivateUserRequest
    {
        public string oracleId { get; set; }
        public string updateDate { get; set; }
        public string employeeNumber { get; set; }
        public string replacementEmployeeNumber { get; set; }
        public string enableFlag { get; set; }
    }


    // Response --------
    public class ActivateUserResponse
    {
        public string vidaplusId { get; set; }
        public string responseStatus { get; set; }
        public string responseMsg { get; set; }
    }
    #endregion



    #region UpdateUser
    public class UpdateUserRequest
    {
        public string oracleId { get; set; }
        public string employeeNumber { get; set; }
        public string employeeName { get; set; }
        public string emailAddress { get; set; }
        public string mobileNumber { get; set; }
    }


    // Response --------
    public class UpdateUserResponse
    {
        public string vidaplusId { get; set; }
        public string responseStatus { get; set; }
        public string responseMsg { get; set; }
    }
    #endregion

}
