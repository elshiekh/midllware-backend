namespace HMGOnBaseIn.DTO
{
    public class GetEngineerNameRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_ENGINEER_NAME";
        }
        public GetEngineerNameResponse response { get; set; }
    }

    public class GetEngineerNameResponse
    {
        public string ENGINEER_NAME { get; set; }
    }
}
