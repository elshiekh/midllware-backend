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
        public int RequestStatus { get; set; }
        public int ResponseStatus { get; set; }
       //  public string  ResponseError { get; set; }
        public bool IsSuccess { get; set; }
        public string RequestMethod { get; set; }
        public string RequestFunction { get; set; }
        public string RequestUrl { get; set; }
        public string QueryString { get; set; }
        public byte[] RequestBody { get; set; }
        public string RequestFormat { get; set; }
        public byte[] ResponseBody { get; set; }
        public string ResponseFormat { get; set; }
        public string IP_Address { get; set; }
        public string  UserName { get; set; }
        public string RowVersion { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Created_By { get; set; }
        public DateTime? Last_Update_Date { get; set; }
        public string Last_Updated_By { get; set; }

        [ForeignKey("ProjectCode")]
        public virtual Project Project { get; set; }

    }
}


//REQUEST_ID-- Identity Column
//PROJECT_ID
//REQUEST_DATE -- Date with time
//ELAPSED_TIME -- Milliseconds
//REQUEST_URL
//REQUEST_METHOD -- GET, POST, PUT, DELETE
//REQUEST_FUNCTION
//QUERY_STRING
//REQUEST_BODY
//REQUEST_FORMAT -- xml, json
//RESPONSE_BODY
//RESPONSE_FORMAT -- xml, json
//REQUEST_STATUS -- (Success, Failure, In Process) 
//RESPONSE_CODE--(200 Success, 400 Bad Request, 401 unauthorized, 500 Internal Server Error, 403 Forbidden, 404 Not Found)
//USER_NAME
//IP_ADDRESS
//--Who columns
//ROW_VERSION
//CREATION_DATE -- Date with time
//CREATED_BY
//LAST_UPDATE_DATE -- Date with time
//LAST_UPDATED_BY
