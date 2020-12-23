namespace HMGOnBaseIn.Controllers
{
    public  class RetrieveDocumentRequest
    {
    }

    public class RetrieveDocumentResponse
    {
        public Doc Doc { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
    public class Doc
    {
        public string FileBytes { get; set; }
        public string FileExtension { get; set; }
        public string DocTypeName { get; set; }
        public string Keywords { get; set; }
    } 
}