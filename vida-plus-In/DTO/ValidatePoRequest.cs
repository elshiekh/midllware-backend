using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;

namespace vida_plus_In.DTO
{

    //ProcessTransaction
    #region ProcessTransaction
    public class ProcessTransactionRequest
    {
        public string GetSPName()
        {
            return "HMG_VP_INV_INT_IN_PKG.PROCESS_TRANSACTIONS";
        }
        public int vidaPlus_id { get; set; }
        public string item_code { get; set; }
        public string lot_number { get; set; }
        public int transaction_quantity { get; set; }
        public string transaction_reference { get; set; }
        public int line_number { get; set; }
        public string transaction_type_name { get; set; }
        public DateTime transaction_date { get; set; }
        public string organization_code { get; set; }
        public string subinventory_code { get; set; }
        public string cost_center { get; set; }
        public Serials trx_serials { get; set; }
    }

    public class Serials
    { 
        public List<trxSerials> trx_serials { get; set; }
    }

    public class trxSerials
    {
        public string gtin { get; set; }
        public string serial_number { get; set; }
        public string mfg_batch_number { get; set; }
        public string expiration_date { get; set; }
    }

    public class ProcessTransactionsResponce
    {
        public Int64 P_ORACLE_ID { get; set; }
        public string P_RESPONSE_STATUS { get; set; }
        public string P_RESPONSE_MSG { get; set; }
    }
    #endregion


    //InsertArCustIntoStg
    #region InsertArCustIntoStg
    public class InsertArCustIntoStgRequest
    {
        public string GetSPName()
        {
            return "HMG_VP_AR_CUST_INT_IN_PKG.INSERT_AR_CUST_INTO_STG";
        }
        public List<InsertArCustIntoStgRequestData> InsertArCustIntoStg { get; set; }
    }

    public class InsertArCustIntoStgRequestData
    {
        public int vidaplus_id { get; set; }
        public string his_customer_number { get; set; }
        public string his_customer_name { get; set; }
        public string his_customer_category { get; set; }
    }


    public class InsertArCustIntoStgResponce
    {
        public decimal oracle_id { get; set; }
        public decimal vidaplus_id { get; set; }
        public string response_status { get; set; }
        public string response_msg { get; set; }
    }
    #endregion


    //InsertArInvIntoStg
    #region InsertArInvIntoStg
    public class InsertArInvIntoStgRequest
    {
        public string GetSPName()
        {
            return "HMG_VP_AR_INV_INT_IN_PKG.INSERT_AR_INV_INTO_STG";
        }
        public List<InsertArInvIntoStgRequestData> InsertArInvIntoStg { get; set; }
    }

    public class InsertArInvIntoStgRequestData
    {
        public int vidaplus_id { get; set; }
        public string operating_unit_code { get; set; }
        public string batch_source { get; set; }
        public string batch_number { get; set; }
        public string transaction_type_name { get; set; }
        public string his_customer_number { get; set; }
        public DateTime invoice_date { get; set; }
        public int line_amount { get; set; }
        public string currency_code { get; set; }
        public string segment2 { get; set; }
        public string segment4 { get; set; }
        public string memo_line_name { get; set; }
        public string segment6 { get; set; }
    }


    public class InsertArInvIntoStgResponce
    {
        public decimal oracle_id { get; set; }
        public decimal vidaplus_id { get; set; }
        public string response_status { get; set; }
        public string response_msg { get; set; }
    }
    #endregion


    //InsertGlJournalsIntoStg
    #region InsertGlJournalsIntoStg
    public class InsertGlJournalsIntoStgRequest
    {
        public string GetSPName()
        {
            return "HMG_VP_GL_INT_IN_PKG.INSERT_GL_JOURNALS_INTO_STG";
        }
        public List<InsertGlJournalsIntoStgRequestData> InsertGlJournalsIntoStg { get; set; }
    }

    public class InsertGlJournalsIntoStgRequestData
    {
        public Int64 vidaplus_id { get; set; }
        public string batch_number { get; set; }
        public DateTime accounting_date { get; set; }
        public string currency_code { get; set; }
        public string journal_category_name { get; set; }
        public string journal_source_name { get; set; }
        public string operating_unit_code { get; set; }
        public string segment2 { get; set; }
        public string segment4 { get; set; }
        public string segment6 { get; set; }
        public string revenue_category_name { get; set; }
        public Int64 line_amount { get; set; }
        public string line_description { get; set; }
    }


    public class InsertGlJournalsIntoStgResponce
    {
        public decimal oracle_id { get; set; }
        public decimal vidaplus_id { get; set; }
        public string response_status { get; set; }
        public string response_msg { get; set; }
    }
    #endregion


    //InsertOffersIntoStg
    #region InsertOffersIntoStg
    public class InsertOffersIntoStgRequest
    {
        public string GetSPName()
        {
            return "HMG_VP_OFFERS_INT_IN_PKG.INSERT_OFFERS_INTO_STG";
        }
        public List<InsertOffersIntoStgRequestData> InsertOffersIntoStg { get; set; }
    }

    public class InsertOffersIntoStgRequestData
    {
        public int vidaplus_id { get; set; }
        public string operating_unit_code { get; set; }
        public string offer_type { get; set; }
        public string Lot_Number { get; set; }
        public int offer_qty { get; set; }
        public DateTime invoice_date { get; set; }
        public int discount_percentage { get; set; }
        public string invoice_number { get; set; }
        public string organaization_code { get; set; }
        public string subinventory_code { get; set; }
    }


    public class InsertOffersIntoStgResponce
    {
        public decimal oracle_id { get; set; }
        public decimal vidaplus_id { get; set; }
        public string response_status { get; set; }
        public string response_msg { get; set; }
    }
    #endregion


    //InsertApInvIntoStg
    #region InsertApInvIntoStg
    public class InsertApInvIntoStgRequest
    {
        public string GetSPName()
        {
            return "HMG_VP_AP_INV_INT_IN_PKG.INSERT_AP_INV_INTO_STG";
        }
        public List<InsertApInvIntoStgRequestData> InsertApInvIntoStg { get; set; }
    }

    public class InsertApInvIntoStgRequestData
    {
        public int vidaplus_id { get; set; }
        public string operating_unit_code { get; set; }
        public string invoice_number { get; set; }
        public DateTime invoice_date { get; set; }
        public string invoice_currency_code { get; set; }
        public string invoice_type { get; set; }
        public int line_amount { get; set; }
        public int patient_id { get; set; }
        public string patient_name { get; set; }
    }


    public class InsertApInvIntoStgResponce
    {
        public decimal oracle_id { get; set; }
        public decimal vidaplus_id { get; set; }
        public string response_status { get; set; }
        public string response_msg { get; set; }
    }
    #endregion


    //AjajiInsertArInvIntoStg
    #region AjajiInsertArInvIntoStg
    public class AjajiInsertArInvIntoStgRequest
    {
        public string GetSPName()
        {
            return "HMG_VP_AJAJI_AR_INV_INT_IN_PKG.INSERT_AR_INV_INTO_STG";
        }
        public List<AjajiInsertArInvIntoStgRequestData> AjajiInsertArInvIntoStg { get; set; }
    }

    public class AjajiInsertArInvIntoStgRequestData
    {
        public int vidaplus_id { get; set; }
        public string operating_unit_code { get; set; }
        public string batch_source { get; set; }
        public string batch_number { get; set; }
        public string transaction_type_name { get; set; }
        public string his_customer_number { get; set; }
        public DateTime invoice_date { get; set; }
        public int line_amount { get; set; }
        public string currency_code { get; set; }
        public string segment2 { get; set; }
        public string segment4 { get; set; }
        public string memo_line { get; set; }
        public string segment6 { get; set; }
        public string branch_operation_unit_code { get; set; }
    }


    public class AjajiInsertArInvIntoStgResponce
    {
        public decimal oracle_id { get; set; }
        public decimal vidaplus_id { get; set; }
        public string response_status { get; set; }
        public string response_msg { get; set; }
    }
    #endregion


    //GetEmployeeDetails
    #region GetEmployeeDetails
    public class InsertArRecIntoStgRequest
    {
        public string GetSPName()
        {
            return "HMG_VP_AR_REC_INT_IN_PKG.INSERT_AR_REC_INTO_STG";
        }
        public List<InsertArRecIntoStgRequestData> InsertArRecIntoStg { get; set; }
    }

    public class InsertArRecIntoStgRequestData
    {
        public int vidaplus_id { get; set; }
        public string operating_unit_code { get; set; }
        public string payment_method_name { get; set; }
        public string receipt_number { get; set; }
        public int check_number { get; set; }
        public int receipt_amount { get; set; }
        public DateTime receipt_date { get; set; }
        public string his_customer_number { get; set; }
    }


    public class InsertArRecIntoStgResponce
    {
        public decimal oracle_id { get; set; }
        public decimal vidaplus_id { get; set; }
        public string response_status { get; set; }
        public string response_msg { get; set; }
    }
    #endregion



    //GetEmployeeDetails
    #region Get EmployeeDetails
    public class GetEmployeeDetailsRequest
    {
        public string GetSPName()
        {
            return "HMG_VP_EMP_INFO_PKG.GET_EMPLOYEE_DETAILS";
        }
    }

    public class GetEmployeeDetailsResponce
    {
        public string P_EMPLOYEE_INFORMATION { get; set; }
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MSG { get; set; }
    }
    #endregion
}
