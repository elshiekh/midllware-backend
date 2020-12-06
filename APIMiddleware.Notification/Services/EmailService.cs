using APIMiddleware.Notification.Models;
using MailKit.Security;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace APIMiddleware.Notification.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailMessage emailMessage, NotificationMetadata notificationMetadata);
    }

    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmail(EmailMessage emailMessage, NotificationMetadata notificationMetadata)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(notificationMetadata.Sender, notificationMetadata.Sender));
                message.To.Add(new MailboxAddress(notificationMetadata.Reciever, notificationMetadata.Reciever));
                message.Subject = emailMessage.Subject;
                message.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = emailMessage.Content };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    //Like gmail and live
                    //client.Connect("smtp.gmail.com", 587, false);
                    await client.ConnectAsync("mail.drsulaimanalhabib.com", 25, SecureSocketOptions.None);

                    //SMTP server authentication if needed
                    //client.Authenticate("athr", "admin@1234");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
