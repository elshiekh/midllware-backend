using System.Collections.Generic;

namespace HMGOnBaseIn.DTO
{
    public class GetSupplierSiteRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_SUPPLIER_SITE";
        }
        public int VENDOR_ID { get; set; }
        public int ORGANIZATION_ID { get; set; }

    }

    public class GetSupplierSiteResult
    {
        public decimal VENDOR_SITE_ID { get; set; }
        public string VENDOR_SITE_CODE { get; set; }
    }
}
