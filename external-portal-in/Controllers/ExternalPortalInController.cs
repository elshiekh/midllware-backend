using external_portal_in.DTO;
using external_portal_in.Extenstion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Threading.Tasks;

namespace external_portal_in.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class ExternalPortalInController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public ExternalPortalInController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region GetOperatingUnits
        [HttpGet("GetOperatingUnits.{format}")]
        public IActionResult GetOperatingUnits()
        {
            try
            {
                GetOperatingUnitsRequest request = new GetOperatingUnitsRequest();
                //Command text for getting the REF Cursor as OUT parameter
                using (OracleConnection objConn = new OracleConnection(_dbOption.DbConection))
                {
                    OracleCommand objCmd = new OracleCommand();
                    objCmd.Connection = objConn;
                    objCmd.CommandText = request.GetSPName();
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.Add("P_OPERATING_UNITS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    try
                    {
                        objConn.Open();
                        OracleDataReader objReader = objCmd.ExecuteReader();
                        List<GetOperatingUnitsResponse> OperatingUnitList = new List<GetOperatingUnitsResponse>();
                        OperatingUnitList = QueryExtenstion.DataReaderMapToList<GetOperatingUnitsResponse>(objReader);

                        objReader.Close();

                        objConn.Close();
                        objConn.Dispose();
                        return Ok(OperatingUnitList);
                    }
                    catch (Exception ex)
                    {
                        objConn.Close();
                        return ReturnException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region ValidatePo 
        [HttpPost("VALIDATE_PO.{format}")]
        public async Task<IActionResult> ValidatePo([FromBody] ValidatePoRequest request)
        {
            try
            {
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                IDataParameter[] parameters = new IDataParameter[3];

                parameters[0] = new OracleParameter("P_ORG_ID", OracleDbType.Int32, 25, ParameterDirection.Input, false, 0, 0, "P_ORG_ID", DataRowVersion.Current, request.P_ORG_ID); // 
                parameters[1] = new OracleParameter("P_PO_NUMBER", OracleDbType.Varchar2, 25, ParameterDirection.Input, false, 0, 0, "P_PO_NUMBER", DataRowVersion.Current, request.P_PO_NUMBER);   //
                // Outputs
                parameters[2] = new OracleParameter("P_FOUND_FLAG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

                using (OracleCommand command = Extenstion.QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var result = new ValidatePoResponse()
                    {
                        P_FOUND_FLAG = command.Parameters["P_FOUND_FLAG"].Value.ToString()
                    };
                    conn.Close();
                    conn.Dispose();

                    return Ok(result);
                }
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