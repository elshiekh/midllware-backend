﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;

namespace Fusion_In.DTO
{
    
    //InsertSupplierData
    #region InsertSupplierData
    public class InsertSupplierDataRequest
    {
        public string GetSPName()
        {
            return "HMG_SUPP_FUSION_INT_IN_PKG.INSERT_SUPPLIER_DATA";
        }
        public int transaction_id { get; set; }
        public string SupplierPayload { get; set; }
    }

    public class InsertSupplierDataResponce
    {
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MSG { get; set; }
    }
    #endregion


    //InsertBuyerData
    #region InsertBuyerData
    public class InsertBuyerDataRequest
    {
        public string GetSPName()
        {
            return "HMG_BUYER_FUSION_INT_IN_PKG.INSERT_BUYER_DATA";
        }
        public int transaction_id { get; set; }
        public string BuyerPayload { get; set; }
    }

    public class InsertBuyerDataResponce
    {
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MSG { get; set; }
    }
    #endregion


    //InsertAwardData
    #region InsertAwardData
    public class InsertAwardDataRequest
    {
        public string GetSPName()
        {
            return "HMG_AWARD_FUSION_INT_IN_PKG.INSERT_AWARD_DATA";
        }
        public int transaction_id { get; set; }
        public string AwardPayload { get; set; }
    }
}

    public class InsertAwardDataResponce
    {
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MSG { get; set; }
    }
    #endregion