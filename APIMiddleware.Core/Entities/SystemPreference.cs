using System.ComponentModel.DataAnnotations;

namespace APIMiddleware.Core.Entities
{
    public class SystemPreference
    {
        [Key]
        public int PreferenceId { get; set; }

        public string PreferenceCode { get; set; }

        public string PreferenceValue { get; set; }
    }
}
