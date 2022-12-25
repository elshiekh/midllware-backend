namespace HMGOnBaseIn.DTO
{
    public class PostRevisionRequest
    {
        public long OnBaseDocID { get; set; }
        public int FileId { get; set; }
        public string fileBytes { get; set; }
        public string fileExtension { get; set; }
    }

    public class PostRevisionResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
