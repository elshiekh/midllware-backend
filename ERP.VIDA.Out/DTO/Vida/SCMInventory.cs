﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Vida.DTO.Vida
{
    public class SCMInventoryRequest
    {
        public INVStock INVStock { get; set; }
        public List<Serials_ROW> Serials { get; set; }   // ScmSerials
    }

    public class SCMInventoryResponse
    {
        [XmlElement("MESSAGE")]
        public string Message { get; set; }

        [XmlElement("RESPONSESTATUS")]
        public string ResponseStatus { get; set; }

        [XmlElement("TRANSACTIONID")]
        public string TransactionId { get; set; }
    }

    public class INVStock
    {
        public Int64 ORACLE_ID { get; set; } = 5401272;
        public string ORACLE_ITEM_CODE { get; set; } = "6280020242";
        public string ORACLE_SUBINVENTORY_CODE { get; set; } = "DSU_IP";
        public double ORACLE_QUANTITY { get; set; } = 33.3;
        public string ORACLE_TRANSACTION_UOM { get; set; } = "EA";
        public string LOT_NUMBER { get; set; } = "1427179";
        public string ORACLE_TRANSACTION_TYPE { get; set; } = "Return from Clinic/Floor";
        public string SUPPLIER_BATCH { get; set; } = "Supplier Batch";
        public string TRANSACTION_DATE { get; set; } = "2020-08-19 00:00:00.000";
        public string ORGANIZATION_CODE { get; set; } = "HMC";
        public string EXPIRY_DATE { get; set; } = "2020-08-19 00:00:00.000";
        public double PUR_PRICE { get; set; } = 100.5;
        public double SALE_PRICE { get; set; } = 100.5;
        public string TRANSACTION_REFFERENCE { get; set; } = "6280020242";
    }

    public class Serials_ROW  // Serials_ROW ScmSerials
    {
        public string SFDA_BARCODE { get; set; } = "1111111111"; //SerialNum
        public string GTIN { get; set; } = "22222222222"; //GTIN
        public string SERIAL_NUMBER { get; set; } = "33333333"; //QRCode
    }
}
