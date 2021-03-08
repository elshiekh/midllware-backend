using System.Collections.Generic;

namespace HMGOnBaseIn.DTO
{
    public class UpdateDocByKeywordSpecialCaseRequest
    {
        public List<IDictionary<string, string>> PrimaryKeywords { get; set; }
        public List<IDictionary<string, string>> UpdatedKeywords { get; set; }
        public string SC_DocTypeList { get; set; }
    }

    public class UpdateDocByKeywordSpecialCaseResponse
    {
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
