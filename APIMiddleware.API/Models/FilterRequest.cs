using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMiddleware.API.Models
{
    public class FilterRequest
    {
        public int? ProjectId { get; set; }
        public string Function { get; set; }
        public string StatusCode { get; set; }
        public int? RequestReceiveId { get; set; }
        public string UserName { get; set; }
        public string IpAddress { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
