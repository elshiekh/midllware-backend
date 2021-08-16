using System;
using System.Collections.Generic;

namespace APIMiddleware.Core.DTO
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string  ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string EnabledFlag { get; set; }
        public string RowVersion { get; set; }
        public DateTime? CREATION_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? LAST_UPDATE_DATE { get; set; }
        public string LAST_UPDATED_BY { get; set; }
        public List<FunctionDTO> Functions { get; set; }
    }
}
