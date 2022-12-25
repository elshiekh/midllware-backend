using System.Collections.Generic;

namespace HMGOnBaseIn.DTO
{
    public class StoreNewDocumentRequest
    {
        public int FileId { get; set; }
        public string FileBytes { get; set; }
        public string FileExtension { get; set; }
        public string DocTypeName { get; set; }
        public List<IDictionary<string, string>> Keywords { get; set; }
        // public Keywords Keywords { get; set; }
    }

    public class StoreNewDocumentResponse
    {
        public string DocURL { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }

    public class Keywords
    {
        public string P_ORACLE_ID { get; set; }
        public string P_ATTACHED_DOCUMENT_ID { get; set; }
        public string P_DOCUMENT_ID { get; set; }
        public string P_ENTITY_NAME { get; set; }
        public string P_CATEGORY_ID { get; set; }
        public string P_CATEGORY_NAME { get; set; }
        public string P_FILE_ID { get; set; }
        public string P_PK1_VALUE { get; set; }
        public string P_PK2_VALUE { get; set; }
        public string P_PK3_VALUE { get; set; }
        public string P_PK4_VALUE { get; set; }
        public string P_PK5_Value { get; set; }
    }
}
