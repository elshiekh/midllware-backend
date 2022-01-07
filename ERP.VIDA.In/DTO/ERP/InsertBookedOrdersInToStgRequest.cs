using System;
using System.Collections.Generic;

namespace Vida.DTO
{
    //INSERTBOOKEDORDERSINTOSTGREQUEST
    public class InsertBookedOrdersInToStgRequest
    {
        public string GetSPName()
        {
            return "HMG_VIDA_INV_INT_IN_PKG.INSERT_BOOKED_ORDERS_INTO_STG";
        }
        public P_BOOKED_ORDERS_XML P_BOOKED_ORDERS_XML { get; set; }
    }

    public class InsertBookedOrdersInToStgResponce
    {
        public decimal VIDA_ID { get; set; }
        public string USER_NAME { get; set; }
        public string ORDER_NUMBER { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public decimal LINE_NUMBER { get; set; }
        public string ITEM_CODE { get; set; }
        public decimal QUANTITY { get; set; }
        public DateTime NEED_BY_DATE { get; set; }
        public string DEST_ORGANIZATION_CODE { get; set; }
        public string DEST_SUBINVENTORY { get; set; }
        public string EXTENSION_NUMBER { get; set; }
        public decimal ORACLE_ID { get; set; }
        public string RESPONSE_STATUS { get; set; }
        public string RESPONSE_MSG { get; set; }
    }

    public class P_BOOKED_ORDERS_XML
    {
        public List<BOOKED_ORDERS> BOOKED_ORDERS { get; set; }
    }

    public class BOOKED_ORDERS
    {
        public int VIDA_ID { get; set; }
        public string USER_NAME { get; set; }
        public string ORDER_NUMBER { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public int LINE_NUMBER { get; set; }
        public string ITEM_CODE { get; set; }
        public double QUANTITY { get; set; }
        public DateTime NEED_BY_DATE { get; set; }
        public string DEST_ORGANIZATION_CODE { get; set; }
        public string DEST_SUBINVENTORY { get; set; }
        public string EXTENSION_NUMBER { get; set; }
    }


    public class TestRequest
    {
        public string GetSPName()
        {
            return "HMG_ELEVATUS_INT_IN_PKG. XX_TEST_REC";
        }
        public int SEQ_ID { get; set; }
        public TableRequest TableRequest { get; set; }
    }
    public class TableRequest
    {
        public List<TableColumn> TableColumns { get; set; }
    }

    public class TableColumn
    {
        public string EMPLOYEE_NUMBER { get; set; }
        public string NAME { get; set; }
    }
}
