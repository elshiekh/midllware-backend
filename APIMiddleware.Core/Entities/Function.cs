using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIMiddleware.Core.Entities
{
    [Table("MID_FUNCTIONS")]
    public class Function
    {
        [Key]
        [Column("FUNCTION_ID")]
        public int FunctionId { get; set; }

        [Column("FUNCTION_CODE")]
        public string FunctionCode { get; set; }

        [Column("FUNCTION_NAME")]
        public string FunctionName { get; set; }

        [Column("PROJECT_ID")]
        public int ProjectId { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("ENABLED_FLAG")]
        public string EnabledFlag { get; set; }

        [Column("ROW_VERSION")]
        public string RowVersion { get; set; }

        [Column("CREATION_DATE")]
        public DateTime? CREATION_DATE { get; set; }

        [Column("CREATED_BY")]
        public int CREATED_BY { get; set; }

        [Column("LAST_UPDATE_DATE")]
        public DateTime? LAST_UPDATE_DATE { get; set; }

        [Column("LAST_UPDATED_BY")]
        public int LAST_UPDATED_BY { get; set; }

        public virtual Project Project { get; set; }
        //public virtual IEnumerable<Request> Requests { get; set; }
    }
}
