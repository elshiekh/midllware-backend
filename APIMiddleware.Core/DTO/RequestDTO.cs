using System;

namespace APIMiddleware.Core.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; } // REQUEST_ID 
        public string RequestGuid { get; set; }
        public int ProjectId { get; set; } // PROJECT_ID
        public string ProjectName { get; set; }
        public DateTime RequestDate { get; set; } // REQUEST_DATE 
        public DateTime RequestTime { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public long ElapsedMilliseconds { get; set; }
       // public int RequestStatus { get; set; }
        public int ResponseCode { get; set; }
        public string RequestMethod { get; set; }
        public string RequestFunction { get; set; }
        public string RequestFormat { get; set; }
        public string ResponseFormat { get; set; }
        public string RequestUrl { get; set; }
        public string QueryString { get; set; }
        public byte[] ResponseBody { get; set; }
        public byte[] RequestBody { get; set; }
        public string RequestStatus { get; set; }
        public string  IP_Address { get; set; }
        public string UserName { get; set; }
        public string RowVersion { get; set; }
        public string RequestStart { get; set; }
        public string ResponseFinish { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Created_By { get; set; }
        public DateTime? Last_Update_Date { get; set; }
        public string Last_Updated_By { get; set; }
    }
}
