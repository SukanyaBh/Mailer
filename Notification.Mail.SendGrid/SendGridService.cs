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
        private SendGridClient _sendGridClient { get; set; }
        public SendGridService(SendGridConfig config, INotificationBodyResolver resolver = null) : base(resolver)
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
            throw new NotImplementedException();
        }

        public override Task<EmailResponse> ParseTemplateAndNotifyAsync(INotificationBodyRequest templateRequest, EmailRequest<SendGridRawRequest> request)
        {
            throw new NotImplementedException();
        }

        private SendGridHelper.Mail.SendGridMessage PrepareMail(EmailRequest<SendGridRawRequest> request)
        {
            var from = new SendGridHelper.Mail.EmailAddress(request.FromEmail.Email, request.FromEmail.Name);
            var to = new List<SendGridHelper.Mail.EmailAddress>();
            request.To.ForEach(_ => {
                to.Add(new SendGridHelper.Mail.EmailAddress(request.FromEmail.Email, request.FromEmail.Name));
            });
            var msg = SendGridHelper.Mail.MailHelper.CreateSingleEmailToMultipleRecipients(from, to, request.Subject, request.Content, "");
            return msg;
        }

        private SendGridClient GetClient(SendGridConfig config)
        {
            var client = new SendGridClient(config.ApiKey);
            return client;
        }

    }
}
