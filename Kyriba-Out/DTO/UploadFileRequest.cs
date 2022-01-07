namespace Kyriba_Out.DTO
{
    public class UploadFileRequest
    {
        public string fileByte { get; set; }
        public string fileName { get; set; }
        public string fileExtension { get; set; }
    }
    public class UploadFileResponse
    {
        public string ResponseStatus { get; set; }
        public string ResponseMessage { get; set; }
    }
}
