using System.ComponentModel.DataAnnotations;

namespace APIMiddleware.Web.Models
{
    public class SystemPreferenceModel
    {
        [Display(Name = "Id")]
        public int PreferenceId { get; set; }

        [Display(Name = "Code")]
        public string PreferenceCode { get; set; }

        [Display(Name = "Preference Value")]
        public string PreferenceValue { get; set; }

        [Required, Display(Name = "Failded API")]
        public int FaildedAPI { get; set; }

        [Required, Display(Name = "Failded API Time")]
        public int FaildedAPITime { get; set; }

        [Required, Display(Name = "Failded API Count")]
        public int FaildedAPICount { get; set; }

        [Required, Display(Name = "Email Body")]
        public string EmailBody { get; set; }

        [Required, Display(Name = "Email Subject")]
        public string EmailSubject { get; set; }

        [Required, Display(Name = "Email UserName")]
        public string EmailUserName { get; set; }

        [Required, Display(Name = "Email Password")]
        public string EmailPassword { get; set; }

        [Required, Display(Name = "Email Server Port")]
        public int EmailServerPort { get; set; }

        [Required, Display(Name = "Email Reciever")]
        public string EmailReciever { get; set; }

        [Required, Display(Name = "Email Sender")]
        public string EmailSender { get; set; }

        [Required, Display(Name = "Email Smtp Server")]
        public string EmailSmtpServer { get; set; }
    }
}
