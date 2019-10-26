using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Notification.Concerns;
using Notification.Contracts;
using Notification.Mail.Concerns;
using Notification.Mail.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Mail.AmazonSES
{
    public class AmazonEmailService : BaseEmailService<BaseAgentRawRequest>
    {
        private AmazonSimpleEmailServiceClient _client { get; set; }

        public AmazonEmailService(AmazonEmailConfig config,INotificationBodyParser parser) :base(parser)
        {
            this._client = this.GetClient(config);
        }


        public override EmailResponse Notify(EmailRequest<BaseAgentRawRequest> request)
        {
            var mailBody = this.PrepareMailBody(request);
            var rawResponse =  this._client.SendEmailAsync(mailBody);
            var response = new EmailResponse();
            response.RawResponse = rawResponse;
            response.Status = NotificationStatus.Pending;
            return response;
        }

        public override async Task<EmailResponse> NotifyAsync(EmailRequest<BaseAgentRawRequest> request)
        {
            var mailBody = this.PrepareMailBody(request);
            var rawResponse =await this._client.SendEmailAsync(mailBody);
            var response = new EmailResponse();
            response.RawResponse = rawResponse;
            if (rawResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                response.Status = NotificationStatus.Sent;
            }
            else 
            {
                response.Status = NotificationStatus.Failed;

            }
            return response;
        }

        public override EmailResponse ParseTemplateAndNotify(INotificationBodyRequest templateRequest, EmailRequest<BaseAgentRawRequest> request)
        {
            throw new NotImplementedException();
        }

        public override Task<EmailResponse> ParseTemplateAndNotifyAsync(INotificationBodyRequest templateRequest, EmailRequest<BaseAgentRawRequest> request)
        {
            throw new NotImplementedException();
        }

        protected virtual SendEmailRequest PrepareMailBody(EmailRequest<BaseAgentRawRequest> request) 
        {
            var body = new Body();
            if (request.IsBodyHtml)
            {
                body.Html = new Content(request.Content);
            }
            else 
            {
                body.Text = new Content(request.Content);
            }

            var message = new Message()
            {
                Subject = new Content(request.Subject),
                Body = body
            };
            var emailRequest = new SendEmailRequest() 
            {
                Source = request.FromEmail.Email,
                Destination = new Destination() 
                { 
                    BccAddresses = request.BCC?.Select(_=>_.Email).ToList(),
                    CcAddresses = request.CC?.Select(_ => _.Email).ToList(),
                    ToAddresses = request.To?.Select(_ => _.Email).ToList()
                },
                Message = message
            };

            return emailRequest;
        }

        protected virtual AmazonSimpleEmailServiceClient GetClient(AmazonEmailConfig config) 
        {
            var client = new AmazonSimpleEmailServiceClient(config.AwsAccessKeyId,config.AwsSecretAccessKey,config.RegionEndPoint);
            return client;
        }
    }
}
