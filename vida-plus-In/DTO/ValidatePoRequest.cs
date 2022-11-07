using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;

namespace vida_plus_In.DTO
{


    #region ProcessTransaction
    public class ProcessTransactionRequest
    {
        public string GetSPName()
        {
            return "HMG_VP_INV_INT_IN_PKG.PROCESS_TRANSACTIONS";
        }
        public int vidaPlus_id { get; set; }
        public string organaization_code { get; set; }
        public string subinventory_code { get; set; }
        public string transaction_type { get; set; }
        public DateTime transaction_date { get; set; }
        public int transaction_quantity { get; set; }
        public string lot_number { get; set; }
        public string cost_center { get; set; }
        public string transaction_referance { get; set; }
        public int line_number { get; set; }
        public string item_code { get; set; }
        public Serials trx_serials_xml { get; set; }
    }

    public class Serials
    { 
        public List<trxSerials> trxSerials { get; set; }
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
        public decimal P_ORACLE_ID { get; set; }
        public string P_RESPONSE_STATUS { get; set; }
        public string P_RESPONSE_MSG { get; set; }
    }
    #endregion



    #region InsertStageData
    public class InsertStageDataRequest
    {
        public string GetSPName()
        {
            return "HMG_VP_GL_INT_IN_PKG.HMG_VP_INSERT_STAGE_DATA_P";
        }
        public List<InsertStageDataRequestData> InsertStageData { get; set; }
    }

    public class InsertStageDataRequestData
    {
        public Int64 vidaplus_id { get; set; }
        public string batch_number { get; set; }
        public DateTime accounting_date { get; set; }
        public string currency_code { get; set; }
        public string journal_category_name { get; set; }
        public string journal_source_name { get; set; }
        public string segment2 { get; set; }
        public string segment4 { get; set; }
        public string segment6 { get; set; }
        public string revenue_category_name { get; set; }
        public Int64 line_amount { get; set; }
        public string line_description { get; set; }
    }


    public class InsertStageDataResponce
    {
        public decimal oracle_id { get; set; }
        public decimal vidaplus_id { get; set; }
        public string response_status { get; set; }
        public string response_msg { get; set; }
    }
    #endregion



    #region InsertStageDateOffer
    public class InsertStageDataOfferRequest
    {
        public string GetSPName()
        {
            return "HMG_VP_OFFERS_INT_IN_PKG.HMG_VP_INSERT_STAGE_DATA_P";
        }
        public List<InsertStageDataOfferRequestData> InsertStageDataOffer { get; set; }
    }

    public class InsertStageDataOfferRequestData
    {
        public int vidaplus_id { get; set; }
        public string oparating_unit_code { get; set; }
        public string offer_type { get; set; }
        public string Lot_Number { get; set; }
        public int offer_qty { get; set; }
        public DateTime invoice_date { get; set; }
        public int discount_percentage { get; set; }
        public string invoice_number { get; set; }
        public string organaization_code { get; set; }
        public string subinventory_code { get; set; }
    }


    public class InsertStageDataOfferResponce
    {
        public decimal oracle_id { get; set; }
        public decimal vidaplus_id { get; set; }
        public string response_status { get; set; }
        public string response_msg { get; set; }
    }
    #endregion

}
