namespace APIMiddleware.Core.DTO
{
    public class SystemEnums
    {
        public enum PreferenceCode
        {
            FaildedAPI = 1,

            FaildedAPITime,
            FaildedAPICount,

            EmailBody,
            EmailSubject,

            EmailUserName,
            EmailPassword,
            EmailServerPort,
            EmailReciever,
            EmailSender,
            EmailSmtpServer,
        }


        public enum Project
        {
            WEBAPI1 = 101,
            WEBAPI2 = 102,
        }
    }
}
