using HMGONBaseController.DTO;
using HMGOnBaseOut.DTO;
using HMGOnBaseOut.Extenstion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace HMGOnBaseOut.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    [FormatFilter]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class HMGONBaseOUTController : ControllerBase
    {
        private readonly DBOption _dbOption;
        private readonly IMemoryCache _mCache;
        public HMGONBaseOUTController(DBOption dbOption, IMemoryCache mCache)
        {
            _dbOption = dbOption;
            _mCache = mCache;
        }

        // GetSuppliers
        [HttpGet("api/HMGONBASE/GetSuppliers.{format}")]
        // [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any)]
        public IActionResult GetSuppliers(int? P_SUPPLIER_NUMBER)
        {
            try
            {
                GetSuppliersRequest request = new GetSuppliersRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_SUPPLIER_NUMBER)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_SUPPLIER_NUMBER", P_SUPPLIER_NUMBER);
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
                List<GetSupplierNumberResponse> supplierNumberList = new List<GetSupplierNumberResponse>();
                supplierNumberList = QueryExtenstion.DataReaderMapToList<GetSupplierNumberResponse>(reader);

                reader.Close();

                return Ok(supplierNumberList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GetItemName
        [HttpGet("api/HMGONBASE/GetItemName.{format}")]
        public IActionResult GetItemName(string P_ITEM_CODE)
        {
            try
            {
                GetItemNameRequest request = new GetItemNameRequest();
                // Command text for getting the REF Cursor as OUT parameter
                String cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_ITEM_CODE)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_ITEM_CODE", P_ITEM_CODE);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetItemNameResponse> itemCodeList = new List<GetItemNameResponse>();
                itemCodeList = QueryExtenstion.DataReaderMapToList<GetItemNameResponse>(reader);

                reader.Close();

                return Ok(itemCodeList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GetItemCode ----------------------------------
        [HttpGet("api/HMGONBASE/GetItemCode.{format}")]
        public IActionResult GetItemCode(string P_ITEM_DESC)
        {
            try
            {
                GetItemCodeRequest request = new GetItemCodeRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_ITEM_DESC)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_ITEM_DESC", P_ITEM_DESC);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetItemCodeResponse> itemCodeList = new List<GetItemCodeResponse>();
                itemCodeList = QueryExtenstion.DataReaderMapToList<GetItemCodeResponse>(reader);

                reader.Close();

                return Ok(itemCodeList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GetPositionTitle-----------
        [HttpGet("api/HMGONBASE/GetPositionTitle.{format}")]
        //[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public IActionResult GetPositionTitle(string P_BUSINESS_GROUP_NAME)
        {
            try
            {
                GetPositionTitleRequest request = new GetPositionTitleRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_BUSINESS_GROUP_NAME)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_BUSINESS_GROUP_NAME", P_BUSINESS_GROUP_NAME);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetPositionTitleResponse> getPositionTitleList = new List<GetPositionTitleResponse>();
                getPositionTitleList = QueryExtenstion.DataReaderMapToList<GetPositionTitleResponse>(reader);
                reader.Close();

                return Ok(getPositionTitleList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GetBusinessGroup ----------
        [HttpGet("api/HMGONBASE/GetBusinessGroup.{format}")]
        public IActionResult GetBusinessGroup(string P_BUSINESS_GROUP_NAME)
        {
            try
            {
                GetBusinessGroupRequest request = new GetBusinessGroupRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_BUSINESS_GROUP_NAME)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);
                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_BUSINESS_GROUP_NAME", P_BUSINESS_GROUP_NAME);
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
                List<GetHrEmployeeInfoResponse> getHrEmployeeInfoResponse = new List<GetHrEmployeeInfoResponse>();
                getHrEmployeeInfoResponse = QueryExtenstion.DataReaderMapToList<GetHrEmployeeInfoResponse>(reader);
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

        // GetHrRequiredDocument ----------------------------------
        [HttpGet("api/HMGONBASE/GetHrRequiredDocument.{format}")]
        public IActionResult GetHrRequiredDocument()
        {
            try
            {
                var cachRequest = new CacheHrRequiredDocumentRequest();
                List<GetHrRequiredDocumentResponse> value=null;
                _mCache.TryGetValue(cachRequest.GetKey(), out value);
                if (value == null)
                {
                    GetHrRequiredDocumentResquest request = new GetHrRequiredDocumentResquest();
                    // Command text for getting the REF Cursor as OUT parameter
                    string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "; end;";
                    OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                    conn.Open();
                    // Create the command object for executing cmdTxt1 and cmdTxt2
                    OracleCommand cmd = new OracleCommand(cmdTxt1, conn);
                    // Bind the Ref cursor to the PL/SQL stored procedure
                    OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                      OracleDbType.RefCursor, ParameterDirection.Output);
                    OracleDataReader reader = cmd.ExecuteReader();
                    List<GetHrRequiredDocumentResponse> getHrRequiredDocumentResponse = new List<GetHrRequiredDocumentResponse>();
                    getHrRequiredDocumentResponse = QueryExtenstion.CustomDataReaderMapToList<GetHrRequiredDocumentResponse>(reader);
                    reader.Close();
                    value = QueryExtenstion.SetCaching(_mCache, cachRequest.GetKey(), getHrRequiredDocumentResponse);
                   // value = getHrRequiredDocumentResponse;
                }

                return Ok(value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region Canceled 
        //// GetAPEmployeeInfo----------------------------------
        //[HttpGet("api/HMGONBASE/GetAPEmployeeInfo.{format}")]
        //public IActionResult GetAPEmployeeInfo(string P_EMPLOYEE_NUMBER)
        //{
        //    try
        //    {
        //        GetAPEmployeeInfoResquest request = new GetAPEmployeeInfoResquest();
        //        // Command text for getting the REF Cursor as OUT parameter
        //        string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_EMPLOYEE_NUMBER)" + "; end;";
        //        OracleConnection conn = new OracleConnection(_dbOption.DbConection);
        //        conn.Open();
        //        // Create the command object for executing cmdTxt1 and cmdTxt2
        //        OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

        //        // Bind the Ref cursor to the PL/SQL stored procedure
        //        OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
        //          OracleDbType.RefCursor, ParameterDirection.Output);
        //        cmd.Parameters.Add(":P_EMPLOYEE_NUMBER", P_EMPLOYEE_NUMBER);
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        List<GetAPEmployeeInfoResponse> employeeInfoList = new List<GetAPEmployeeInfoResponse>();
        //        employeeInfoList = QueryExtenstion.DataReaderMapToList<GetAPEmployeeInfoResponse>(reader);
        //        reader.Close();

        //        return Ok(employeeInfoList);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        //// GetPOEmployeeInfo----------------------------------
        //[HttpGet("api/HMGONBASE/GetPOEmployeeInfo.{format}")]
        //public IActionResult GetPOEmployeeInfo(string P_EMPLOYEE_NUMBER)
        //{
        //    try
        //    {
        //        GetPOEmployeeInfoResquest request = new GetPOEmployeeInfoResquest();
        //        // Command text for getting the REF Cursor as OUT parameter
        //        string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_EMPLOYEE_NUMBER)" + "; end;";
        //        OracleConnection conn = new OracleConnection(_dbOption.DbConection);
        //        conn.Open();
        //        // Create the command object for executing cmdTxt1 and cmdTxt2
        //        OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

        //        // Bind the Ref cursor to the PL/SQL stored procedure
        //        OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
        //          OracleDbType.RefCursor, ParameterDirection.Output);
        //        cmd.Parameters.Add(":P_EMPLOYEE_NUMBER", P_EMPLOYEE_NUMBER);
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        GetPOEmployeeInfoResponse getPOEmployeeInfo = new GetPOEmployeeInfoResponse();
        //        while (reader.Read())
        //        {
        //            getPOEmployeeInfo = reader.ConvertToObject<GetPOEmployeeInfoResponse>();
        //        }
        //        reader.Close();

        //        return Ok(getPOEmployeeInfo);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
        #endregion
    }
}