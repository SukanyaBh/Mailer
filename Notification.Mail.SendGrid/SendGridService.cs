using Notification.Concerns;
using Notification.Contracts;
using Notification.Mail.Concerns;
using Notification.Mail.Contracts;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SendGridHelper = SendGrid.Helpers;

namespace Notification.Mail.SendGrid
{
    public class SendGridService : BaseEmailService<SendGridRawRequest>
    {
        protected SendGridClient _sendGridClient { get; set; }
        public SendGridService(SendGridConfig config, INotificationBodyParser resolver = null) : base(resolver)
        {
            this._sendGridClient = this.GetClient(config);
        }

        public override EmailResponse Notify(EmailRequest<SendGridRawRequest> request)
        {
            var mail = this.PrepareMail(request);
            var response = this._sendGridClient.SendEmailAsync(mail);
            var emailResponse = new EmailResponse();
            emailResponse.RawResponse = response;
            if (response.Result.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                emailResponse.Status = NotificationStatus.Sent;
            }
            else
            {
                emailResponse.Status = NotificationStatus.Failed;
            }
            return emailResponse;
        }

        public override async Task<EmailResponse> NotifyAsync(EmailRequest<SendGridRawRequest> request)
        {
            var mail = this.PrepareMail(request);
            var response = await this._sendGridClient.SendEmailAsync(mail);
            var emailResponse = new EmailResponse();
            emailResponse.RawResponse = response;
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                emailResponse.Status = NotificationStatus.Sent;
            }
            else
            {
                emailResponse.Status = NotificationStatus.Failed;
            }
            return emailResponse;
        }

        public override EmailResponse ParseTemplateAndNotify(INotificationBodyRequest templateRequest, EmailRequest<SendGridRawRequest> request)
        {
            request.Content = this.PraseTemplate(templateRequest);
            return this.Notify(request);
        }

        public override Task<EmailResponse> ParseTemplateAndNotifyAsync(INotificationBodyRequest templateRequest, EmailRequest<SendGridRawRequest> request)
        {
            request.Content = this.PraseTemplate(templateRequest);
            return this.NotifyAsync(request);
        }

        protected virtual SendGridHelper.Mail.SendGridMessage PrepareMail(EmailRequest<SendGridRawRequest> request)
        {
            var rawRequest = request.RawRequest;
            var from = new SendGridHelper.Mail.EmailAddress(request.FromEmail.Email, request.FromEmail.Name);
            var to = new List<SendGridHelper.Mail.EmailAddress>();
            request.To.ForEach(_ => {
                to.Add(new SendGridHelper.Mail.EmailAddress(request.FromEmail.Email, request.FromEmail.Name));
            });

            SendGridHelper.Mail.SendGridMessage msg;
            if (rawRequest != null && rawRequest.UsePreDefinedTemplate)
            {
                msg = SendGridHelper.Mail.MailHelper.CreateSingleTemplateEmailToMultipleRecipients(from, to, rawRequest.TemplateId, rawRequest.DynamicValues);
            }
            else 
            {
                msg = SendGridHelper.Mail.MailHelper.CreateSingleEmailToMultipleRecipients(from, to, request.Subject, request.Content, request.IsBodyHtml ? request.Content : string.Empty);

            }

            return msg;
        }

        protected virtual SendGridClient GetClient(SendGridConfig config)
        {
            var client = new SendGridClient(config.ApiKey,config.Host,config.RequestHeaders,config.Version,config.UrlPath);
            return client;
        }
    }
}
