
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Threading.Tasks;
using Vida.DTO;
using Vida.Extenstion;
using Vida.Mapper;

namespace Vida.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
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
        [HttpPost("ProcessTransactions.{format}"), FormatFilter]
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

        #region Insert Booked Orders
        [HttpPost("InsertBookedOrdersInToStg.{format}"), FormatFilter]
        public async Task<IActionResult> InsertBookedOrdersInToStg([FromBody] InsertBookedOrdersInToStgRequest request)
        {
            OracleConnection conn = new OracleConnection(_dbOption.DbConnection);

            IDataParameter[] parameters = new IDataParameter[2];

            // Inputs
            parameters[0] = new OracleParameter("@P_BOOKED_ORDERS_XML", OracleDbType.XmlType, request.P_BOOKED_ORDERS_XML.To_BOOKED_ORDERSXML(), ParameterDirection.Input);
            // Outputs
            parameters[1] = new OracleParameter("@P_BOOKED_ORDERS_RESPONSE", OracleDbType.RefCursor, ParameterDirection.Output);

            using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
            {
                try
                {
                    conn.Open();
                    OracleDataReader objReader =  command.ExecuteReader();
                    List<InsertBookedOrdersInToStgResponce> OperatingUnitList = new List<InsertBookedOrdersInToStgResponce>();
                    OperatingUnitList = QueryExtenstion.DataReaderMapToList<InsertBookedOrdersInToStgResponce>(objReader);

                    objReader.Close();

                    conn.Close();
                    conn.Dispose();
                    //var isSuccess = await command.ExecuteNonQueryAsync();
                    //var result = new InsertBookedOrdersInToStgResponce()
                    //{
                    //    VIDA_ID = (Int32)command.Parameters["@VIDA_ID"].Value,
                    //    //USER_NAME = command.Parameters["@USER_NAME"].Value.ToString(),
                    //    //ORDER_NUMBER = command.Parameters["@ORDER_NUMBER"].Value.ToString(),
                    //    // ORDER_DATE = Convert.ToDateTime((command.Parameters["@ORDER_DATE"].Value)),
                    //    //LINE_NUMBER = command.Parameters["@LINE_NUMBER"].Value.ToString(),
                    //    //ITEM_CODE = command.Parameters["@ITEM_CODE"].Value.ToString(),
                    //    //QUANTITY = Convert.ToDecimal((OracleDecimal)(command.Parameters["@QUANTITY"].Value)),
                    //    //   NEED_BY_DATE = Convert.ToDateTime((OracleDate)(command.Parameters["@NEED_BY_DATE"].Value)),
                    //    //DEST_ORGANIZATION_CODE = command.Parameters["@DEST_ORGANIZATION_CODE"].Value.ToString(),
                    //    //DEST_SUBINVENTORY = command.Parameters["@DEST_SUBINVENTORY"].Value.ToString(),
                    //    //EXTENSION_NUMBER = command.Parameters["@EXTENSION_NUMBER"].Value.ToString(),
                    //    // ORACLE_ID = Convert.ToInt32((command.Parameters["@ORACLE_ID"].Value)),
                    //    //RESPONSE_STATUS = command.Parameters["@RESPONSE_STATUS"].Value.ToString(),
                    //    //RESPONSE_MSG = command.Parameters["@RESPONSE_MSG"].Value.ToString(),
                    //};

                    return Ok(OperatingUnitList);
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