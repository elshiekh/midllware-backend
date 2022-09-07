using System.Linq;
using System.Xml.Linq;
using ePharmacy_In.DTO;

namespace ePharmacy_In.Mapper
{
    public static class ObjectToXML
    {

        public static string ToXMLCreateItems(this GetItemONhandRequest security)
        {
            XDocument P_INV_TRX_SER_TBL = new XDocument(new XDeclaration("1.0", "UTF - 8", "yes"),
            new XElement("ITEMLIST",
                    from Item in security.Items
                    select new XElement("ITEM",
                            new XElement("ITEM_CODE", Item.item_code),
                            new XElement("INVENTORIES",
                            from inventory in Item.inventory
                            select
                             new XElement("INVENTORY",
                                    new XElement("ORGANIZATION_CODE", inventory.organization_code),
                                    new XElement("SUBINVENTORY_CODE", inventory.subinventory_code)
                            )
                        )
                ))
            );

            return P_INV_TRX_SER_TBL.ToString();
        }

    }
}
