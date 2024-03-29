﻿using System.Collections.Generic;

namespace HMGOnBaseOut.DTO
{
    public class StoreNewDocumentRequest
    {
        public int FileId { get; set; }
        public byte[] FileBytes { get; set; }
        public string FileExtension { get; set; }
        public string DocTypeName { get; set; }
        public IDictionary<string, string> Keywords { get; set; }
    }

    public class StoreNewDocumentResponse
    {
        public string DocURL { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }

    public class StoreDeleteDocumentResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }
    }

    public class StoreUpdateDocumentRequest
    {
        public IDictionary<string, string> primaryKeywords { get; set; }
        public IDictionary<string, string> metaData { get; set; }
    }

    public class StoreUpdateDocumentResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }
    }


}
