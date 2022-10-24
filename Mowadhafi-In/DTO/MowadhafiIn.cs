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
            return "HMG_MOD_INT_IN_PKG.GET_EMPLOYERS";
        }
        public string P_LANGUAGE { get; set; }
    }

    public class GetEmployersResponce
    {
        public long EMPLOYER_ID { get; set; }
        public string EMPLOYER_NAME { get; set; }
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
    #region Get InstallmentPeriods
    public class GetInstallmentPeriodsRequest
    {
        public string GetSPName()
        {   
            return "HMG_MOD_INT_IN_PKG.GET_INSTALLMENT_PERIODS";
        }
        public string P_LANGUAGE { get; set; }
    }

    public class GetInstallmentPeriodsResponce
    {
        public string PERIOD_NAME { get; set; }
        public string PERIOD_DATE { get; set; }
    }

    #endregion


    // Get Months
    #region Get Months
    public class GetMonthsRequest
    {
        public string GetSPName()
        {
            return "HMG_MOD_INT_IN_PKG.GET_MONTHS";
        }
        public string P_LANGUAGE { get; set; }
    }

    public class GetMonthsResponce
    {
        public string MONTH { get; set; }
    }

    #endregion


    // Get EmployeesDetails
    #region Get EmployeesDetails
    public class GetEmployeesDetailsRequest
    {
        public string GetSPName()
        {
            return "HMG_MOD_INT_IN_PKG.GET_EMPLOYEES_DETAILS";
        }
        public string P_LANGUAGE { get; set; }
    }

    public class GetEmployeesDetailsResponce
    {
        public string EMPLOYEE_NUMBER { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public string EMPLOYEE_MOBILE_NUMBER { get; set; }
        public string EMPLOYER { get; set; }
        public string PAYROLL_CODE { get; set; }
        public string IQAMA_NUMBER { get; set; }
        public string IQAMA_PROFESSION_ID { get; set; }
        public string IQAMA_PROFESSION { get; set; }
        public string IQAMA_ISSUE_DATE { get; set; }
        public string IQAMA_EXPIRY_DATE { get; set; }
        public string LABOUR_CARD_NUMBER { get; set; }
        public string LABOUR_PROFESSION_ID { get; set; }
        public string LABOUR_PROFESSION { get; set; }
        public string LABOUR_ISSUE_DATE { get; set; }
        public string LABOUR_EXPIRY_DATE { get; set; }
    }

    #endregion


    // Get TransactionStatuses
    #region Get TransactionStatuses
    public class GetTransactionStatusesRequest
    {
        public string GetSPName()
        {
            return "HMG_MOD_INT_IN_PKG.GET_TRANSACTION_STATUSES";
        }
        public List<TransactionStatusesRequest> TransactionReferences { get; set; }
    }

    public class TransactionStatusesRequest
    {
        public string EserviceID { get; set; }
        public string TransactionType { get; set; }
    }

    public class GetTransactionStatusesResponce
    {
        public string eservice_id { get; set; }
        public string transaction_type { get; set; }
        public string return_status { get; set; }
        public string return_message { get; set; }
    }
    #endregion


    // Insert TransactionDetails
    #region Get TransactionStatuses
    public class InsertTransactionDetailsRequest
    {
        public string GetSPName()
        {
            return "HMG_MOD_INT_IN_PKG.INSERT_TRANSACTION_DETAILS";
        }
        public List<TransactionDetailsRequest> TransactionDetails { get; set; }
    }

    public class TransactionDetailsRequest
    {
        public string EserviceID { get; set; }
        public string TransactionType { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public string IqamaNumber { get; set; }
        public string Month { get; set; }
        public string ReasonCode { get; set; }
        public string ProfessionID { get; set; }
        public string Profession { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CardNumber { get; set; }
        public string CardFees { get; set; }
        public string PenaltyAmount { get; set; }
        public string CompanyCharges { get; set; }
        public string EmployeeCharges { get; set; }
        public string NoOfInstallments { get; set; }
        public string InstallmentPeriod { get; set; }
        public string SadadNumber { get; set; }
    }

    public class InsertTransactionDetailsResponce
    {
        public string eservice_id { get; set; }
        public string Transaction_Type { get; set; }
        public string return_status { get; set; }
        public string return_message { get; set; }
    }

    #endregion

}
