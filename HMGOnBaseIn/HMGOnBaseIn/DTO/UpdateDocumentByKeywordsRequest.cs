using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMGOnBaseIn.DTO
{
    public class UpdateDocumentByKeywordsRequest
    {
        public List<IDictionary<string, string>> PrimaryKeywaords { get; set; }
        public List<IDictionary<string, string>> UpdatedKeywaords { get; set; }
    }

    public class UpdateDocumentByKeywordsResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }
    }

}
