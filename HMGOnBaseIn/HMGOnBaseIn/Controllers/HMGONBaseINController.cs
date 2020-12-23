using HMGOnBaseIn.DTO;
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
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: Store-Retrieve-Document-" + DateTime.Now);
                return BadRequest();
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
                return BadRequest();
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
                    using (var response = await httpClient.PutAsync("http://10.201.203.132/onbaseapi/api/documents?OnBaseDocID=" + request.OnBaseDocID, content))
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
                ;
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