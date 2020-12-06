using System.ComponentModel.DataAnnotations;

namespace APIMiddleware.Core.DTO
{
    public class SystemPreferenceDTO
    {
        public int PreferenceId { get; set; }
        public string PreferenceCode { get; set; }
        public string PreferenceValue { get; set; }
        public int FaildedAPI { get; set; }
        public int FaildedAPITime { get; set; }
        public int FaildedAPICount { get; set; }
        public string EmailBody { get; set; }
        public string EmailSubject { get; set; }
        public string EmailUserName { get; set; }
        public string EmailPassword { get; set; }
        public int EmailServerPort { get; set; }
        public string EmailReciever { get; set; }
        public string EmailSender { get; set; }
        public string EmailSmtpServer { get; set; }
    }
}
