using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Promotions_Portal_In.DTO;
using System;
using System.Data;
using System.Net;
using System.Threading.Tasks;

namespace Promotions_Portal_In.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class PromotionsPortalInController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public PromotionsPortalInController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region InsertGLJournalsIntoSTGA
        [HttpPost("InsertGLJournalsIntoSTG")]
        public async Task<IActionResult> InsertGLJournalsIntoSTG([FromBody] InsertGlJournalsIntoSTGRequest request)
        {
            try
            {
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                IDataParameter[] parameters = new IDataParameter[9];
               
                parameters[0] = new OracleParameter("P_PROMOTION_PACKAGE_ID", OracleDbType.Int32, 25, ParameterDirection.Input, false, 0, 0, "P_PROMOTION_PACKAGE_ID", DataRowVersion.Current, request.P_PROMOTION_PACKAGE_ID); // 
                parameters[1] = new OracleParameter("P_BATCH_NUMBER",OracleDbType.Varchar2,25 , ParameterDirection.Input,false, 0, 0, "P_BATCH_NUMBER", DataRowVersion.Current, request.P_BATCH_NUMBER);   //
                parameters[2] = new OracleParameter("P_JOURNAL_CATEGORY",OracleDbType.Varchar2, 25, ParameterDirection.Input, false, 0, 0, "P_JOURNAL_CATEGORY", DataRowVersion.Current, request.P_JOURNAL_CATEGORY); //
                parameters[3] = new OracleParameter("P_ACCOUNTING_DATE",OracleDbType.Date, 25, ParameterDirection.Input, false, 0, 0, "P_ACCOUNTING_DATE", DataRowVersion.Current, request.P_ACCOUNTING_DATE); //
                parameters[4] = new OracleParameter("P_LINE_AMOUNT", OracleDbType.Double, 25, ParameterDirection.Input, false, 0, 0, "P_LINE_AMOUNT", DataRowVersion.Current, request.P_LINE_AMOUNT); //
                parameters[5] = new OracleParameter("P_REVENUE_CATEGORY",OracleDbType.Varchar2, 25, ParameterDirection.Input, false, 0, 0, "P_REVENUE_CATEGORY", DataRowVersion.Current, request.P_REVENUE_CATEGORY);

                // Outputs
                parameters[6] = new OracleParameter("P_ORACLE_ID", OracleDbType.Int64, ParameterDirection.Output);
                parameters[7] = new OracleParameter("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                parameters[8] = new OracleParameter("P_RETURN_MESSAGE", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

                using (OracleCommand command = Extenstion.QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
                {

                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var result = new InsertGlJournalsIntoSTGResponse()
                    {
                        P_ORACLE_ID = Convert.ToDecimal(((OracleDecimal)command.Parameters["P_ORACLE_ID"].Value).Value),
                        P_RETURN_STATUS = command.Parameters["P_RETURN_STATUS"].Value.ToString(),
                        P_RETURN_MESSAGE = command.Parameters["P_RETURN_MESSAGE"].Value.ToString()
                    };

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