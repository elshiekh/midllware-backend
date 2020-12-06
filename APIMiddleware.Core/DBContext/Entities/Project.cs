using System.Collections.Generic;

namespace APIMiddleware.Core.DBContext.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }


        public virtual IEnumerable<Request> Requests { get; set; }
    }
}
