using elevatus_in.DTO;
using elevatus_in.Extenstion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Net;
using System.Threading.Tasks;

namespace elevatus_in.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class ElevatusInController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public ElevatusInController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region VALIDATE_LOGIN  
        [HttpPost("ValidateLogin.{format}")]
        public async Task<IActionResult> ValidateLogin([FromBody] ValidateLoginRequest request)
        {
            try
            {
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                IDataParameter[] parameters = new IDataParameter[8];

                parameters[0] = new OracleParameter("P_USER_NAME", OracleDbType.Varchar2, 25, ParameterDirection.Input, false, 0, 0, "P_USER_NAME", DataRowVersion.Current, request.P_USER_NAME); // 
                parameters[1] = new OracleParameter("P_PASSWORD", OracleDbType.Varchar2, 25, ParameterDirection.Input, false, 0, 0, "P_PASSWORD", DataRowVersion.Current, request.P_PASSWORD);   //
                // Outputs
                parameters[2] = new OracleParameter("P_MOBILE_NUMBER", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[3] = new OracleParameter("P_EMAIL_ADDRESS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[4] = new OracleParameter("P_PASSWORD_EXPIRED", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[5] = new OracleParameter("P_PASSWORD_EXPIRED_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[6] = new OracleParameter("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[7] = new OracleParameter("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var result = new ValidateLoginResponse()
                    {
                        P_MOBILE_NUMBER = command.Parameters["P_MOBILE_NUMBER"].Value.ToString(),
                        P_EMAIL_ADDRESS = command.Parameters["P_EMAIL_ADDRESS"].Value.ToString(),
                        P_PASSWORD_EXPIRED = command.Parameters["P_PASSWORD_EXPIRED"].Value.ToString(),
                        P_PASSWORD_EXPIRED_MSG = command.Parameters["P_PASSWORD_EXPIRED_MSG"].Value.ToString(),
                        P_RETURN_MSG = command.Parameters["P_RETURN_MSG"].Value.ToString(),
                        P_RETURN_STATUS = command.Parameters["P_RETURN_STATUS"].Value.ToString(),
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