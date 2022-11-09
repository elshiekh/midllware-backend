using System.Linq;
using System.Xml.Linq;
using vida_plus_In.DTO;

namespace vida_plus_In.Mapper
{
    public static class ObjectToXML
    {
        //ToXMLserials
        public static string ToXMLserials(this Serials Serials)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("SERIALLIST",
                    from serial in Serials.trx_serials
                    select new XElement("SERIAL",
                            new XElement("GTIN", serial.gtin),
                            new XElement("SERIAL_NUMBER", serial.serial_number),
                            new XElement("MFG_BATCH_NUMBER", serial.mfg_batch_number),
                            new XElement("EXPIRATION_DATE", serial.expiration_date))
            ));

            return P_INV_TRX_SER_TBL.ToString();
        }


        //ToXMLInsertStageData
        public static string ToXMLInsertStageData(this InsertStageDataRequest InsertStageDate)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("VPLUS_TRANS",
                    from serial in InsertStageDate.InsertStageData
                    select new XElement("VPLUS_REC",
                            new XElement("VIDAPLUS_ID", serial.vidaplus_id),
                            new XElement("BATCH_NUMBER", serial.batch_number),
                            new XElement("ACCOUNTING_DATE", serial.accounting_date.ToString("yyyy-MM-dd")),
                            new XElement("CURRENCY_CODE", serial.currency_code),
                            new XElement("JOURNAL_CATEGORY_NAME", serial.journal_category_name),
                            new XElement("JOURNAL_SOURCE_NAME", serial.journal_source_name),
                            new XElement("SEGMENT2", serial.segment2),
                            new XElement("SEGMENT4", serial.segment4),
                            new XElement("SEGMENT6", serial.segment6),
                            new XElement("REVENUE_CATEGORY_NAME", serial.revenue_category_name),
                            new XElement("LINE_AMOUNT", serial.line_amount),
                            new XElement("LINE_DESCRIPTION", serial.line_description))
            ));

            return P_INV_TRX_SER_TBL.ToString();
        }


        //ToXMLInsertStageDataOffer
        public static string ToXMLInsertStageDataOffer(this InsertStageDataOfferRequest InsertStageDate)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("VP_OFFERS_TRANS",
                    from serial in InsertStageDate.InsertStageDataOffer
                    select new XElement("VP_OFFERS_REC",
                            new XElement("VIDAPLUS_ID", serial.vidaplus_id),
                            new XElement("OPARATING_UNIT_CODE", serial.oparating_unit_code),
                            new XElement("OFFER_TYPE", serial.offer_type),
                            new XElement("LOT_NUMBER", serial.Lot_Number),
                            new XElement("OFFER_QTY", serial.offer_qty),
                            new XElement("INVOICE_DATE", serial.invoice_date.ToString("yyyy-MM-dd")),
                            new XElement("DISCOUNT_PERCENTAGE", serial.discount_percentage),
                            new XElement("INVOICE_NUMBER", serial.invoice_date),
                            new XElement("ORGANIZATION_CODE", serial.organaization_code),
                            new XElement("SUBINVENTORY_CODE", serial.subinventory_code))
            ));

            return P_INV_TRX_SER_TBL.ToString();
        }


        //ToXMLInsertArCustIntoStg
        public static string ToXMLInsertArCustIntoStg(this InsertArCustIntoStgRequest InsertArCustIntoStg)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("CUSTLIST",
                    from serial in InsertArCustIntoStg.InsertArCustIntoStg
                    select new XElement("CUST",
                            new XElement("vidaplus_id", serial.vidaplus_id),
                            new XElement("his_customer_number", serial.his_customer_number),
                            new XElement("his_customer_name", serial.his_customer_name),
                            new XElement("his_customer_category", serial.his_customer_category))
            ));

            return P_INV_TRX_SER_TBL.ToString();
        }


        //ToXMLInsertArInvIntoStg
        public static string ToXMLInsertArInvIntoStg(this InsertArInvIntoStgRequest InsertArInvIntoStg)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("ARINVOICES",
                    from serial in InsertArInvIntoStg.InsertArInvIntoStg
                    select new XElement("INVOICE",
                            new XElement("vidaplus_id", serial.vidaplus_id),
                            new XElement("operating_unit_code", serial.operating_unit_code),
                            new XElement("batch_source", serial.batch_source),
                            new XElement("batch_number", serial.his_customer_number),
                            new XElement("transaction_type_name", serial.transaction_type_name),
                            new XElement("his_customer_number", serial.his_customer_number),
                            new XElement("invoice_date", serial.invoice_date.ToString("yyyy-MM-dd")),
                            new XElement("line_amount", serial.line_amount),
                            new XElement("currency_code", serial.currency_code),
                            new XElement("segment2", serial.segment2),
                            new XElement("segment4", serial.segment4),
                            new XElement("memo_line_name", serial.memo_line_name),
                            new XElement("segment6", serial.segment6))
            ));

            return P_INV_TRX_SER_TBL.ToString();
        }

    }
}
