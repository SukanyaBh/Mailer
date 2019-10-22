using Notification.Concerns;
using Notification.Contracts;
using Notification.Mail.Concerns;
using Notification.Mail.Contracts;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Notification.Mail.SMTP
{
    public class SMTPService : BaseEmailService<BaseAgentRawRequest>
    {
        public SMTPConfig _config { get; set; }
        public SmtpClient _client { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="parser"></param>
        public SMTPService(SMTPConfig config, INotificationBodyResolver parser = null) : base(parser)
        {
            this._config = config;
            this._client = this.GetSMTPClient(this._config);          
        }

        public override EmailResponse Notify(EmailRequest<BaseAgentRawRequest> request)
        {
            EmailResponse response = new EmailResponse();
            MailMessage mailMessage = this.PrepareMailBody(request);
            _client.Send(mailMessage);
            response.Status = (NotificationStatus.Sent);
            return response;
        }

        public override async Task<EmailResponse> NotifyAsync(EmailRequest<BaseAgentRawRequest> request)
        {
            EmailResponse response = new EmailResponse();
            MailMessage mailMessage = this.PrepareMailBody(request);
            await _client.SendMailAsync(mailMessage);
            response.Status = (NotificationStatus.Sent);
            return response;
        }

        public override EmailResponse ParseTemplateAndNotify(INotificationBodyRequest templateRequest, EmailRequest<BaseAgentRawRequest> request)
        {
            var content = this.PraseTemplate(templateRequest);
            request.Content = content;
            return this.Notify(request);
        }

        public override async Task<EmailResponse> ParseTemplateAndNotifyAsync(INotificationBodyRequest templateRequest, EmailRequest<BaseAgentRawRequest> request)
        {
            var content = this.PraseTemplate(templateRequest);
            request.Content = content;
            return await this.NotifyAsync(request);
        }

        private MailMessage PrepareMailBody(EmailRequest<BaseAgentRawRequest> request)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Subject = request.Subject;
            mailMessage.Body = request.Content;
            mailMessage.From = new MailAddress(request.FromEmail.Email);
            mailMessage.IsBodyHtml = request.IsBodyHtml;
            request.To.ForEach(to =>
            {
                mailMessage.To.Add(new MailAddress(to.Email));
            });
            return mailMessage;
        }

        private SmtpClient GetSMTPClient(SMTPConfig config)
        {
            SmtpClient client = new SmtpClient(config.Host, config.Port);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(config.Username, config.Password);
            return client;
        }
    }


}
