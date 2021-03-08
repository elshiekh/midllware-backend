using System;
using System.Collections.Generic;

namespace APIMiddleware.Core.DBContext.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public int? ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string RowVersion { get; set; }
        public DateTime? CREATION_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? LAST_UPDATE_DATE { get; set; }
        public string LAST_UPDATED_BY { get; set; }
        public virtual IEnumerable<Request> Requests { get; set; }
    }
}
