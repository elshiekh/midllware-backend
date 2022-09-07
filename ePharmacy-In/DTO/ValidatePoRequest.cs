using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;

namespace ePharmacy_In.DTO
{
    public class ItemsDetailsResponse
    {
        public string P_ITEMS_DETAILS_RESP { get; set; }
        public string P_RETURN_STATUS { get; set; }
        public string P_RETURN_MSG { get; set; }
    }

    public class GetItemONhandRequest
    {
        public string GetSPName()
        {
            return "HMG_EPH_INT_IN_PKG.GET_ITEM_ONHAND";
        }
        public List<Item> Items { get; set; }

    }

    public class Item
    {
        public Item()
        {
            inventory = new List<Inventory>();
        }
        public string item_code { get; set; }
        public List<Inventory> inventory { get; set; }

        //public string organization_code { get; set; }
        //public string subinventory_code { get; set; }
    }

    public class Inventory
    {
        public string organization_code { get; set; }
        public string subinventory_code { get; set; }
    }

    public class CrudItemsResponse
    {
        public string item_code { get; set; }
        public string organization_code { get; set; }
        public string subinventory_code { get; set; }
        public int onhand_qty { get; set; }
        public string return_status { get; set; }
        public string return_msg { get; set; }
    }

}
