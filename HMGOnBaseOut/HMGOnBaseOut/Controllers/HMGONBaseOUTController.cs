using HMGONBaseController.DTO;
using HMGOnBaseOut.DTO;
using HMGOnBaseOut.Extenstion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace HMGOnBaseOut.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [FormatFilter]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class HMGONBaseOUTController : ControllerBase
    {
        private readonly DBOption _dbOption;
        public HMGONBaseOUTController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }

        // GetSuppliers
        [HttpGet("api/HMGONBASE/GetSuppliers.{format}")]
        [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any)]
        public IActionResult GetSuppliers()
        {
            try
            {
                GetSuppliersRequest request = new GetSuppliersRequest();
                // Command text for getting the REF Cursor as OUT parameter
                String cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetSuppliersResponse> supplierList = new List<GetSuppliersResponse>();
                supplierList = QueryExtenstion.DataReaderMapToList<GetSuppliersResponse>(reader);

                reader.Close();

                return Ok(supplierList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GetSupplierNumber----------------------------------
        [HttpGet("api/HMGONBASE/GetSupplierNumber.{format}")]
        public IActionResult GetSupplierNumber(string P_SUPPLIER_NAME)
        {
            try
            {
                GetSupplierNumberRequest request = new GetSupplierNumberRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_SUPPLIER_NAME)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_SUPPLIER_NAME", P_SUPPLIER_NAME);
                OracleDataReader reader = cmd.ExecuteReader();
                GetSupplierNumberResponse supplierNumber = new GetSupplierNumberResponse();
                while (reader.Read())
                {
                    supplierNumber = reader.ConvertToObject<GetSupplierNumberResponse>();
                }
                reader.Close();

                return Ok(supplierNumber);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GetAPEmployeeInfo----------------------------------
        [HttpGet("api/HMGONBASE/GetAPEmployeeInfo.{format}")]
        public IActionResult GetAPEmployeeInfo(string P_EMPLOYEE_NUMBER)
        {
            try
            {
                GetAPEmployeeInfoResquest request = new GetAPEmployeeInfoResquest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_EMPLOYEE_NUMBER)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_EMPLOYEE_NUMBER", P_EMPLOYEE_NUMBER);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetAPEmployeeInfoResponse> employeeInfoList = new List<GetAPEmployeeInfoResponse>();
                employeeInfoList = QueryExtenstion.DataReaderMapToList<GetAPEmployeeInfoResponse>(reader);
                reader.Close();

                return Ok(employeeInfoList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GetPOEmployeeInfo----------------------------------
        [HttpGet("api/HMGONBASE/GetPOEmployeeInfo.{format}")]
        public IActionResult GetPOEmployeeInfo(string P_EMPLOYEE_NUMBER)
        {
            try
            {
                GetPOEmployeeInfoResquest request = new GetPOEmployeeInfoResquest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_EMPLOYEE_NUMBER)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_EMPLOYEE_NUMBER", P_EMPLOYEE_NUMBER);
                OracleDataReader reader = cmd.ExecuteReader();
                GetPOEmployeeInfoResponse getPOEmployeeInfo = new GetPOEmployeeInfoResponse();
                while (reader.Read())
                {
                    getPOEmployeeInfo = reader.ConvertToObject<GetPOEmployeeInfoResponse>();
                }
                reader.Close();

                return Ok(getPOEmployeeInfo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GetItemName
        [HttpGet("api/HMGONBASE/GETITEMNAME.{format}")]
        public IActionResult GETITEMNAME(string P_ITEM_NAME)
        {
            try
            {
                GetItemNameRequest request = new GetItemNameRequest();
                // Command text for getting the REF Cursor as OUT parameter
                String cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName()  + "(:P_ITEM_NAME)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_ITEM_NAME", P_ITEM_NAME);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetItemNameResponse> employeeInfoList = new List<GetItemNameResponse>();
                employeeInfoList = QueryExtenstion.DataReaderMapToList<GetItemNameResponse>(reader);

                reader.Close();

                return Ok(employeeInfoList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GetItemCode ----------------------------------
        [HttpGet("api/HMGONBASE/GetItemCode.{format}")]
        public IActionResult GetItemCode(string P_ITEM_NAME)
        {
            try
            {
                GetItemCodeRequest request = new GetItemCodeRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_ITEM_NAME)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_ITEM_NAME", P_ITEM_NAME);
                OracleDataReader reader = cmd.ExecuteReader();
                GetItemCodeResponse ItemCode = new GetItemCodeResponse();
                while (reader.Read())
                {
                    ItemCode = reader.ConvertToObject<GetItemCodeResponse>();
                }
                reader.Close();

                return Ok(ItemCode);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GetPositionTitle-----------
        [HttpGet("api/HMGONBASE/GetPositionTitle.{format}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public IActionResult GetPositionTitle()
        {
            try
            {
                GetPositionTitleRequest request = new GetPositionTitleRequest();
                // Command text for getting the REF Cursor as OUT parameter
                String cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1", OracleDbType.RefCursor, ParameterDirection.Output);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetPositionTitleResponse> getPositionTitleList = new List<GetPositionTitleResponse>();
                getPositionTitleList = QueryExtenstion.DataReaderMapToList<GetPositionTitleResponse>(reader);
                reader.Close();

                return Ok(getPositionTitleList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GetBusinessGroup ----------
        [HttpGet("api/HMGONBASE/GetBusinessGroup.{format}")]
        public IActionResult GetBusinessGroup()
        {
            try
            {
                GetBusinessGroupRequest request = new GetBusinessGroupRequest();
                // Command text for getting the REF Cursor as OUT parameter
                String cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);
                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetBusinessGroupResponse> getBusinessGroupList = new List<GetBusinessGroupResponse>();
                getBusinessGroupList = QueryExtenstion.DataReaderMapToList<GetBusinessGroupResponse>(reader);
                reader.Close();

                return Ok(getBusinessGroupList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GetHrEmployeeInfo ----------------------------------
        [HttpGet("api/HMGONBASE/GetHrEmployeeInfo.{format}")]
        public IActionResult GetHrEmployeeInfo(string P_EMPLOYEE_NUMBER)
        {
            try
            {
                GetHrEmployeeInfoResquest request = new GetHrEmployeeInfoResquest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_EMPLOYEE_NUMBER)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_EMPLOYEE_NUMBER", P_EMPLOYEE_NUMBER);
                OracleDataReader reader = cmd.ExecuteReader();
                GetHrEmployeeInfoResponse getHrEmployeeInfoResponse = new GetHrEmployeeInfoResponse();
                while (reader.Read())
                {
                    getHrEmployeeInfoResponse = reader.ConvertToObject<GetHrEmployeeInfoResponse>();
                }
                reader.Close();

                return Ok(getHrEmployeeInfoResponse);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //GetEngineerName ----------------------------------
        [HttpGet("api/HMGONBASE/GetEngineerName.{format}")]
        public IActionResult GetEngineerName(string P_ENGINEER_NUMBER)
        {
            try
            {
                GetEngineerNameRequest request = new GetEngineerNameRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_ENGINEER_NUMBER)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);
                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_ENGINEER_NUMBER", P_ENGINEER_NUMBER);
                OracleDataReader reader = cmd.ExecuteReader();
                GetEngineerNameResponse getEngineerName = new GetEngineerNameResponse();
                while (reader.Read())
                {
                    getEngineerName = reader.ConvertToObject<GetEngineerNameResponse>();
                }
                reader.Close();

                return Ok(getEngineerName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}