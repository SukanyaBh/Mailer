using Mailer.Contracts;
using Mailer.Contracts.Models;
using Mailer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static Mailer.Contracts.Enums;

namespace Mailer.Core.Services
{
    public class SMTPService : IEmailService
    {
        public SMTPConfig _config { get; set; }
        public SmtpClient _client { get; set; }

        public SMTPService(SMTPConfig config)
        {
            this._config = config;
            this._client = this.GetSMTPClient(this._config);
        }

        public EmailResponse Notify(EmailRequest request)
        {
            EmailResponse response = new EmailResponse();
            try
            {

                MailMessage mailMessage = this.PrepareMailBody(request);
                _client.Send(mailMessage);
                response.Status=(NotificationStatus.Sent);
            }
            catch (Exception ex)
            {
                response.Status = NotificationStatus.Failed;
            }
            return response;
        }

        public async Task<EmailResponse> NotifyAsync(EmailRequest request)
        {
            EmailResponse response = new EmailResponse();
            try
            {

                MailMessage mailMessage = this.PrepareMailBody(request);
                await _client.SendMailAsync(mailMessage);
                response.Status = (NotificationStatus.Sent);
            }
            catch (Exception ex)
            {
                response.Status = NotificationStatus.Failed;
            }
            return response;
        }

        private MailMessage PrepareMailBody(EmailRequest request)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Subject = request.Subject;
            mailMessage.Body = request.Content;
            mailMessage.From = new MailAddress(request.FromEmail);
            request.To.ForEach(to =>
            {
                mailMessage.To.Add(new MailAddress(to));
            });
            return mailMessage;
        }

        private SmtpClient GetSMTPClient(SMTPConfig config)
        {
            SmtpClient client = new SmtpClient(config.Host, config.Port);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(config.Username, config.Password);
            return client;
        }
    }
}
