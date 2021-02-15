using System;

namespace APIMiddleware.Core.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; } // REQUEST_ID 
        public string RequestGuid { get; set; }
        public int ProjectCode { get; set; } // PROJECT_ID
        public string ProjectName { get; set; }
        public DateTime RequestDate { get; set; } // REQUEST_DATE 
        public DateTime RequestTime { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public long ElapsedMilliseconds { get; set; }
        public int StatusCode { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public byte[] ResponseBody { get; set; }
        public byte[] RequestBody { get; set; }
        public bool IsSuccess { get; set; }
        public string  Host { get; set; }
        public string RequestExtension { get; set; }
        public string ResponseExtension { get; set; }
    }
}
