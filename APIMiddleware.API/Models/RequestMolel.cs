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

        [Display(Name = "Status Code")]
        public int StatusCode { get; set; }

        [Display(Name = "Type")]
        public string Method { get; set; }

        [Display(Name = "Path")]
        public string Path { get; set; }

        [Display(Name = "Parameters")]
        public string QueryString { get; set; }

        [Display(Name = "Response Body")]
        public string ResponseBodyContent { get; set; }

        [Display(Name = "Request Body")]
        public string RequestBodyContent { get; set; }

        [Display(Name = "Response Body")]
        public byte[] ResponseBody { get; set; }

        [Display(Name = "Request Body")]
        public byte[] RequestBody { get; set; }

        [Display(Name = "Success")]
        public bool IsSuccess { get; set; }

        public string Date { get; set; }
        public string Time { get; set; }
    }
}
