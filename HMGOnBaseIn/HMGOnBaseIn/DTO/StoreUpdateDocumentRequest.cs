using System.Collections.Generic;

namespace HMGOnBaseIn.DTO
{
    public class StoreUpdateDocumentRequest
    {
        public long OnBaseDocID { get; set; }
        public string DocTypename { get; set; }
        public int CATEGORY_ID { get; set; } // CATEGORY_ID
        public string CATEGORY_NAME { get; set; } // CATEGORY_NAME

        // public IDictionary<string, string> Metadata { get; set; }
        public List<IDictionary<string, string>> Metadata { get; set; }
    }

    public class StoreUpdateDocumentResponse
    {
        public string docURL { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
