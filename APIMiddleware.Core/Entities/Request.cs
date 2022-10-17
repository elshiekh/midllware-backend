using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMiddleware.Core.Entities
{
    [Table("MID_REQUESTS")]
    public class Request
    {
        [Key]

        [Column("REQUEST_ID")]
        public int RequestId { get; set; }

        [Column("PROJECT_ID")]
        public int ProjectId { get; set; }

        [Column("REQUEST_GUID")]
        public string RequestGuid { get; set; }

        [Column("REQUEST_DATE")]
        public DateTime RequestTime { get; set; }

        [Column("ELAPSED_TIME")]
        public long ElapsedMilliseconds { get; set; }

        [Column("RESPONSE_CODE")]
        public int ResponseCode { get; set; }

        [Column("REQUEST_STATUS")]
        public string RequestStatus { get; set; }

        [Column("REQUEST_METHOD")]
        public string RequestMethod { get; set; }

        [Column("REQUEST_FUNCTION")]
        public string RequestFunction { get; set; }

        [Column("REQUEST_URL")]
        public string RequestUrl { get; set; }

        [Column("QUERY_STRING")]
        public string QueryString { get; set; }

        [Column("REQUEST_BODY")]
        public byte[] RequestBody { get; set; }

        [Column("REQUEST_FORMAT")]
        public string RequestFormat { get; set; }

        [Column("RESPONSE_BODY")]
        public byte[] ResponseBody { get; set; }

        [Column("RESPONSE_FORMAT")]
        public string ResponseFormat { get; set; }

        [Column("IP_ADDRESS")]
        public string IP_Address { get; set; }

        [Column("USER_NAME")]
        public string UserName { get; set; }

        [Column("ROW_VERSION")]
        public string RowVersion { get; set; }

        [Column("CREATION_DATE")]
        public DateTime Creation_Date { get; set; }

        [Column("CREATED_BY")]
        public string Created_By { get; set; }

        [Column("LAST_UPDATE_DATE")]
        public DateTime? Last_Update_Date { get; set; }

        [Column("LAST_UPDATED_BY")]
        public string Last_Updated_By { get; set; }

        [ForeignKey("ProjectId")]
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
