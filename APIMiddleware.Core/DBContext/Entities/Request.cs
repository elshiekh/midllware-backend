using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMiddleware.Core.DBContext.Entities
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public int ProjectCode { get; set; }
        public string RequestGuid { get; set; }
        public DateTime RequestTime { get; set; }
        public long ElapsedMilliseconds { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public byte[] RequestBody { get; set; }
        public byte[] ResponseBody { get; set; }


        [ForeignKey("ProjectCode")]
        public virtual Project Project { get; set; }
    }
}
