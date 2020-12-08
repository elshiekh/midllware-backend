using System;
using System.Collections.Generic;

namespace HMGONBaseController.DTO
{
    public class GetSuppliersResponse
    {
        public string  VENDOR_NAME { get; set; }
    }

    public class GetSuppliersRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_SUPPLIERS";
        }
        public List<GetSuppliersResponse> response { get; set; }
    }


    public class GetSupplierNumberResponse
    {
        public string SUPPLIER_NUMBER { get; set; }
    }

    public class GetSupplierNumberRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_SUPPLIER_NUMBER";
        }
        public GetSuppliersResponse response { get; set; }
    }
}
