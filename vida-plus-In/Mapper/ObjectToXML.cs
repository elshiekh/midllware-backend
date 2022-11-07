using System.Linq;
using System.Xml.Linq;
using vida_plus_In.DTO;

namespace vida_plus_In.Mapper
{
    public static class ObjectToXML
    {

        public static string ToXMLserials(this Serials Serials)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("SERIALLIST",
                    from serial in Serials.trxSerials
                    select new XElement("SERIAL",
                            new XElement("GTIN", serial.gtin),
                            new XElement("SERIAL_NUMBER", serial.serial_number),
                            new XElement("MFG_BATCH_NUMBER", serial.mfg_batch_number),
                            new XElement("EXPIRATION_DATE", serial.expiration_date))
            ));

            return P_INV_TRX_SER_TBL.ToString();
        }



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


    }
}
