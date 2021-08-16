namespace HMGOnBaseOut.DTO
{
    public class SetOnBaseURLRequest
    {
        public string P_DOCUMENT_ID { get; set; }
        public string P_URL { get; set; }
        public string GetSPName()
        {
            return "HMG_ONBASE_MIG_PKG.SET_ONBASE_URL";
        }
    }
    public class SetOnBaseURLResponse
    {
        public string P_STATUS { get; set; }
    }
}
