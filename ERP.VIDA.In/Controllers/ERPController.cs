
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Data;
using System.Net;
using System.Threading.Tasks;
using Vida.DTO;
using Vida.Extenstion;
using Vida.Mapper;

namespace Vida.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ERPController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public ERPController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region Process Transactions
        [HttpPost("api/erp/ProcessTransactions.{format}"), FormatFilter]
        public async Task<IActionResult> ProcessTransactions([FromBody] ProcessTransactionsRequest request)
        {
            OracleConnection conn = new OracleConnection(_dbOption.DbConnection);

            IDataParameter[] parameters = new IDataParameter[15];

            // Inputs
            parameters[0] = new OracleParameter("@P_VIDA_ID", OracleDbType.Int32, request.P_VIDA_ID, ParameterDirection.Input);
            parameters[1] = new OracleParameter("@P_ORGANIZATION_CODE", OracleDbType.NVarchar2, request.P_ORGANIZATION_CODE, ParameterDirection.Input);
            parameters[2] = new OracleParameter("@P_SUBINVENTORY_CODE", OracleDbType.NVarchar2, request.P_SUBINVENTORY_CODE, ParameterDirection.Input);
            parameters[3] = new OracleParameter("@P_TRANSACTION_TYPE", OracleDbType.NVarchar2, request.P_TRANSACTION_TYPE, ParameterDirection.Input);
            parameters[4] = new OracleParameter("@P_TRANSACTION_DATE", OracleDbType.Date, request.P_TRANSACTION_DATE, ParameterDirection.Input);
            parameters[5] = new OracleParameter("@P_TRANSACTION_QUANTITY", OracleDbType.Int32, request.P_TRANSACTION_QUANTITY, ParameterDirection.Input);
            parameters[6] = new OracleParameter("@P_LOT_NUMBER", OracleDbType.NVarchar2, request.P_LOT_NUMBER, ParameterDirection.Input);
            parameters[7] = new OracleParameter("@P_COST_CENTER", OracleDbType.NVarchar2, request.P_COST_CENTER, ParameterDirection.Input);
            parameters[8] = new OracleParameter("@P_TRANSACTION_REFERENCE", OracleDbType.NVarchar2, request.P_TRANSACTION_REFERENCE, ParameterDirection.Input);
            parameters[9] = new OracleParameter("@P_LINE_NUMBER", OracleDbType.Int32, request.P_LINE_NUMBER, ParameterDirection.Input);
            parameters[10] = new OracleParameter("@P_ITEM_CODE", OracleDbType.NVarchar2, request.P_ITEM_CODE, ParameterDirection.Input);

            // XmlType input
            if (request.P_TRX_SERIALS_XML != null)
            {
                parameters[11] = new OracleParameter("@P_TRX_SERIALS_XML", OracleDbType.XmlType, request.P_TRX_SERIALS_XML.ToXML(), ParameterDirection.Input);
            }
            else
            {
                parameters[11] = new OracleParameter("@P_TRX_SERIALS_XML", OracleDbType.XmlType, null, ParameterDirection.Input);
            }

            // Outputs
            parameters[12] = new OracleParameter("@P_ORACLE_ID", OracleDbType.Int64, ParameterDirection.Output);
            parameters[13] = new OracleParameter("@P_RESPONSE_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
            parameters[14] = new OracleParameter("@P_RESPONSE_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

            using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
            {
                try
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var result = new ProcessTransactionsResponce()
                    {
                        P_ORACLE_ID = Convert.ToDecimal(((OracleDecimal)command.Parameters["@P_ORACLE_ID"].Value).Value),
                        P_RESPONSE_STATUS = command.Parameters["@P_RESPONSE_STATUS"].Value.ToString(),
                        P_RESPONSE_MSG = command.Parameters["@P_RESPONSE_MSG"].Value.ToString()
                    };

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