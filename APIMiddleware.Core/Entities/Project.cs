using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMiddleware.Core.Entities
{

    [Table("MID_PROJECTS")]
    public class Project
    {
        [Key]
        [Column("PROJECT_ID")]
        public int ProjectId { get; set; }

        [Column("PROJECT_CODE")]
        public string ProjectCode { get; set; }

        [Column("PROJECT_NAME")]
        public string ProjectName { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("ENABLED_FLAG")]
        public string EnabledFlag { get; set; }

        [Column("ROW_VERSION")]
        public string RowVersion { get; set; }

        [Column("CREATION_DATE")]
        public DateTime? CREATION_DATE { get; set; }

        [Column("CREATED_BY")]
        public string CREATED_BY { get; set; }

        [Column("LAST_UPDATE_DATE")]
        public DateTime? LAST_UPDATE_DATE { get; set; }

        [Column("LAST_UPDATED_BY")]
        public string LAST_UPDATED_BY { get; set; }
        //public virtual IEnumerable<Request> Requests { get; set; }
    }
}
