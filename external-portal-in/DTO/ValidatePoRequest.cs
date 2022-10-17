namespace external_portal_in.DTO
{
    public class ValidatePoRequest
    {
        public string GetSPName()
        {
            return "HMG_EXT_PORTAL_INT_IN_PKG.VALIDATE_PO";
        }
        public int? P_ORG_ID { get; set; } = null;
        public string P_PO_NUMBER { get; set; } = null;
    }

    public class ValidatePoResponse
    {
        public string P_FOUND_FLAG { get; set; }
    }
}
