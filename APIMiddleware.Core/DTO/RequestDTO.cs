using System;

namespace APIMiddleware.Core.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public string RequestGuid { get; set; }
        public int ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public DateTime RequestTime { get; set; }
        public long ElapsedMilliseconds { get; set; }
        public int StatusCode { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public byte[] ResponseBody { get; set; }
        public byte[] RequestBody { get; set; }
        public bool IsSuccess { get; set; }
    }
}
