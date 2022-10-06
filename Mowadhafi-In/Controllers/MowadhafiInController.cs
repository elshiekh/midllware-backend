﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Threading.Tasks;
using Mowadhafi_In.Extenstion;
using System;
using System.Net;
using Newtonsoft.Json;
using Mowadhafi_In.DTO;
using System.Collections.Generic;

namespace Mowadhafi_In.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class MowadhafiInController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public MowadhafiInController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion


        #region Get Professions
        [HttpPost("GetProfessions.{format}")]
        public async Task<IActionResult> GetProfessions(string P_LANGUAGE)
        {
            try
            {
                GetProfessionsRequest request = new GetProfessionsRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConnection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_LANGUAGE", OracleDbType.Varchar2)).Value = P_LANGUAGE;
                cmd.Parameters.Add("P_PROFESSIONS", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, ParameterDirection.Output);

                OracleDataReader reader = cmd.ExecuteReader();

                List<GetProfessionsResponce> ProfessionsList = new List<GetProfessionsResponce>();
                ProfessionsList = QueryExtenstion.DataReaderMapToList<GetProfessionsResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(ProfessionsList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        #region Get Reasons
        [HttpPost("GetReasons.{format}")]
        public async Task<IActionResult> GetReasons(string P_LANGUAGE)
        {
            try
            {
                GetReasonsRequest request = new GetReasonsRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConnection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_LANGUAGE", OracleDbType.Varchar2)).Value = P_LANGUAGE;
                cmd.Parameters.Add("P_REASONS", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, ParameterDirection.Output);

                OracleDataReader reader = cmd.ExecuteReader();

                List<GetReasonsResponce> ReasonsList = new List<GetReasonsResponce>();
                ReasonsList = QueryExtenstion.DataReaderMapToList<GetReasonsResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(ReasonsList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        #region Get Employers
        [HttpPost("GetEmployers.{format}")]
        public async Task<IActionResult> GetEmployers(string P_LANGUAGE)
        {
            try
            {
                GetEmployersRequest request = new GetEmployersRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConnection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_LANGUAGE", OracleDbType.Varchar2)).Value = P_LANGUAGE;
                cmd.Parameters.Add("P_EMPLOYER", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, ParameterDirection.Output);

                OracleDataReader reader = cmd.ExecuteReader();

                List<GetEmployersResponce> EmployersList = new List<GetEmployersResponce>();
                EmployersList = QueryExtenstion.DataReaderMapToList<GetEmployersResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(EmployersList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        #region Get Payrolls
        [HttpPost("GetPayrolls.{format}")]
        public async Task<IActionResult> GetPayrolls(string P_LANGUAGE)
        {
            try
            {
                GetPayrollsRequest request = new GetPayrollsRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConnection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_LANGUAGE", OracleDbType.Varchar2)).Value = P_LANGUAGE;
                cmd.Parameters.Add("P_PAYROLLS", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, ParameterDirection.Output);

                //OracleDataAdapter ad = new OracleDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);

                OracleDataReader reader = cmd.ExecuteReader();

                List<GetPayrollsResponce> PayrollsList = new List<GetPayrollsResponce>();
                PayrollsList = QueryExtenstion.DataReaderMapToList<GetPayrollsResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(PayrollsList);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        #region Get InsallmentPeriods
        [HttpPost("GetInsallmentPeriods.{format}")]
        public async Task<IActionResult> GetInsallmentPeriods(string P_LANGUAGE)
        {
            try
            {
                GetInsallmentPeriodsRequest request = new GetInsallmentPeriodsRequest();

                // Command text for getting the REF Cursor as OUT parameter
                string cmdTxt1 = request.GetSPName();
                OracleConnection conn = new OracleConnection(_dbOption.DbConnection);
                conn.Open();

                // Create the command object for executing cmdTxt1 and cmdTxt2
                OracleCommand cmd = new OracleCommand(cmdTxt1, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //Bind the Ref cursor to the PL / SQL stored procedure
                cmd.Parameters.Add(new OracleParameter("P_LANGUAGE", OracleDbType.Varchar2)).Value = P_LANGUAGE;
                cmd.Parameters.Add("P_INSALLMENT_PERIODS", OracleDbType.RefCursor, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_STATUS", OracleDbType.Varchar2, ParameterDirection.Output);
                cmd.Parameters.Add("P_RETURN_MSG", OracleDbType.Varchar2, ParameterDirection.Output);

                //OracleDataAdapter ad = new OracleDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //ad.Fill(dt);

                OracleDataReader reader = cmd.ExecuteReader();

                List<GetInsallmentPeriodsResponce> InsallmentPeriodsList = new List<GetInsallmentPeriodsResponce>();
                InsallmentPeriodsList = QueryExtenstion.DataReaderMapToList<GetInsallmentPeriodsResponce>(reader);

                reader.Close();

                conn.Close();
                conn.Dispose();

                return Ok(InsallmentPeriodsList);
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
