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
using vida_plus_In.DTO;
using vida_plus_In.Mapper;
using vida_plus_In.Extenstion;
using Oracle.ManagedDataAccess.Types;

namespace vida_plus_In.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class VidaPlusInController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public VidaPlusInController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion


        #region ProcessTransaction
        [HttpPost("ProcessTransaction.{format}")]
        public async Task<IActionResult> ProcessTransaction([FromBody] ProcessTransactionRequest requestList)
        {
            try
            {
                ProcessTransactionRequest request = new ProcessTransactionRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_VIDAPLUS_ID", OracleDbType.Int64, ParameterDirection.Input)).Value = requestList.vidaPlus_id;
                cmd.Parameters.Add(new OracleParameter("P_ORGANIZATION_CODE", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.organaization_code;
                cmd.Parameters.Add(new OracleParameter("P_SUBINVENTORY_CODE", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.subinventory_code;
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_TYPE_NAME", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.transaction_type;
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_DATE", OracleDbType.Date, ParameterDirection.Input)).Value = requestList.transaction_date;
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_QUANTITY", OracleDbType.Int64, ParameterDirection.Input)).Value = requestList.transaction_quantity;
                cmd.Parameters.Add(new OracleParameter("P_LOT_NUMBER", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.lot_number;
                cmd.Parameters.Add(new OracleParameter("P_COST_CENTER", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.cost_center;
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_REFERENCE", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.transaction_referance;
                cmd.Parameters.Add(new OracleParameter("P_LINE_NUMBER", OracleDbType.Int64, ParameterDirection.Input)).Value = requestList.line_number;
                cmd.Parameters.Add(new OracleParameter("P_ITEM_CODE", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.item_code;
                cmd.Parameters.Add(new OracleParameter("P_TRX_SERIALS_XML", OracleDbType.XmlType, ParameterDirection.Input)).Value = requestList.trx_serials_xml.ToXMLserials();


                cmd.Parameters.Add("P_ORACLE_ID", OracleDbType.Int64, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RESPONSE_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RESPONSE_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

                OracleDataAdapter ad = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);

                OracleDataReader reader = cmd.ExecuteReader();

                List<ProcessTransactionsResponce> InsertTransactionDetailsList = new List<ProcessTransactionsResponce>();
                InsertTransactionDetailsList = QueryExtenstion.DataReaderMapToList<ProcessTransactionsResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(InsertTransactionDetailsList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        #region InsertStageData
        [HttpPost("InsertStageData.{format}")]
        public async Task<IActionResult> InsertStageData([FromBody] InsertStageDataRequest requestList)
        {
            try
            {
                //requestList.InsertStageDate = requestList.InsertStageDate.Da.ToString("yyyy-MM-dd");
                InsertStageDataRequest request = new InsertStageDataRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_STAGES_TRANSACTION_DETAILS", OracleDbType.XmlType, ParameterDirection.Input)).Value = requestList.ToXMLInsertStageData();

                cmd.Parameters.Add("P_STAGES_TRANSACTION_STATUS", OracleDbType.RefCursor, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

                //OracleDataAdapter ad = new OracleDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);

                OracleDataReader reader = cmd.ExecuteReader();

                List<InsertStageDataResponce> InsertStageDataList = new List<InsertStageDataResponce>();
                InsertStageDataList = QueryExtenstion.DataReaderMapToList<InsertStageDataResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(InsertStageDataList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        #region InsertStageDataOffer
        [HttpPost("InsertStageDataOffer.{format}")]
        public async Task<IActionResult> InsertStageDataOffer([FromBody] InsertStageDataOfferRequest requestList)
        {
            try
            {
                InsertStageDataOfferRequest request = new InsertStageDataOfferRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_STAGES_TRANSACTION_DETAILS", OracleDbType.XmlType, ParameterDirection.Input)).Value = requestList.ToXMLInsertStageDataOffer();


                cmd.Parameters.Add("P_STAGE_TRANSACTION_STATUS", OracleDbType.RefCursor, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

                //OracleDataAdapter ad = new OracleDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);

                OracleDataReader reader = cmd.ExecuteReader();

                List<InsertStageDataOfferResponce> InsertStageDataOfferList = new List<InsertStageDataOfferResponce>();
                InsertStageDataOfferList = QueryExtenstion.DataReaderMapToList<InsertStageDataOfferResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(InsertStageDataOfferList);
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