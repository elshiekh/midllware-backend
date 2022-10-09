using System;
using System.Collections.Generic;

namespace Mowadhafi_In.DTO
{
    // Get Professions
    #region Get Professions
    public class GetProfessionsRequest
    {
        public string GetSPName()
        {
            return "HMG_MOD_INT_IN_PKG.GET_PROFESSIONS";
        }
        public string P_LANGUAGE { get; set; }
    }

    public class GetProfessionsResponce
    {
        public string PROFESSION_EN { get; set; }
        public string PROFESSION_AR { get; set; }
        public string PROFESSION_ID { get; set; }
    }

    //public class ItemsDetailsResponse
    //{
    //    public string P_ITEMS_DETAILS_RESP { get; set; }
    //    public string P_RETURN_STATUS { get; set; }
    //    public string P_RETURN_MSG { get; set; }
    //}
    #endregion


    // Get Reasons
    #region Get Reasons
    public class GetReasonsRequest
    {
        public string GetSPName()
        {
            return "HMG_MOD_INT_IN_PKG.GET_REASONS";
        }
        public string P_LANGUAGE { get; set; }
    }

    public class GetReasonsResponce
    {
        public string REASON_CODE { get; set; }
        public string REASON_DESCRIPTION { get; set; }
    }

    #endregion


    // Get Employers
    #region Get Employers
    public class GetEmployersRequest
    {
        public string GetSPName()
        {
            return "HMG_MOD_INT_IN_PKG.GET_EMPLOYER";
        }
        public string P_LANGUAGE { get; set; }
    }

    public class GetEmployersResponce
    {
        public string EMPLOYER { get; set; }
        public long EMPLOYER_ID { get; set; }
    }

    #endregion


    // Get Payrolls
    #region Get Payrolls
    public class GetPayrollsRequest
    {
        public string GetSPName()
        {
            return "HMG_MOD_INT_IN_PKG.GET_PAYROLLS";
        }
        public string P_LANGUAGE { get; set; }
    }

    public class GetPayrollsResponce
    {
        public string PAYROLL_NAME { get; set; }
        public int PAYROLL_ID { get; set; }
    }

    #endregion


    // Get PayInsallmentPeriodsrolls
    #region Get InsallmentPeriods
    public class GetInsallmentPeriodsRequest
    {
        public string GetSPName()
        {
            return "HMG_MOD_INT_IN_PKG.GET_INSALLMENT_PERIODS";
        }
        public string P_LANGUAGE { get; set; }
    }

    public class GetInsallmentPeriodsResponce
    {
        public string PERIOD_NAME { get; set; }
        public string PERIOD_DATE { get; set; }
    }

    #endregion


    // Get Employees
    #region Get Employees
    public class GetEmployeesRequest
    {
        public string GetSPName()
        {
            return "HMG_MOD_INT_IN_PKG.GET_EMPLOYEES";
        }
        public string P_LANGUAGE { get; set; }
    }

    public class GetEmployeesResponce
    {
        public string EMPLOYEE_NUMBER { get; set; }
        public string EMPLOYEE_NAME { get; set; }
    }

    #endregion
}
