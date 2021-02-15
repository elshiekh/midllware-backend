﻿using HMGONBaseController.DTO;
using HMGOnBaseOut.DTO;
using HMGOnBaseOut.Extenstion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace HMGOnBaseOut.Controllers
{
    //[Authorize]
    [ApiController]
    //[Route("[controller]")]
    [FormatFilter]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class HMGONBaseOUTController : ControllerBase
    {
        private readonly DBOption _dbOption;
        //private readonly IMemoryCache _mCache;
        public HMGONBaseOUTController(DBOption dbOption)
        {
            _dbOption = dbOption;
            //_mCache = mCache;
        }

        // GetSuppliers
        [HttpGet("api/HMGONBASEOUT/GetSuppliers.{format}")]
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
        [HttpGet("api/HMGONBASEOUT/GetSupplierNumber.{format}")]
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
        [HttpGet("api/HMGONBASEOUT/GetItemName.{format}")]
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
        [HttpGet("api/HMGONBASEOUT/GetItemCode.{format}")]
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
        [HttpGet("api/HMGONBASEOUT/GetPositionTitle.{format}")]
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
        [HttpGet("api/HMGONBASEOUT/GetBusinessGroup.{format}")]
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
        [HttpGet("api/HMGONBASEOUT/GetHrEmployeeInfo.{format}")]
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
        [HttpGet("api/HMGONBASEOUT/GetEngineerName.{format}")]
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

        //// GetHrRequiredDocument ----------------------------------
        //[HttpGet("api/HMGONBASEOUT/GetHrRequiredDocument.{format}")]
        //public IActionResult GetHrRequiredDocument()
        //{
        //    try
        //    {
        //        var cachRequest = new CacheHrRequiredDocumentRequest();
        //        List<GetHrRequiredDocumentResponse> value=null;
        //        _mCache.TryGetValue(cachRequest.GetKey(), out value);
        //        if (value == null)
        //        {
        //            GetHrRequiredDocumentResquest request = new GetHrRequiredDocumentResquest();
        //            // Command text for getting the REF Cursor as OUT parameter
        //            string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "; end;";
        //            OracleConnection conn = new OracleConnection(_dbOption.DbConection);
        //            conn.Open();
        //            // Create the command object for executing cmdTxt1 and cmdTxt2
        //            OracleCommand cmd = new OracleCommand(cmdTxt1, conn);
        //            //cmd.CommandTimeout = 0;
        //            // Bind the Ref cursor to the PL/SQL stored procedure
        //            OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
        //              OracleDbType.RefCursor, ParameterDirection.Output);
        //            OracleDataReader reader = cmd.ExecuteReader();
        //            List<GetHrRequiredDocumentResponse> getHrRequiredDocumentResponse = new List<GetHrRequiredDocumentResponse>();
        //            getHrRequiredDocumentResponse = QueryExtenstion.CustomDataReaderMapToList<GetHrRequiredDocumentResponse>(reader);
        //            reader.Close();
        //            value = QueryExtenstion.SetCaching(_mCache, cachRequest.GetKey(), getHrRequiredDocumentResponse);
        //           // value = getHrRequiredDocumentResponse;
        //        }

        //        return Ok(value);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        // GetHrRequiredDocument ----------------------------------
        [HttpGet("api/HMGONBASEOUT/GetHrRequiredDocument.{format}")]
        public IActionResult GetHrRequiredDocument()
        {
            try
            {
                var cachRequest = new CacheHrRequiredDocumentRequest();
                List<GetHrEmployeeDocumentsResponse> value = null;
                //_mCache.TryGetValue(cachRequest.GetKey(), out value);
                //string JSONString = string.Empty;
                if (value == null)
                {
                    GetHrEmployeeDocumentsResquest request = new GetHrEmployeeDocumentsResquest();
                    // Command text for getting the REF Cursor as OUT parameter
                    string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "; end;";
                    OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                    conn.Open();
                    // Create the command object for executing cmdTxt1 and cmdTxt2
                    OracleCommand cmd = new OracleCommand(cmdTxt1, conn);
                    //cmd.CommandTimeout = 0;
                    // Bind the Ref cursor to the PL/SQL stored procedure
                    OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                      OracleDbType.RefCursor, ParameterDirection.Output);
                    OracleDataReader reader = cmd.ExecuteReader();
                    //var dataTable = new DataTable();
                    //dataTable.Load(reader,LoadOption.Upsert);
                   //List<GetHrEmployeeDocumentsResponse> getHrRequiredDocumentResponse = new List<GetHrEmployeeDocumentsResponse>();
                 //   getHrRequiredDocumentResponse = QueryExtenstion.ConvertDataTable<GetHrEmployeeDocumentsResponse>(dataTable);
                    //JSONString = JsonConvert.SerializeObject(dataTable);
                    List<GetHrEmployeeDocumentsResponse> getHrRequiredDocumentResponse = new List<GetHrEmployeeDocumentsResponse>();
                    getHrRequiredDocumentResponse = QueryExtenstion.CustomDataReaderMapToList<GetHrEmployeeDocumentsResponse>(reader);
                    reader.Close();
                    //value = QueryExtenstion.SetCaching(_mCache, cachRequest.GetKey(), getHrRequiredDocumentResponse);
                    value = getHrRequiredDocumentResponse;
                 }

                return Ok(value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GetEmployeeByName
        [HttpGet("api/HMGONBASEOUT/GetEmployeeByName.{format}")]
        public IActionResult GetEmployeeByName(string P_EMPLOYEE_NAME)
        {
            try
            {
                GetEmployeeByNameRequest request = new GetEmployeeByNameRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_EMPLOYEE_NAME)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_EMPLOYEE_NAME ", P_EMPLOYEE_NAME);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetEmployeeByNameResponse> employerNameList = new List<GetEmployeeByNameResponse>();
                employerNameList = QueryExtenstion.DataReaderMapToList<GetEmployeeByNameResponse>(reader);

                reader.Close();

                return Ok(employerNameList);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GetEmployers 
        [HttpGet("api/HMGONBASEOUT/GetEmployers.{format}")]
        public IActionResult GetEmployers(string P_EMPLOYER_NAME)
        {
            try
            {
                GetEmployersRequest request = new GetEmployersRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_EMPLOYER_NAME)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("P_EMPLOYER_NAME", P_EMPLOYER_NAME);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetEmployersResponse> employersList = new List<GetEmployersResponse>();
                employersList = QueryExtenstion.DataReaderMapToList<GetEmployersResponse>(reader);

                reader.Close();

                return Ok(employersList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GetJobTitles
        [HttpGet("api/HMGONBASEOUT/GetJobTitles.{format}")]
        public IActionResult GetJobTitles(string P_JOB_TITLE)
        {
            try
            {
                GetJobTitlesRequest request = new GetJobTitlesRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_JOB_TITLE)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_JOB_TITLE", P_JOB_TITLE);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetJobTitlesResponse> jobTitleList = new List<GetJobTitlesResponse>();
                jobTitleList = QueryExtenstion.DataReaderMapToList<GetJobTitlesResponse>(reader);

                reader.Close();

                return Ok(jobTitleList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GetEmploymentCategory
        [HttpGet("api/HMGONBASEOUT/GetEmploymentCategory.{format}")]
        public IActionResult GetEmploymentCategory(string P_EMPLOYMENT_CATEGORY)
        {
            try
            {
                GetEmploymentCategoryRequest request = new GetEmploymentCategoryRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_EMPLOYMENT_CATEGORY)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_EMPLOYMENT_CATEGORY", P_EMPLOYMENT_CATEGORY);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetEmploymentCategoryResponse> getEmploymentCategoryList = new List<GetEmploymentCategoryResponse>();
                getEmploymentCategoryList = QueryExtenstion.DataReaderMapToList<GetEmploymentCategoryResponse>(reader);

                reader.Close();

                return Ok(getEmploymentCategoryList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-- GetNationality
        [HttpGet("api/HMGONBASEOUT/GetNationality.{format}")]
        public IActionResult GetNationality(string P_NATIONALITY)
        {
            try
            {
                GetNationalityRequest request = new GetNationalityRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_NATIONALITY)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_NATIONALITY", P_NATIONALITY);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetNationalityResponse> getNationalityResponse = new List<GetNationalityResponse>();
                getNationalityResponse = QueryExtenstion.DataReaderMapToList<GetNationalityResponse>(reader);
                reader.Close();

                return Ok(getNationalityResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GetOrganizations 
        [HttpGet("api/HMGONBASEOUT/GetOrganizations.{format}")]
        public IActionResult GetOrganizations(string P_ORGANIZATION_NAME)
        {
            try
            {
                GetOrganizationsRequest request = new GetOrganizationsRequest();
                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_EMPLOYEE_NAME)" + "; end;";
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();
                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                // Bind the Ref cursor to the PL/SQL stored procedure
                OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
                  OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add(":P_ORGANIZATION_NAME  ", P_ORGANIZATION_NAME);
                OracleDataReader reader = cmd.ExecuteReader();
                List<GetOrganizationsResponse> getOrganizationsResponse = new List<GetOrganizationsResponse>();
                getOrganizationsResponse = QueryExtenstion.DataReaderMapToList<GetOrganizationsResponse>(reader);

                return Ok(getOrganizationsResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // SetOnBaseURLRequest
        [HttpPost("api/HMGONBASEOUT/SetOnBaseURL.{format}")]
        public async Task<IActionResult> SetOnBaseURL([FromBody] SetOnBaseURLRequest request)
        {
            OracleConnection conn = new OracleConnection(_dbOption.DbConection);
            IDataParameter[] parameters = new IDataParameter[4];
            // Inputs
            parameters[0] = new OracleParameter("P_FILE_ID", OracleDbType.Int64, request.P_FILE_ID, ParameterDirection.Input);
            parameters[1] = new OracleParameter("P_DOCUMENT_ID", OracleDbType.NVarchar2, request.P_DOCUMENT_ID, ParameterDirection.Input);
            parameters[2] = new OracleParameter("P_URL", OracleDbType.NVarchar2, request.P_URL, ParameterDirection.Input);
            // Outputs
            parameters[3] = new OracleParameter("P_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);


            using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
            {
                try
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var result = new SetOnBaseURLResponse()
                    {
                        P_STATUS = command.Parameters["P_STATUS"].Value.ToString(),
                    };

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }

        //----SetHrRequiredDocErrors
        [HttpPost("api/HMGONBASEOUT/SetHrRequiredDocErrors.{format}")]
        public async Task<IActionResult> SetHrRequiredDocErrors([FromBody] SetHrRequiredDocErrorsRequest request)
        {
            OracleConnection conn = new OracleConnection(_dbOption.DbConection);
            IDataParameter[] parameters = new IDataParameter[3];
            // Inputs
            parameters[0] = new OracleParameter("P_EMPLOYEE_NUM", OracleDbType.Int32, request.P_EMPLOYEE_NUM, ParameterDirection.Input);
            parameters[1] = new OracleParameter("P_STATUS", OracleDbType.NVarchar2, request.P_STATUS, ParameterDirection.Input);
            parameters[2] = new OracleParameter("P_DESCRIPTION", OracleDbType.NVarchar2, request.P_DESCRIPTION, ParameterDirection.Input);

            using (OracleCommand command = QueryExtenstion.BuildQueryCommand(conn, request.GetSPName(), parameters))
            {
                try
                {
                    conn.Open();
                    var isSuccess = await command.ExecuteNonQueryAsync();
                    var result = new SetHrRequiredDocErrorsResponse()
                    {
                        //P_RESPONSE_STATUS = command.Parameters["@P_RESPONSE_STATUS"].Value.ToString(),
                    };

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }

        #region Canceled 
        //// GetAPEmployeeInfo----------------------------------
        //[HttpGet("api/HMGONBASEOUT/GetAPEmployeeInfo.{format}")]
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
        //[HttpGet("api/HMGONBASEOUT/GetPOEmployeeInfo.{format}")]
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

        //      public IActionResult GetEmployers(string P_EMPLOYER_NAME, int? P_BUSINESS_GROUP_ID)
        //    {
        //        try
        //        {
        //            GetEmployersRequest request = new GetEmployersRequest();
        //    // Command text for getting the REF Cursor as OUT parameter
        //    string cmdTxt1 = "BEGIN :refcursor1 := " + request.GetSPName() + "(:P_EMPLOYER_NAME ,:P_BUSINESS_GROUP_ID)" + "; end;";
        //    OracleConnection conn = new OracleConnection(_dbOption.DbConection);
        //    conn.Open();
        //            // Create the command object for executing cmdTxt1 and cmdTxt2
        //            OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

        //    // Bind the Ref cursor to the PL/SQL stored procedure
        //    OracleParameter outRefPrm = cmd.Parameters.Add(":refcursor1",
        //      OracleDbType.RefCursor, ParameterDirection.Output);
        //    cmd.Parameters.Add("P_EMPLOYER_NAME", P_EMPLOYER_NAME);
        //            cmd.Parameters.Add("P_BUSINESS_GROUP_ID", P_BUSINESS_GROUP_ID);
        //            OracleDataReader reader = cmd.ExecuteReader();
        //    List<GetEmployersResponse> employersList = new List<GetEmployersResponse>();
        //    employersList = QueryExtenstion.DataReaderMapToList<GetEmployersResponse>(reader);

        //            reader.Close();

        //            return Ok(employersList);
        //}
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        // }
        #endregion
    }
}