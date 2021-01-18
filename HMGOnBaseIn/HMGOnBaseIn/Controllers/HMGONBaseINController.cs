﻿using HMGOnBaseIn.DTO;
using HMGOnBaseIn.Extenstion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HMGOnBaseIn.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [FormatFilter]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class HMGOnBaseINController : ControllerBase
    {
        private readonly DBOption _dbOption;
        private readonly ILogger _logger;

        public HMGOnBaseINController(DBOption dbOption, ILogger<HMGOnBaseINController> logger)
        {
            _dbOption = dbOption;
            _logger = logger;
        }
        
        // ---- RetrieveDocumentList
        [HttpPost("api/HMGOnBaseIN/RetrieveDocumentList.{format}")]
        public async Task<IActionResult> RetrieveDocumentList(RetrieveDocumentListRequest request)
        {
            try
            {
                _logger.LogInformation("Fire Retrieve Document List");
                var isXML = Request.ContentType.Contains("application/xml");
                RetrieveDocumentListResponse result = new RetrieveDocumentListResponse();
                HttpClientHandler httpClientHandler = new HttpClientHandler()
                {
                    Credentials = new NetworkCredential("onbase", "onbase123"),
                };
                var onBaseDocIDList = new List<long>();
                foreach (var item in request.DOC)
                {
                    onBaseDocIDList.Add(item.ID);
                }
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    var byteArray = Encoding.ASCII.GetBytes("onbase:onbase123");

                    httpClient.DefaultRequestHeaders.Authorization = new
                    AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    StringContent content = new StringContent(JsonConvert.SerializeObject(onBaseDocIDList), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://10.201.203.132/OnBaseAPI/API/documents/GetDocListBytes", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        if (isXML)
                        {
                            result.Rows = JsonConvert.DeserializeObject<List<Row>>(apiResponse.ToString());
                        }
                        else
                        {
                            result.Rows = JsonConvert.DeserializeObject<List<Row>>(apiResponse.ToString());
                        }
                    }
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: Retrieve Document List-" + DateTime.Now);
                throw ex;
            }
        }
      
        // ---- RetrieveDocument
        [HttpGet("api/HMGOnBaseIN/RetrieveDocument.{format}")]
        public async Task<IActionResult> RetrieveDocument(string OnBaseDocID)
        {
            try
            {
                _logger.LogInformation("Fire Store Retrieve Document");
                RetrieveDocumentResponse result = new RetrieveDocumentResponse();
                HttpClientHandler httpClientHandler = new HttpClientHandler()
                {
                    Credentials = new NetworkCredential("onbase", "onbase123"),
                };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    var byteArray = Encoding.ASCII.GetBytes("onbase:onbase123");

                    httpClient.DefaultRequestHeaders.Authorization = new
                    AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    using (var response = await httpClient.GetAsync("http://10.201.203.132/onbaseapi/api/documents?OnBaseDocID=" + OnBaseDocID))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<RetrieveDocumentResponse>(apiResponse.ToString());
                    }
                }
                //TETSXML(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: Store-Retrieve-Document-" + DateTime.Now);
                return BadRequest(ex);
            }
        }

        //---- StoreNewDocument
        [HttpPost("api/HMGOnBaseIN/StoreNewDocument.{format}")]
        public async Task<IActionResult> StoreNewDocument([FromBody] StoreNewDocumentRequest request)
        {
            try
            {
                _logger.LogInformation("Fire Store New Document");
                var isXML = Request.ContentType.Contains("application/xml");
                var fileBlob = GetFIle(request.FileId).FILE_DATA;
                if (fileBlob != null)
                {
                    request.FileBytes = Convert.ToBase64String(fileBlob, 0, fileBlob.Length);
                }
                else
                {
                    request.FileBytes = null;
                }
                //------123
                //string filePath = $@"E:\FOLDERTEST\" + "TTTTTTTTTTTT - " + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + request.FileExtension;
                //System.IO.FileStream file = System.IO.File.Create(filePath);
                //file.Write(fileBlob, 0, fileBlob.Length);
                //file.Close();
                //----------
               // string base64String = Convert.ToBase64String(fileBlob, 0, fileBlob.Length);
                //request.FileBytes = base64String;
                StoreNewDocumentResponse result = new StoreNewDocumentResponse();
                HttpClientHandler httpClientHandler = new HttpClientHandler()
                {
                    Credentials = new NetworkCredential("onbase", "onbase123"),
                };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    var byteArray = Encoding.ASCII.GetBytes("onbase:onbase123");

                    httpClient.DefaultRequestHeaders.Authorization = new
                    AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://10.201.203.132/OnBaseAPI/API/documents", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (isXML)
                        {
                            var doc = JsonConvert.DeserializeObject<StoreNewDocumentResponse>(apiResponse.ToString());
                        }
                        else
                        {
                            result = JsonConvert.DeserializeObject<StoreNewDocumentResponse>(apiResponse.ToString());
                        }
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: StoreNewDocument-" + DateTime.Now);
                throw ex;
            }
        }

        //---- UpdateDocumentBasedCondition
        [HttpPost("api/UpdateDocumentBasedCondition.{format}")]
        public async Task<IActionResult> UpdateDocumentBasedCondition([FromBody] UpdateDocumentBasedConditionRequest request)
        {
            try
            {
                _logger.LogInformation("Update Document Based On Condition");
                var isXML = Request.ContentType.Contains("application/xml");
                UpdateDocumentBasedConditionResponse result = new UpdateDocumentBasedConditionResponse();
                HttpClientHandler httpClientHandler = new HttpClientHandler()
                {
                    Credentials = new NetworkCredential("onbase", "onbase123"),
                };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    var byteArray = Encoding.ASCII.GetBytes("onbase:onbase123");

                    httpClient.DefaultRequestHeaders.Authorization = new
                    AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://10.201.203.132/RequiredDocsRule/API/RequiredDoc", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (isXML)
                        {
                            var doc = JsonConvert.DeserializeObject<UpdateDocumentBasedConditionResponse>(apiResponse.ToString());
                        }
                        else
                        {
                            result = JsonConvert.DeserializeObject<UpdateDocumentBasedConditionResponse>(apiResponse.ToString());
                        }
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: Update Document Based Condition-" + DateTime.Now);
                throw ex;
            }
        }

        //---- SetOnBaseURL
        [HttpPost("api/HMGOnBaseIN/SetOnBaseURL.{format}")]
        public async Task<IActionResult> SetOnBaseURL([FromBody] SetOnBaseURLRequest request)
        {
            OracleConnection conn = new OracleConnection(_dbOption.DbConection);
            IDataParameter[] parameters = new IDataParameter[4];
            // Inputs
            parameters[0] = new OracleParameter("P_FILE_ID", OracleDbType.Int64, request.P_FILE_ID, ParameterDirection.Input);
            parameters[1] = new OracleParameter("P_DOCUMENT_ID", OracleDbType.NVarchar2, request.P_DOCUMENT_ID, ParameterDirection.Input);
            parameters[2] = new OracleParameter("P_URL", OracleDbType.NVarchar2, request.P_URL, ParameterDirection.Input);
            // Outputs
            parameters[3] = new OracleParameter("P_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);


            using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
            {
                try
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var result = new SetOnBaseURLResponse()
                    {
                        P_STATUS = command.Parameters["P_STATUS"].Value.ToString(),
                    };

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }

        //---- PostRevision
        [HttpPost("api/HMGOnBaseIN/PostRevision.{format}")]
        public async Task<IActionResult> PostRevision([FromBody] PostRevisionRequest request)
        {
            try
            {
                _logger.LogInformation("Fire Store New Document");
                var isXML = Request.ContentType.Contains("application/xml");
                var fileBlob = GetFIle(request.FileId).FILE_DATA;
                if (fileBlob != null) 
                {
                    request.fileBytes = Convert.ToBase64String(fileBlob, 0, fileBlob.Length); 
                } else {
                    request.fileBytes = null; 
                }
                PostRevisionResponse result = new PostRevisionResponse();
                HttpClientHandler httpClientHandler = new HttpClientHandler()
                {
                    Credentials = new NetworkCredential("onbase", "onbase123"),
                };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    var byteArray = Encoding.ASCII.GetBytes("onbase:onbase123");

                    httpClient.DefaultRequestHeaders.Authorization = new
                    AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                    StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://10.201.203.132/OnBaseAPI/API/documents/PostRevision", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        if (isXML)
                        {
                            var doc = JsonConvert.DeserializeObject<PostRevisionResponse>(apiResponse.ToString());
                        }
                        else
                        {
                            result = JsonConvert.DeserializeObject<PostRevisionResponse>(apiResponse.ToString());
                        }
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: PostRevision-" + DateTime.Now);
                return BadRequest();
            }
        }

        //---- UpdateDocument
        [HttpPut("api/HMGOnBaseIN/UpdateDocument.{format}")]
        public async Task<IActionResult> UpdateDocument([FromBody] StoreUpdateDocumentRequest request)
        {
            try
            {
                _logger.LogInformation("Fire Store Update Document");
                StoreUpdateDocumentResponse result = new StoreUpdateDocumentResponse();
                HttpClientHandler httpClientHandler = new HttpClientHandler()
                {
                    Credentials = new NetworkCredential("onbase", "onbase123"),
                };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    var byteArray = Encoding.ASCII.GetBytes("onbase:onbase123");

                    httpClient.DefaultRequestHeaders.Authorization = new
                    AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("http://10.201.203.132/OnBaseAPI/API/documents/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<StoreUpdateDocumentResponse>(apiResponse.ToString());
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: StoreUpdateDocument-" + DateTime.Now);
                return BadRequest();
            }
        }

        //---- DeleteDocument
        [HttpDelete("api/HMGOnBaseIN/DeleteDocument/.{format}")]
        public async Task<IActionResult> DeleteDocument(long OnBaseDocID, bool DeletePermanently)
        {
            try
            {
                _logger.LogInformation("Fire Store Delete Document");
                StoreDeleteDocumentResponse result = new StoreDeleteDocumentResponse();
                HttpClientHandler httpClientHandler = new HttpClientHandler()
                {
                    Credentials = new NetworkCredential("onbase", "onbase123"),
                };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    var byteArray = Encoding.ASCII.GetBytes("onbase:onbase123");

                    httpClient.DefaultRequestHeaders.Authorization = new
                    AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                    using (var response = await httpClient.DeleteAsync("http://10.201.203.132/onbaseapi/api/documents?OnBaseDocID=" + OnBaseDocID + "&DeletePermanently=" + DeletePermanently))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<StoreDeleteDocumentResponse>(apiResponse.ToString());
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: StoreDeleteDocument-" + DateTime.Now);
                return BadRequest();
            }
        }

        //----SetHrRequiredDocErrors
        [HttpPost("api/HMGOnBaseIN/SetHrRequiredDocErrors.{format}")]
        public async Task<IActionResult> SetHrRequiredDocErrors([FromBody] SetHrRequiredDocErrorsRequest request)
        {
            OracleConnection conn = new OracleConnection(_dbOption.DbConection);
            IDataParameter[] parameters = new IDataParameter[3];
            // Inputs
            parameters[0] = new OracleParameter("P_EMPLOYEE_NUM", OracleDbType.Int32, request.P_EMPLOYEE_NUM, ParameterDirection.Input);
            parameters[1] = new OracleParameter("P_STATUS", OracleDbType.NVarchar2, request.P_STATUS, ParameterDirection.Input);
            parameters[2] = new OracleParameter("P_DESCRIPTION", OracleDbType.NVarchar2, request.P_DESCRIPTION, ParameterDirection.Input);
 
            using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
            {
                try
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var result = new SetHrRequiredDocErrorsResponse()
                    {
                        //P_ORACLE_ID = Convert.ToDecimal(((OracleDecimal)command.Parameters["@P_ORACLE_ID"].Value).Value),
                        //P_RESPONSE_STATUS = command.Parameters["@P_RESPONSE_STATUS"].Value.ToString(),
                        //P_RESPONSE_MSG = command.Parameters["@P_RESPONSE_MSG"].Value.ToString()
                    };

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }

        private GetFileResponse GetFIle(int FILE_ID)
        {
            try
            {
                GetFileRequest request = new GetFileRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_FILE_ID)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_FILE_ID", FILE_ID);
                OracleDataReader reader = cmd.ExecuteReader();
                GetFileResponse fileResponset = new GetFileResponse();
                
                while (reader.Read())
                {
                    fileResponset = reader.ConvertToObject<GetFileResponse>();
                }
                reader.Close();

                return fileResponset;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
      #region LegacySection
         //private IActionResult TETS(RetrieveDocumentResponse request)
//{

//    List<DocFile> myTable = new List<DocFile>();
//    byte[] clob = Convert.FromBase64String(request.Doc.FileBytes);
//    //myTable.Add(new DocFile { FileBytes = clob);

//    OracleConnection conn = new OracleConnection(_dbOption.DbConection);
//    conn.Open();
//    OracleCommand cmd = new OracleCommand("XX_TEST_MW.GET_ONBASE_FILE", conn);
//    cmd.CommandType = CommandType.StoredProcedure;

//    //Pass table Valued parameter to Store Procedure
//    OracleParameter oracleParam = cmd.Parameters.Add("P_ONBASE_FILE_TBL", myTable);
//    //oracleParam.OracleDbType = DbType.;
//    cmd.ExecuteNonQuery();
//    conn.Close();
//    Console.Write("Data Save Successfully.");
//    return Ok(123);
//    //byte[] clob = Convert.FromBase64String(request.Doc.FileBytes);
//    //OracleConnection conn = new OracleConnection(_dbOption.DbConection);
//    //IDataParameter[] parameters = new IDataParameter[4];
//    //// Inputs
//    //parameters[0] = new OracleParameter("P_FILE_BYTES", OracleDbType.Blob, clob, ParameterDirection.Input);
//    //parameters[1] = new OracleParameter("P_FILE_EXTENSION", OracleDbType.NVarchar2, request.Doc.FileExtension, ParameterDirection.Input);
//    //parameters[2] = new OracleParameter("P_STATUS", OracleDbType.NVarchar2, request.Status, ParameterDirection.Output);
//    //parameters[3] = new OracleParameter("P_ERROR_MESSAGE", OracleDbType.NVarchar2, request.Description, ParameterDirection.Output);

//    //using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, "XX_TEST_MW.GET_ONBASE_FILE", parameters))
//    //{
//    //    try
//    //    {
//    //        conn.Open();
//    //        var isSuccess =  command.ExecuteNonQueryAsync();
//    //        var result = new SetHrRequiredDocErrorsResponse()
//    //        {
//    //            //P_ORACLE_ID = Convert.ToDecimal(((OracleDecimal)command.Parameters["@P_ORACLE_ID"].Value).Value),
//    //            //P_RESPONSE_STATUS = command.Parameters["@P_RESPONSE_STATUS"].Value.ToString(),
//    //            //P_RESPONSE_MSG = command.Parameters["@P_RESPONSE_MSG"].Value.ToString()
//    //        };

//    //        return Ok(result);
//    //    }
//    //    catch (Exception ex)
//    //    {
//    //        return BadRequest(ex);
//    //    }
//    //}
//}

//private IActionResult TETSXML(RetrieveDocumentResponse request)
//{
//    var xmlObject = QueryExtenstion.ConvertObjectToXMLString(request);
//    OracleConnection conn = new OracleConnection(_dbOption.DbConection);
//    IDataParameter[] parameters = new IDataParameter[1];
//    // Inputs
//    parameters[0] = new OracleParameter("P_ONBASE_DATA", OracleDbType.XmlType, xmlObject, ParameterDirection.Input);

//    using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, "XX_TEST_MW.GET_ONBASE_XMLTYPE", parameters))
//    {
//        try
//        {
//            conn.Open();
//            var isSuccess = command.ExecuteNonQueryAsync();
//            var result = new SetHrRequiredDocErrorsResponse()
//            {
//                //P_ORACLE_ID = Convert.ToDecimal(((OracleDecimal)command.Parameters["@P_ORACLE_ID"].Value).Value),
//                //P_RESPONSE_STATUS = command.Parameters["@P_RESPONSE_STATUS"].Value.ToString(),
//                //P_RESPONSE_MSG = command.Parameters["@P_RESPONSE_MSG"].Value.ToString()
//            };

//            return Ok(result);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(ex);
//        }
//    }
//}
      #endregion