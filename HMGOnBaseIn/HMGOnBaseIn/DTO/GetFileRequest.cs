namespace HMGOnBaseIn.DTO
{
    public class GetFileRequest
    {
        public string GetSPName()
        {
            return "HMG_ONBASE_INT_IN_PKG.GET_FILE";
        }
    }

    public class GetFileResponse
    {
        public byte[] FILE_DATA { get; set; }
    }
}
