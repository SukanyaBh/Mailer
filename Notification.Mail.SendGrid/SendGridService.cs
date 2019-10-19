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
    public class SendGridService : BaseEmailService
    {
        private SendGridClient _sendGridClient { get; set; }
        public SendGridService(SendGridConfig config, INotificationBodyResolver resolver = null) :base(resolver)
        {
            this._sendGridClient = this.GetClient(config);
        }

        public override EmailResponse Notify(EmailRequest request)
        {         
            var from = new SendGridHelper.Mail.EmailAddress(request.FromEmail.Email, request.FromEmail.Name);
            var to = new List<SendGridHelper.Mail.EmailAddress>();
            request.To.ForEach(_=> {
                to.Add(new SendGridHelper.Mail.EmailAddress(request.FromEmail.Email, request.FromEmail.Name));
            });
            var msg = SendGridHelper.Mail.MailHelper.CreateSingleEmailToMultipleRecipients(from, to, request.Subject,request.Content,"");
            var response = this._sendGridClient.SendEmailAsync(msg);
            var emailResponse = new EmailResponse();
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                emailResponse.Status = NotificationStatus.Sent;
            }
            else
            {
                emailResponse.Status = NotificationStatus.Failed;
            }
            return emailResponse;
        }

        public override Task<EmailResponse> NotifyAsync(EmailRequest request)
        {
            throw new NotImplementedException();
        }

        public override EmailResponse ParseTemplateAndNotify(INotificationBodyRequest templateRequest, EmailRequest request)
        {
            throw new NotImplementedException();
        }

        public override Task<EmailResponse> ParseTemplateAndNotifyAsync(INotificationBodyRequest templateRequest, EmailRequest request)
        {
            throw new NotImplementedException();
        }

        private SendGridClient GetClient(SendGridConfig config)
        {
            var client = new SendGridClient(config.ApiKey);
            return client;
        }
    }
}
