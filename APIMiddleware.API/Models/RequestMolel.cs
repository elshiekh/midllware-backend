using System;
using System.ComponentModel.DataAnnotations;

namespace APIMiddleware.API.Models
{
    public class RequestMolel
    {
        public int Id { get; set; }

        [Display(Name = "Guid")]
        public string RequestGuid { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Display(Name = "Time")]
        public DateTime RequestTime { get; set; }

        [Display(Name = "Elapsed Milliseconds")]
        public long ElapsedMilliseconds { get; set; }

        [Display(Name = "Request Status")]
        public int RequestStatus { get; set; }

        [Display(Name = "Method")]
        public string RequestMethod { get; set; }

        [Display(Name = "Request Url")]
        public string RequestUrl { get; set; }

        [Display(Name = "Parameters")]
        public string QueryString { get; set; }

        [Display(Name = "Response Body")]
        public byte[] ResponseBody { get; set; }

        [Display(Name = "Request Body")]
        public byte[] RequestBody { get; set; }

        [Display(Name = "Success")]
        public bool IsSuccess { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int ResponseStatus { get; set; }
        public string RequestFunction { get; set; }
        public string RequestFormat { get; set; }
        public string ResponseFormat { get; set; }
        public string IP_Address { get; set; }
        public string UserName { get; set; }
        public string RowVersion { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Created_By { get; set; }
        public DateTime? Last_Update_Date { get; set; }
        public string Last_Updated_By { get; set; }
    }
}
