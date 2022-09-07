using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ePharmacy_In.DTO;
using ePharmacy_In.Mapper;
using ePharmacy_In.Extenstion;

namespace ePharmacy_In.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class ePharmacyInController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public ePharmacyInController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region Item
        [HttpPost("GetItemONhand.{format}")]
        public async Task<IActionResult> GetItemONhand([FromBody] GetItemONhandRequest request)
        {
            try
            {
                var result = new List<CrudItemsResponse>();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);

                IDataParameter[] parameters = new IDataParameter[4];

                parameters[0] = new OracleParameter("P_ITEMS_DETAILS_REQ", OracleDbType.XmlType, request.ToXMLCreateItems(), ParameterDirection.Input);     // Input

                parameters[1] = new OracleParameter("P_ITEMS_DETAILS_RESP", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);      // Outputs
                parameters[2] = new OracleParameter("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);      // Outputs
                parameters[3] = new OracleParameter("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);      // Outputs

                using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();

                    var result1 = new ItemsDetailsResponse()
                    {
                        P_ITEMS_DETAILS_RESP = command.Parameters["P_ITEMS_DETAILS_RESP"].Value.ToString(),
                        P_RETURN_MSG = command.Parameters["P_RETURN_MSG"].Value.ToString(),
                        P_RETURN_STATUS = command.Parameters["P_RETURN_STATUS"].Value.ToString(),
                    };

                    //byte[] byteArray = Convert.FromBase64String(result1.P_ITEMS_DETAILS_RESP);
                    //string jsonBack = Encoding.UTF8.GetString(byteArray);

                    result = JsonConvert.DeserializeObject<List<CrudItemsResponse>>(result1.P_ITEMS_DETAILS_RESP);
                    conn.Close();
                    conn.Dispose();

                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Return Exception
        private IActionResult ReturnException(Exception ex)
        {
            HttpContext.Response.ContentType = "application/json";
            HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return StatusCode(HttpContext.Response.StatusCode, JsonConvert.SerializeObject(new
            {
                error = new
                {
                    message = ex.Message,
                    exception = ex.GetType().Name
                }
            }));
        }
        #endregion
    }
}