using elevatus_in.DTO;
using elevatus_in.Extenstion;
using elevatus_in.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;
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
                IDataParameter[] parameters = new IDataParameter[9];

                parameters[0] = new OracleParameter("P_USER_NAME", OracleDbType.Varchar2, 25, ParameterDirection.Input, false, 0, 0, "P_USER_NAME", DataRowVersion.Current, request.P_USER_NAME); // 
                parameters[1] = new OracleParameter("P_PASSWORD", OracleDbType.Varchar2, 25, ParameterDirection.Input, false, 0, 0, "P_PASSWORD", DataRowVersion.Current, request.P_PASSWORD);   //
                parameters[2] = new OracleParameter("P_LANGUAGE", OracleDbType.Varchar2, 25, ParameterDirection.Input, false, 0, 0, "P_LANGUAGE", DataRowVersion.Current, request.P_LANGUAGE);   //
                // Outputs
                parameters[3] = new OracleParameter("P_MOBILE_NUMBER", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[4] = new OracleParameter("P_EMAIL_ADDRESS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[5] = new OracleParameter("P_PASSWORD_EXPIRED", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[6] = new OracleParameter("P_PASSWORD_EXPIRED_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[7] = new OracleParameter("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[8] = new OracleParameter("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
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

        #region Update Requisition  
        [HttpPost("UpdateRequisition.{format}")]
        public async Task<IActionResult> UpdateRequisition([FromBody] UpdateRequisitionRequest request)
        {
            try
            {
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                IDataParameter[] parameters = new IDataParameter[5];
                parameters[0] = new OracleParameter("P_POSITION_ID", OracleDbType.Int32, request.P_POSITION_ID, ParameterDirection.Input); // 
                parameters[1] = new OracleParameter("P_NUM_OF_REQUISITION", OracleDbType.Int32, request.P_NUM_OF_REQUISITION, ParameterDirection.Input);   //
                // outPut                                                                                                                                      // Outputs
                parameters[2] = new OracleParameter("P_ORACLE_ID", OracleDbType.Int64, ParameterDirection.Output);
                parameters[3] = new OracleParameter("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[4] = new OracleParameter("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var result = new UpdateRequisitionResponse()
                    {
                        P_ORACLE_ID = Convert.ToDecimal(((OracleDecimal)command.Parameters["P_ORACLE_ID"].Value).Value),
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

        #region Is Position Vacant 
        [HttpPost("IsPositionVacant.{format}")]
        public async Task<IActionResult> IsPositionVacant([FromBody] IsPositionVacantRequest request)
        {
            try
            {
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                IDataParameter[] parameters = new IDataParameter[2];
                parameters[0] = new OracleParameter("P_POSITION_ID", OracleDbType.Int32, request.P_POSITION_ID, ParameterDirection.Input); // 
                parameters[1] = new OracleParameter("P_VACANT_POSITION_FLAG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var result = new IsPositionVacantResponse()
                    {
                        P_VACANT_POSITION_FLAG = command.Parameters["P_VACANT_POSITION_FLAG"].Value.ToString(),
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

        #region Security
        [HttpPost("CreateSecurity.{format}")]
        public async Task<IActionResult> CreateSecurity([FromBody] CreateSecurityRequest request)
        {
            try
            {
                var result = new List<CrudSecurityResponse>();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                IDataParameter[] parameters = new IDataParameter[2];
                parameters[0] = new OracleParameter("P_SECURITY_DETAILS", OracleDbType.XmlType, request.ToXMLCreateSeurity(), ParameterDirection.Input);
                //                                                                                                                                         // Outputs
                parameters[1] = new OracleParameter("P_SECURITY_DETAILS_RESP", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var resultBase64 = command.Parameters["P_SECURITY_DETAILS_RESP"].Value.ToString();
                    byte[] byteArray = Convert.FromBase64String(resultBase64);
                    string jsonBack = Encoding.UTF8.GetString(byteArray);
                    result = JsonConvert.DeserializeObject<List<CrudSecurityResponse>>(jsonBack);
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

        [HttpPut("UpdateSecurity.{format}")]
        public async Task<IActionResult> UpdateSecurity([FromBody] UpdateSecurityRequest request)
        {
            try
            {
                var result = new List<CrudSecurityResponse>();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                IDataParameter[] parameters = new IDataParameter[2];
                parameters[0] = new OracleParameter("P_SECURITY_DETAILS", OracleDbType.XmlType, request.ToXMLUpdateSeurity(), ParameterDirection.Input);
                //                                                                                                                                         // Outputs
                parameters[1] = new OracleParameter("P_SECURITY_DETAILS_RESP", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var resultBase64 = command.Parameters["P_SECURITY_DETAILS_RESP"].Value.ToString();
                    byte[] byteArray = Convert.FromBase64String(resultBase64);
                    string jsonBack = Encoding.UTF8.GetString(byteArray);
                    result = JsonConvert.DeserializeObject<List<CrudSecurityResponse>>(jsonBack);
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

        [HttpDelete("DeleteSecurity.{format}")]
        public async Task<IActionResult> DeleteSecurity([FromBody] DeleteSecurityRequest request)
        {
            try
            {
                var result = new List<CrudSecurityResponse>();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                IDataParameter[] parameters = new IDataParameter[2];
                parameters[0] = new OracleParameter("P_SECURITY_DETAILS", OracleDbType.XmlType, request.ToXMLDeleteSeurity(), ParameterDirection.Input);
                //                                                                                                                                         // Outputs
                parameters[1] = new OracleParameter("P_SECURITY_DETAILS_RESP", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var resultBase64 = command.Parameters["P_SECURITY_DETAILS_RESP"].Value.ToString();
                    byte[] byteArray = Convert.FromBase64String(resultBase64);
                    string jsonBack = Encoding.UTF8.GetString(byteArray);
                    result = JsonConvert.DeserializeObject<List<CrudSecurityResponse>>(jsonBack);
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

        #region Create Applicant
        [HttpPost("CreateApplicant.{format}"), FormatFilter]
        public async Task<IActionResult> CreateApplicant([FromBody] CreateApplicantRequest request)
        {
            OracleConnection conn = new OracleConnection(_dbOption.DbConection);

            IDataParameter[] parameters = new IDataParameter[4];

            // Inputs

            // XmlType input
            if (request.P_APPLICANT_DETAILS != null)
            {
                parameters[0] = new OracleParameter("P_APPLICANT_DETAILS", OracleDbType.XmlType, request.P_APPLICANT_DETAILS.ToXML(), ParameterDirection.Input);
            }
            else
            {
                parameters[0] = new OracleParameter("P_APPLICANT_DETAILS", OracleDbType.XmlType, null, ParameterDirection.Input);
            }

            // Outputs
            parameters[1] = new OracleParameter("P_ORACLE_ID", OracleDbType.Int64, ParameterDirection.Output);
            parameters[2] = new OracleParameter("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
            parameters[3] = new OracleParameter("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

            using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
            {
                try
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var result = new CreateApplicantResponce()
                    {
                        P_ORACLE_ID = Convert.ToDecimal(((OracleDecimal)command.Parameters["P_ORACLE_ID"].Value).Value),
                        P_RETURN_STATUS = command.Parameters["P_RETURN_STATUS"].Value.ToString(),
                        P_RETURN_MSG = command.Parameters["P_RETURN_MSG"].Value.ToString()
                    };
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

        #region Validate Offer  
        [HttpPost("ValidateOffer.{format}")]
        public async Task<IActionResult> ValidateOffer([FromBody] ValidateOfferRequest request)
        {
            try
            {
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                var result = new ValidateOfferResponse();
                IDataParameter[] parameters = new IDataParameter[4];
                var base64Obj = QueryExtenstion.ObjectToBase64(request);
                parameters[0] = new OracleParameter("P_OFFER_FILE_REQUEST", OracleDbType.Varchar2, 32767, ParameterDirection.Input, false, 0, 0, "P_OFFER_FILE_REQUEST", DataRowVersion.Current, base64Obj); // 
                // Outputs
                parameters[1] = new OracleParameter("P_OFFER_FILE_RESPONSE", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[2] = new OracleParameter("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[3] = new OracleParameter("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var resultBase64 = command.Parameters["P_OFFER_FILE_RESPONSE"].Value.ToString();
                    byte[] byteArray = Convert.FromBase64String(resultBase64);
                    string jsonBack = Encoding.UTF8.GetString(byteArray);
                    result = JsonConvert.DeserializeObject<ValidateOfferResponse>(jsonBack);

                    // ValidateOfferResponse
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