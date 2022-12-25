using System.Collections.Generic;

namespace Kyriba_Out.DTO
{
    public class DownloadFileResponse
    {
        public List<FileResponse> Files { get; set; }
    }
    public class FileResponse
    {
        public string fileName { get; set; }
        public string fileBase64 { get; set; }
        public string LastModified { get; set; }
    }

    public class DeleteFileResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
