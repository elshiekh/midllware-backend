namespace HMGOnBaseIn.DTO
{
    public class SetOnBaseURLRequest
    {
        public int P_FILE_ID { get; set; }
        public string P_DOCUMENT_ID { get; set; }
        public string P_URL { get; set; }
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.SET_ONBASE_URL";
        }
    }
    public class SetOnBaseURLResponse
    {
        public string P_STATUS { get; set; }
    }
}
