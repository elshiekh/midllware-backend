using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMGOnBaseIn.DTO
{
    public class StoreUpdateDocumentRequest
    {
        public long OnBaseDocID { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
        public string DocTypename { get; set; }
    }

    public class StoreUpdateDocumentResponse
    {
        public string docURL { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
