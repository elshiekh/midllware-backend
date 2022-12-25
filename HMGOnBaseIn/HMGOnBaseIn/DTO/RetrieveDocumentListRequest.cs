using System.Collections.Generic;

namespace HMGOnBaseIn.DTO
{
    public class RetrieveDocumentListRequest
    {
        public List<DOCID> DOC { get; set; }
    }

    public class DOCID
    {
        public long ID { get; set; }
    }

    public class RetrieveDocumentListResponse
    {
        public List<Row> Rows { get; set; }
    }

    public class Row
    {
        public int ID { get; set; }
        public string FileBytes { get; set; }
        public string FileExtension { get; set; }
        public string DocTypeName { get; set; }
        public string Status { get; set; }
        public string Desciption { get; set; }
        //public Doc Doc { get; set; }
    }
    public class Doc
    {
        public int ID { get; set; }
        public string FileBytes { get; set; }
        public string FileExtension { get; set; }
        public string DocTypeName { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
