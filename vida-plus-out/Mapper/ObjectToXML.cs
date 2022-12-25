using System.Linq;
using System.Xml.Linq;
using vida_plus_out.Item;

namespace vida_plus_out.Mapper
{
    public static class ObjectToXML
    {

        // To XML Responce Item
        //public static string ToXMLResponceItem(this ItemResponse data)
        //{
        //    //ObjectToXML
        //    XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
        //    new XElement("ITEMLIST",
        //    from Item in data.items
        //    select
        //             new XElement("ITEM",
        //                    new XElement("ORACLE_ID", Item.oracle_id),
        //                    new XElement("EPHARMACY_ID", Item.epharmacy_id),
        //                    new XElement("RETURN_STATUS", Item.return_status),
        //                    new XElement("RETURN_MESSAGE", Item.return_message)
        //            )
        //        ));

        //    return P_INV_TRX_SER_TBL.ToString();
        //}

    }
}
