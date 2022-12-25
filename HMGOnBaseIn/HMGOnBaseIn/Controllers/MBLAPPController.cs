using HMGOnBaseIn.DTO;
using HMGOnBaseIn.Extenstion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Net;
using System.Threading.Tasks;

namespace HMGOnBaseIn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class MBLAPPController : Controller
    {
        #region Filed
        private readonly DBOption _dbOption;
        private readonly ILogger _logger;
        public MBLAPPController(DBOption dbOption, ILogger<MBLAPPController> logger)
        {
            _dbOption = dbOption;
            _logger = logger;
        }
        #endregion

        #region LOGIN
        [HttpPost("Login.{format}")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            OracleConnection conn = new OracleConnection(_dbOption.DbConection);
            IDataParameter[] parameters = new IDataParameter[10];
            // Inputs
            parameters[0] = new OracleParameter("P_MBL_ID", OracleDbType.Int32, request.P_MBL_ID, ParameterDirection.Input);
            parameters[1] = new OracleParameter("P_USER_NAME", OracleDbType.NVarchar2, request.P_USER_NAME, ParameterDirection.Input);
            parameters[2] = new OracleParameter("P_LANGUAGE", OracleDbType.NVarchar2, request.P_LANGUAGE, ParameterDirection.Input);
            parameters[3] = new OracleParameter("P_PASSWORD", OracleDbType.NVarchar2, request.P_PASSWORD, ParameterDirection.Input);
            // Outputs
            parameters[4] = new OracleParameter("P_SESSION_ID", OracleDbType.Decimal, ParameterDirection.Output);
            parameters[5] = new OracleParameter("P_PASSWORD_EXPIRED", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
            parameters[6] = new OracleParameter("P_PASSWORD_EXPIRED_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
            parameters[7] = new OracleParameter("P_INVALID_LOGINS_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
            parameters[8] = new OracleParameter("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
            parameters[9] = new OracleParameter("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

            using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
            {
                try
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var sessionObject = command.Parameters["P_SESSION_ID"].Value;
                    var result = new LoginResponse()
                    {
                        // P_SESSION_ID = ((Oracle.ManagedDataAccess.Types.OracleDecimal)sessionObject).Value,
                        P_PASSWORD_EXPIRED = command.Parameters["P_PASSWORD_EXPIRED"].Value.ToString(),
                        P_PASSWORD_EXPIRED_MSG = command.Parameters["P_PASSWORD_EXPIRED_MSG"].Value.ToString(),
                        P_INVALID_LOGINS_MSG = command.Parameters["P_INVALID_LOGINS_MSG"].Value.ToString(),
                        P_RETURN_STATUS = command.Parameters["P_RETURN_STATUS"].Value.ToString(),
                        P_RETURN_MSG = command.Parameters["P_RETURN_MSG"].Value.ToString(),
                    };

                    if (result.P_RETURN_STATUS != "E")
                    {
                        result.P_SESSION_ID = ((Oracle.ManagedDataAccess.Types.OracleDecimal)sessionObject).Value;
                    }
                    conn.Close();
                    conn.Dispose();

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return ReturnException(ex);
                }
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
