using System;

namespace APIMiddleware.Core.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public int ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string RowVersion { get; set; }
        public DateTime? CREATION_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? LAST_UPDATE_DATE { get; set; }
        public string LAST_UPDATED_BY { get; set; }
    }
}
