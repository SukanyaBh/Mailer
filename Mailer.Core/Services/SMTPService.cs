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

        public IEmailResponse Notify(IEmailRequest request)
        {
            SMTPEmailResponse response = null;
            try
            {
                var smtpRequest = request as SMTPEmailRequest;
                MailMessage mailMessage = new MailMessage();
                mailMessage.Subject = smtpRequest.Subject;
                mailMessage.Body = smtpRequest.Content;
                mailMessage.From = new MailAddress(smtpRequest.FromEmail);
                smtpRequest.To.ForEach(to =>
                {
                    mailMessage.To.Add(new MailAddress(to));
                });
                _client.Send(mailMessage);
                response = new SMTPEmailResponse(NotificationStatus.Sent);
            }
            catch (Exception ex)
            {
                response = new SMTPEmailResponse(NotificationStatus.NotSent);
            }
            return response;
        }

        public SmtpClient GetSMTPClient(SMTPConfig config)
        {
            SmtpClient client = new SmtpClient(config.Host, config.Port);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(config.Username, config.Password);
            return client;
        }
    }
}
