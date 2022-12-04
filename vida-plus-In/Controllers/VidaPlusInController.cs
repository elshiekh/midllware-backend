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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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



        //ProcessTransaction
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
                cmd.Parameters.Add(new OracleParameter("P_ORGANIZATION_CODE", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.organization_code;
                cmd.Parameters.Add(new OracleParameter("P_SUBINVENTORY_CODE", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.subinventory_code;
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_TYPE_NAME", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.transaction_type_name;
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_DATE", OracleDbType.Date, ParameterDirection.Input)).Value = requestList.transaction_date;
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_QUANTITY", OracleDbType.Int64, ParameterDirection.Input)).Value = requestList.transaction_quantity;
                cmd.Parameters.Add(new OracleParameter("P_LOT_NUMBER", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.lot_number;
                cmd.Parameters.Add(new OracleParameter("P_COST_CENTER", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.cost_center;
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_REFERENCE", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.transaction_reference;
                cmd.Parameters.Add(new OracleParameter("P_LINE_NUMBER", OracleDbType.Int64, ParameterDirection.Input)).Value = requestList.line_number;
                cmd.Parameters.Add(new OracleParameter("P_ITEM_CODE", OracleDbType.NVarchar2, ParameterDirection.Input)).Value = requestList.item_code;
                cmd.Parameters.Add(new OracleParameter("P_TRX_SERIALS_XML", OracleDbType.XmlType, ParameterDirection.Input)).Value = requestList.trx_serials.ToXMLserials();


                cmd.Parameters.Add("P_ORACLE_ID", OracleDbType.Int64, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RESPONSE_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RESPONSE_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

                
                var isSuccess = await cmd.ExecuteNonQueryAsync();

                var result = new ProcessTransactionsResponce()
                {
                    P_ORACLE_ID = Convert.ToInt64(((OracleDecimal)cmd.Parameters["P_ORACLE_ID"].Value).Value),
                    P_RESPONSE_STATUS = cmd.Parameters["P_RESPONSE_STATUS"].Value.ToString(),
                    P_RESPONSE_MSG = cmd.Parameters["P_RESPONSE_MSG"].Value.ToString()
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
        #endregion


        //InsertArCustIntoStg
        #region InsertArCustIntoStg
        [HttpPost("InsertArCustIntoStg.{format}")]
        public async Task<IActionResult> InsertArCustIntoStg([FromBody] InsertArCustIntoStgRequest requestList)
        {
            try
            {
                InsertArCustIntoStgRequest request = new InsertArCustIntoStgRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_STAGES_TRANSACTION_DETAILS", OracleDbType.XmlType, ParameterDirection.Input)).Value = requestList.ToXMLInsertArCustIntoStg();


                cmd.Parameters.Add("P_STAGES_TRANSACTION_STATUS", OracleDbType.RefCursor, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

                //OracleDataAdapter ad = new OracleDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);

                OracleDataReader reader = cmd.ExecuteReader();

                List<InsertArCustIntoStgResponce> InsertArCustIntoStgList = new List<InsertArCustIntoStgResponce>();
                InsertArCustIntoStgList = QueryExtenstion.DataReaderMapToList<InsertArCustIntoStgResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(InsertArCustIntoStgList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        //InsertArInvIntoStg
        #region InsertArInvIntoStg
        [HttpPost("InsertArInvIntoStg.{format}")]
        public async Task<IActionResult> InsertArInvIntoStg([FromBody] InsertArInvIntoStgRequest requestList)
        {
            try
            {
                InsertArInvIntoStgRequest request = new InsertArInvIntoStgRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_STAGES_TRANSACTION_DETAILS", OracleDbType.XmlType, ParameterDirection.Input)).Value = requestList.ToXMLInsertArInvIntoStg();


                cmd.Parameters.Add("P_STAGES_TRANSACTION_STATUS", OracleDbType.RefCursor, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

                //OracleDataAdapter ad = new OracleDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);

                OracleDataReader reader = cmd.ExecuteReader();

                List<InsertArInvIntoStgResponce> InsertArInvIntoStgList = new List<InsertArInvIntoStgResponce>();
                InsertArInvIntoStgList = QueryExtenstion.DataReaderMapToList<InsertArInvIntoStgResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(InsertArInvIntoStgList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        //InsertGlJournalsIntoStg
        #region InsertGlJournalsIntoStg
        [HttpPost("InsertGlJournalsIntoStg.{format}")]
        public async Task<IActionResult> InsertGlJournalsIntoStg([FromBody] InsertGlJournalsIntoStgRequest requestList)
        {
            try
            {
                //requestList.InsertStageDate = requestList.InsertStageDate.Da.ToString("yyyy-MM-dd");
                InsertGlJournalsIntoStgRequest request = new InsertGlJournalsIntoStgRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_STAGES_TRANSACTION_DETAILS", OracleDbType.XmlType, ParameterDirection.Input)).Value = requestList.ToXMLInsertGlJournalsIntoStg();

                cmd.Parameters.Add("P_STAGES_TRANSACTION_STATUS", OracleDbType.RefCursor, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

                //OracleDataAdapter ad = new OracleDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);

                OracleDataReader reader = cmd.ExecuteReader();

                List<InsertGlJournalsIntoStgResponce> InsertGlJournalsIntoStgList = new List<InsertGlJournalsIntoStgResponce>();
                InsertGlJournalsIntoStgList = QueryExtenstion.DataReaderMapToList<InsertGlJournalsIntoStgResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(InsertGlJournalsIntoStgList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        //InsertOffersIntoStg
        #region InsertOffersIntoStg
        [HttpPost("InsertOffersIntoStg.{format}")]
        public async Task<IActionResult> InsertOffersIntoStg([FromBody] InsertOffersIntoStgRequest requestList)
        {
            try
            {
                InsertOffersIntoStgRequest request = new InsertOffersIntoStgRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_STAGES_TRANSACTION_DETAILS", OracleDbType.XmlType, ParameterDirection.Input)).Value = requestList.ToXMLInsertOffersIntoStg();


                cmd.Parameters.Add("P_STAGES_TRANSACTION_STATUS", OracleDbType.RefCursor, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

                //OracleDataAdapter ad = new OracleDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);

                OracleDataReader reader = cmd.ExecuteReader();

                List<InsertOffersIntoStgResponce> InsertOffersIntoStgList = new List<InsertOffersIntoStgResponce>();
                InsertOffersIntoStgList = QueryExtenstion.DataReaderMapToList<InsertOffersIntoStgResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(InsertOffersIntoStgList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        //InsertApInvIntoStg
        #region InsertApInvIntoStg
        [HttpPost("InsertApInvIntoStg.{format}")]
        public async Task<IActionResult> InsertApInvIntoStg([FromBody] InsertApInvIntoStgRequest requestList)
        {
            try
            {
                InsertApInvIntoStgRequest request = new InsertApInvIntoStgRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_STAGE_AP_TRANSACTION_DETAILS", OracleDbType.XmlType, ParameterDirection.Input)).Value = requestList.ToXMLInsertApInvIntoStg();


                cmd.Parameters.Add("P_STAGE_AP_TRANSACTION_STATUS", OracleDbType.RefCursor, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

                //OracleDataAdapter ad = new OracleDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);

                OracleDataReader reader = cmd.ExecuteReader();

                List<InsertApInvIntoStgResponce> InsertApInvIntoStgList = new List<InsertApInvIntoStgResponce>();
                InsertApInvIntoStgList = QueryExtenstion.DataReaderMapToList<InsertApInvIntoStgResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(InsertApInvIntoStgList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        //AjajiInsertArInvIntoStg
        #region AjajiInsertArInvIntoStg
        [HttpPost("AjajiInsertArInvIntoStg.{format}")]
        public async Task<IActionResult> AjajiInsertArInvIntoStg([FromBody] AjajiInsertArInvIntoStgRequest requestList)
        {
            try
            {
                AjajiInsertArInvIntoStgRequest request = new AjajiInsertArInvIntoStgRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_STAGES_TRANSACTION_DETAILS", OracleDbType.XmlType, ParameterDirection.Input)).Value = requestList.ToXMLAjajiInsertArInvIntoStg();


                cmd.Parameters.Add("P_STAGES_TRANSACTION_STATUS", OracleDbType.RefCursor, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

                //OracleDataAdapter ad = new OracleDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);

                OracleDataReader reader = cmd.ExecuteReader();

                List<AjajiInsertArInvIntoStgResponce> AjajiInsertArInvIntoStgList = new List<AjajiInsertArInvIntoStgResponce>();
                AjajiInsertArInvIntoStgList = QueryExtenstion.DataReaderMapToList<AjajiInsertArInvIntoStgResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(AjajiInsertArInvIntoStgList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        //InsertArRecIntoStg
        #region InsertArRecIntoStg
        [HttpPost("InsertArRecIntoStg.{format}")]
        public async Task<IActionResult> InsertArRecIntoStg([FromBody] InsertArRecIntoStgRequest requestList)
        {
            try
            {
                InsertArRecIntoStgRequest request = new InsertArRecIntoStgRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_STAGES_TRANSACTION_DETAILS", OracleDbType.XmlType, ParameterDirection.Input)).Value = requestList.ToXMLInsertArRecIntoStg();


                cmd.Parameters.Add("P_STAGES_TRANSACTION_STATUS", OracleDbType.RefCursor, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);

                //OracleDataAdapter ad = new OracleDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);

                OracleDataReader reader = cmd.ExecuteReader();

                List<InsertArRecIntoStgResponce> InsertArRecIntoStgList = new List<InsertArRecIntoStgResponce>();
                InsertArRecIntoStgList = QueryExtenstion.DataReaderMapToList<InsertArRecIntoStgResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(InsertArRecIntoStgList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        //GetEmployeeInfo
        #region Get EmployeeInfo
        [HttpPost("GetEmployeeInfo.{format}")]
        public async Task<IActionResult> GetEmployeeInfo(string EMPLOYEE_NUMBER)
        {
            try
            {
                GetEmployeeInfoRequest request = new GetEmployeeInfoRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_EMPLOYEE_NUMBER", OracleDbType.Varchar2)).Value = EMPLOYEE_NUMBER;
                cmd.Parameters.Add("P_EMPLOYEE_INFORMATION", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);


                OracleDataReader reader = cmd.ExecuteReader();

                var EmployeeDetailsList = new GetEmployeeInfoResponce()
                {
                    P_EMPLOYEE_INFORMATION = cmd.Parameters["P_EMPLOYEE_INFORMATION"].Value.ToString(),
                    P_RETURN_STATUS = cmd.Parameters["P_RETURN_STATUS"].Value.ToString(),
                    P_RETURN_MSG = cmd.Parameters["P_RETURN_MSG"].Value.ToString(),
                };


                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(EmployeeDetailsList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        //InsertDeduction
        #region InsertDeduction
        [HttpPost("InsertDeduction.{format}")]
        public async Task<IActionResult> InsertDeduction([FromBody] InsertDeductionRequest requestList)
        {
            try
            {
                InsertDeductionRequest request = new InsertDeductionRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);
                 
                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_VIDAPLUS_ID", OracleDbType.Int64, ParameterDirection.Input)).Value = requestList.VidaPlusId;
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_TYPE", OracleDbType.Varchar2, ParameterDirection.Input)).Value = requestList.transaction_type;
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_DATE", OracleDbType.Date, ParameterDirection.Input)).Value = requestList.transaction_date;
                cmd.Parameters.Add(new OracleParameter("P_EMPLOYEE_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input)).Value = requestList.employee_number;
                cmd.Parameters.Add(new OracleParameter("P_PATIENT_CIVIL_ID", OracleDbType.Int64, ParameterDirection.Input)).Value = requestList.patient_civil_id;
                cmd.Parameters.Add(new OracleParameter("P_INVOICE_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input)).Value = requestList.invoice_number;
                cmd.Parameters.Add(new OracleParameter("P_INVOICE_AMOUNT", OracleDbType.Int64, ParameterDirection.Input)).Value = requestList.invoice_amount;
                cmd.Parameters.Add(new OracleParameter("P_PATIENT_ID", OracleDbType.Int64, ParameterDirection.Input)).Value = requestList.patient_id;
                cmd.Parameters.Add(new OracleParameter("P_PATIENT_NAME", OracleDbType.Varchar2, ParameterDirection.Input)).Value = requestList.patient_name;
                cmd.Parameters.Add(new OracleParameter("P_HIS_USER", OracleDbType.Varchar2, ParameterDirection.Input)).Value = requestList.his_user;
                cmd.Parameters.Add(new OracleParameter("P_HIS_PROJECT", OracleDbType.Varchar2, ParameterDirection.Input)).Value = requestList.his_project;


                cmd.Parameters.Add("P_ORACLE_ID", OracleDbType.Int64, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RESPONSE_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RESPONSE_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);


                var isSuccess = await cmd.ExecuteNonQueryAsync();

                var result = new InsertDeductionResponce()
                {
                    ORACLE_ID = Convert.ToDecimal(((OracleDecimal)cmd.Parameters["P_ORACLE_ID"].Value).Value),
                    RESPONSE_STATUS = cmd.Parameters["P_RESPONSE_STATUS"].Value.ToString(),
                    RESPONSE_MSG = cmd.Parameters["P_RESPONSE_MSG"].Value.ToString()
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
        #endregion


        //ValidateDeduction
        #region ValidateDeduction
        [HttpPost("ValidateDeduction.{format}")]
        public async Task<IActionResult> ValidateDeduction([FromBody] ValidateDeductionRequest requestList)
        {
            try
            {
                ValidateDeductionRequest request = new ValidateDeductionRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_EMPLOYEE_NUMBER", OracleDbType.Varchar2, ParameterDirection.Input)).Value = requestList.employee_number;
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_DATE", OracleDbType.Date, ParameterDirection.Input)).Value = requestList.transaction_date;
                cmd.Parameters.Add(new OracleParameter("P_INVOICE_AMOUNT", OracleDbType.Int64, ParameterDirection.Input)).Value = requestList.invoice_amount;
                cmd.Parameters.Add(new OracleParameter("P_PATIENT_CIVIL_ID", OracleDbType.Int64, ParameterDirection.Input)).Value = requestList.patient_civil_id;


                cmd.Parameters.Add("P_RESPONSE_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RESPONSE_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);


                var isSuccess = await cmd.ExecuteNonQueryAsync();

                var result = new ValidateDeductionResponce()
                {
                    RESPONSE_STATUS = cmd.Parameters["P_RESPONSE_STATUS"].Value.ToString(),
                    RESPONSE_MSG = cmd.Parameters["P_RESPONSE_MSG"].Value.ToString()
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