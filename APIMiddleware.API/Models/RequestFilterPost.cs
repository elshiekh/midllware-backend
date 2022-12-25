namespace APIMiddleware.API.Models
{
    public class RequestFilterPost
    {
        public int? requestId { get; set; }
        public int? projectId { get; set; }
        public string function { get; set; }
        public int? responseCode { get; set; }
        public string requestStatus { get; set; }
        public string ipAddress { get; set; }
        public string userName { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}

//: "13/02/2021"
//: ""
//: ""
//: 0
//requestStatus: ""
//responseCode: 200
//: "15/03/2021"
//: ""