﻿using Notification.Concerns;
using Notification.Contracts;
using Notification.Mail.Concerns;
using Notification.Mail.Contracts;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Notification.Mail.SMTP
{
    public class SMTPService : BaseEmailService
    {
        private SMTPConfig _config { get; set; }
        private SmtpClient _client { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="parser"></param>
        public SMTPService(SMTPConfig config, INotificationBodyParser parser = null) : base(parser)
        {
            this._config = config;
            this._client = this.GetSMTPClient(this._config);          
        }

        public override EmailResponse Notify(EmailRequest request)
        {
            EmailResponse response = new EmailResponse();
            MailMessage mailMessage = this.PrepareMailBody(request);
            _client.Send(mailMessage);
            response.Status = (NotificationStatus.Pending);
            return response;
        }

        public override async Task<EmailResponse> NotifyAsync(EmailRequest request)
        {
            EmailResponse response = new EmailResponse();
            MailMessage mailMessage = this.PrepareMailBody(request);
            await _client.SendMailAsync(mailMessage);
            response.Status = (NotificationStatus.Sent);
            return response;
        }

        public override EmailResponse ParseTemplateAndNotify(INotificationBodyRequest templateRequest, EmailRequest request)
        {
            request.Content = this.PraseTemplate(templateRequest);
            return this.Notify(request);
        }

        public override async Task<EmailResponse> ParseTemplateAndNotifyAsync(INotificationBodyRequest templateRequest, EmailRequest request)
        {
            request.Content = this.PraseTemplate(templateRequest);
            return await this.NotifyAsync(request);
        }

        protected virtual MailMessage PrepareMailBody(EmailRequest request)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Subject = request.Subject;
            mailMessage.Body = request.Content;
            mailMessage.From = new MailAddress(request.FromEmail.Email, request.FromEmail.Name);
            mailMessage.IsBodyHtml = request.IsBodyHtml;
            request.To.ForEach(to =>
            {
                mailMessage.To.Add(new MailAddress(to.Email,to.Name));
            });
            var index = 0;
            request.Attachments?.ForEach((_)=> {
                var stream = new MemoryStream(_.Content);
                mailMessage.Attachments.Insert(index,new Attachment(stream,_.Name));
                index++;
            });
            return mailMessage;
        }

        protected virtual SmtpClient GetSMTPClient(SMTPConfig config)
        {
            SmtpClient client = new SmtpClient(config.Host, config.Port);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(config.Username, config.Password);
            return client;
        }
    }


}
