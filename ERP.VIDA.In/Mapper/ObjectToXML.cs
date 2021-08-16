using System.Linq;
using System.Xml.Linq;
using Vida.DTO;

namespace Vida.Mapper
{
    public static class ObjectToXML
    {
        public static string ToXML(this P_TRX_SERIALS_XML serials)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("P_TRX_SERIALS_XML",
                    from serial in serials.SERIAL
                    select new XElement("SERIAL",
                            new XElement("SFDA_BARCODE", serial.SFDA_BARCODE),
                            new XElement("GTIN", serial.GTIN),
                            new XElement("SERIAL_NUMBER", serial.SERIAL_NUMBER))
            ));

            return P_INV_TRX_SER_TBL.ToString();
        }

        public static string To_BOOKED_ORDERSXML(this P_BOOKED_ORDERS_XML bookorders)
        {
            XDocument P_IBOOKED_ORDERS_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("P_BOOKED_ORDERS_XML",
                    from book_Order in bookorders.BOOKED_ORDERS
                    select new XElement("BOOKED_ORDERS",
                            new XElement("VIDA_ID", book_Order.VIDA_ID),
                            new XElement("USER_NAME", book_Order.USER_NAME),
                            new XElement("ORDER_NUMBER", book_Order.ORDER_NUMBER),
                            new XElement("ORDER_DATE", book_Order.ORDER_DATE.ToShortDateString()),
                            new XElement("LINE_NUMBER", book_Order.LINE_NUMBER),
                            new XElement("ITEM_CODE", book_Order.ITEM_CODE),
                            new XElement("QUANTITY", book_Order.QUANTITY),
                            new XElement("NEED_BY_DATE", book_Order.NEED_BY_DATE.ToShortDateString()),
                            new XElement("DEST_ORGANIZATION_CODE", book_Order.DEST_ORGANIZATION_CODE),
                            new XElement("DEST_SUBINVENTORY", book_Order.DEST_SUBINVENTORY),
                            new XElement("EXTENSION_NUMBER", book_Order.EXTENSION_NUMBER)
                            )
            ));

            return P_IBOOKED_ORDERS_TBL.ToString();
        }
    }
}
