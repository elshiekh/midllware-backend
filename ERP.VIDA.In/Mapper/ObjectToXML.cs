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
                    select  new XElement("SERIAL",
                            new XElement("SFDA_BARCODE", serial.SFDA_BARCODE),
                            new XElement("GTIN", serial.GTIN),
                            new XElement("SERIAL_NUMBER", serial.SERIAL_NUMBER))
            ));

            return P_INV_TRX_SER_TBL.ToString();
        }
    }
}
