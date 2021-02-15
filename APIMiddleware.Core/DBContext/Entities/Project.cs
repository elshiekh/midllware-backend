using System.Collections.Generic;

namespace APIMiddleware.Core.DBContext.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }

        public virtual IEnumerable<Request> Requests { get; set; }
    }
}

//PROJECT_ID-- Identity Column
//PROJECT_CODE
//PROJECT_NAME
//ROW_VERSION
//CREATION_DATE -- Date with time
//CREATED_BY
//LAST_UPDATE_DATE -- Date with time
//LAST_UPDATED_BY
