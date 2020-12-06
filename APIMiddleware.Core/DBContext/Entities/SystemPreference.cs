using System.ComponentModel.DataAnnotations;

namespace APIMiddleware.Core.DBContext.Entities
{
    public class SystemPreference
    {
        [Key]
        public int PreferenceId { get; set; }

        public string PreferenceCode { get; set; }

        public string PreferenceValue { get; set; }
    }
}
