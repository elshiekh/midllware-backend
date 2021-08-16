using System;

namespace APIMiddleware.Core.DTO
{
    public class FunctionDTO
    {
        public int FunctionId { get; set; }
        public string FunctionCode { get; set; }
        public string FunctionName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string EnabledFlag { get; set; }
        public string RowVersion { get; set; }
        public DateTime? CREATION_DATE { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime? LAST_UPDATE_DATE { get; set; }
        public int LAST_UPDATED_BY { get; set; }
    }
}
