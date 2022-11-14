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


        //ToXMLInsertStageData
        public static string ToXMLInsertGlJournalsIntoStg(this InsertGlJournalsIntoStgRequest InsertGlJournalsIntoStg)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("VPLUS_TRANS",
                    from serial in InsertGlJournalsIntoStg.InsertGlJournalsIntoStg
                    select new XElement("VPLUS_REC",
                            new XElement("VIDAPLUS_ID", serial.vidaplus_id),
                            new XElement("BATCH_NUMBER", serial.batch_number),
                            new XElement("ACCOUNTING_DATE", serial.accounting_date.ToString("yyyy-MM-dd")),
                            new XElement("CURRENCY_CODE", serial.currency_code),
                            new XElement("JOURNAL_CATEGORY_NAME", serial.journal_category_name),
                            new XElement("JOURNAL_SOURCE_NAME", serial.journal_source_name),
                            new XElement("OPERATING_UNIT_CODE", serial.operating_unit_code),
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
        public static string ToXMLInsertOffersIntoStg(this InsertOffersIntoStgRequest InsertOffersIntoStg)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("VP_OFFERS_TRANS",
                    from serial in InsertOffersIntoStg.InsertOffersIntoStg
                    select new XElement("VP_OFFERS_REC",
                            new XElement("VIDAPLUS_ID", serial.vidaplus_id),
                            new XElement("OPERATING_UNIT_CODE", serial.operating_unit_code),
                            new XElement("OFFER_TYPE", serial.offer_type),
                            new XElement("LOT_NUMBER", serial.Lot_Number),
                            new XElement("OFFER_QTY", serial.offer_qty),
                            new XElement("INVOICE_DATE", serial.invoice_date.ToString("yyyy-MM-dd")),
                            new XElement("DISCOUNT_PERCENTAGE", serial.discount_percentage),
                            new XElement("INVOICE_NUMBER", serial.invoice_number),
                            new XElement("ORGANIZATION_CODE", serial.organaization_code),
                            new XElement("SUBINVENTORY_CODE", serial.subinventory_code))
            ));

            return P_INV_TRX_SER_TBL.ToString();
        }


        //ToXMLInsertStageDataOffer
        public static string ToXMLInsertApInvIntoStg(this InsertApInvIntoStgRequest InsertApInvIntoStg)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("VP_AP_TRANS",
                    from serial in InsertApInvIntoStg.InsertApInvIntoStg
                    select new XElement("VP_AP_REC",
                            new XElement("VIDAPLUS_ID", serial.vidaplus_id),
                            new XElement("OPERATING_UNIT_CODE", serial.operating_unit_code),
                            new XElement("INVOICE_NUMBER", serial.invoice_number),
                            new XElement("INVOICE_DATE", serial.invoice_date.ToString("yyyy-MM-dd")),
                            new XElement("INVOICE_CURRENCY_CODE", serial.invoice_currency_code),
                            new XElement("INVOICE_TYPE", serial.invoice_type),
                            new XElement("LINE_AMOUNT", serial.line_amount),
                            new XElement("PATIENT_ID", serial.patient_id),
                            new XElement("PATIENT_NAME", serial.patient_name))
            ));

            return P_INV_TRX_SER_TBL.ToString();
        }


        //ToXMLAjajiInsertArInvIntoStg
        public static string ToXMLAjajiInsertArInvIntoStg(this AjajiInsertArInvIntoStgRequest AjajiInsertArInvIntoStg)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("VPLUS_AJAJI_AR_TRANS",
                    from serial in AjajiInsertArInvIntoStg.AjajiInsertArInvIntoStg
                    select new XElement("VPLUS_REC",
                            new XElement("VIDAPLUS_ID", serial.vidaplus_id),
                            new XElement("OPERATING_UNIT_CODE", serial.operating_unit_code),
                            new XElement("BATCH_SOURCE", serial.batch_source),
                            new XElement("BATCH_NUMBER", serial.batch_number),
                            new XElement("TRANSACTION_TYPE_NAME", serial.transaction_type_name),
                            new XElement("HIS_CUSTOMER_NUMBER", serial.his_customer_number),
                            new XElement("INVOICE_DATE", serial.invoice_date.ToString("yyyy-MM-dd")),
                            new XElement("LINE_AMOUNT", serial.line_amount),
                            new XElement("CURRENCY_CODE", serial.currency_code),
                            new XElement("SEGMENT2", serial.segment2),
                            new XElement("SEGMENT4", serial.segment4),
                            new XElement("MEMO_LINE", serial.memo_line),
                            new XElement("SEGMENT6", serial.segment6),
                            new XElement("BRANCH_OPERATING_UNIT_CODE", serial.branch_operation_unit_code))
            ));

            return P_INV_TRX_SER_TBL.ToString();
        }


        //ToXMLAjajiInsertArInvIntoStg
        public static string ToXMLInsertArRecIntoStg(this InsertArRecIntoStgRequest InsertArRecIntoStg)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("VPLUS_AR_REC_TRANS",
                    from serial in InsertArRecIntoStg.InsertArRecIntoStg
                    select new XElement("VPLUS_REC",
                            new XElement("VIDAPLUS_ID", serial.vidaplus_id),
                            new XElement("OPERATING_UNIT_CODE", serial.operating_unit_code),
                            new XElement("PAYMENT_METHOD_NAME", serial.payment_method_name),
                            new XElement("RECEIPT_NUMBER", serial.receipt_number),
                            new XElement("CHECK_NUMBER", serial.check_number),
                            new XElement("RECEIPT_AMOUNT", serial.receipt_amount),
                            new XElement("RECEIPT_DATE", serial.receipt_date.ToString("yyyy-MM-dd")),
                            new XElement("HIS_CUSTOMER_NUMBER", serial.his_customer_number))
            ));

            return P_INV_TRX_SER_TBL.ToString();
        }

    }
}
