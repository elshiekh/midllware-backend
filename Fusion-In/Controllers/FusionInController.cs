﻿using Microsoft.AspNetCore.Http;
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
using Fusion_In.DTO;
using Fusion_In.Mapper;
using Fusion_In.Extenstion;
using Oracle.ManagedDataAccess.Types;

namespace Fusion_In.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class FusionInController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public FusionInController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion



        //InsertSupplierData
        #region InsertSupplierData
        [HttpPost("InsertSupplierData.{format}")]
        public async Task<IActionResult> InsertSupplierData(InsertSupplierDataRequest request)
        {
            try
            {
                //InsertSupplierDataRequest request = new InsertSupplierDataRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_ID", OracleDbType.Int64)).Value = request.transaction_id;
                cmd.Parameters.Add(new OracleParameter("P_SUPPLIER_PAYLOAD", OracleDbType.Clob)).Value = request.SupplierPayload;

                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);


                OracleDataReader reader = cmd.ExecuteReader();

                var InsertSupplierDataList = new InsertSupplierDataResponce()
                {
                    P_RETURN_STATUS = cmd.Parameters["P_RETURN_STATUS"].Value.ToString(),
                    P_RETURN_MSG = cmd.Parameters["P_RETURN_MSG"].Value.ToString(),
                };


                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(InsertSupplierDataList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        //InsertBuyerData
        #region InsertBuyerData
        [HttpPost("InsertBuyerData.{format}")]
        public async Task<IActionResult> InsertBuyerData(InsertBuyerDataRequest request)
        {
            try
            {
                //InsertBuyerDataRequest request = new InsertBuyerDataRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_ID", OracleDbType.Int64)).Value = request.transaction_id;
                cmd.Parameters.Add(new OracleParameter("P_BUYER_PAYLOAD", OracleDbType.Varchar2)).Value = request.BuyerPayload;

                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);


                OracleDataReader reader = cmd.ExecuteReader();

                var InsertBuyerDataList = new InsertBuyerDataResponce()
                {
                    P_RETURN_STATUS = cmd.Parameters["P_RETURN_STATUS"].Value.ToString(),
                    P_RETURN_MSG = cmd.Parameters["P_RETURN_MSG"].Value.ToString(),
                };


                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(InsertBuyerDataList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        //InsertAwardData
        #region InsertAwardData
        [HttpPost("InsertAwardData.{format}")]
        public async Task<IActionResult> InsertAwardData(InsertAwardDataRequest request)
        {
            try
            {
                //InsertAwardDataRequest request = new InsertAwardDataRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_TRANSACTION_ID", OracleDbType.Int64)).Value = request.transaction_id;
                cmd.Parameters.Add(new OracleParameter("P_AWARD_PAYLOAD", OracleDbType.Varchar2)).Value = request.AwardPayload;

                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, 32767, null, ParameterDirection.Output);


                OracleDataReader reader = cmd.ExecuteReader();

                var InsertAwardDataList = new InsertAwardDataResponce()
                {
                    P_RETURN_STATUS = cmd.Parameters["P_RETURN_STATUS"].Value.ToString(),
                    P_RETURN_MSG = cmd.Parameters["P_RETURN_MSG"].Value.ToString(),
                };


                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(InsertAwardDataList);
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