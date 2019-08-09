using Mailer.Contracts;
using Mailer.Models;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailer.Services
{
    public class ExchangeServerEmailService : INotificationContract
    {
        public ExchangeService _exchangeService { get; set; }
        public string _domain { get; set; }
        public string _userName { get; set; }
        public string _passWord { get; set; }

        public ExchangeServerEmailService(ExchangeVersion exchangeVersion, string domain, string userName, string passWord)
        {
            this._exchangeService = new ExchangeService(exchangeVersion);
            this._domain = domain;
            this._userName = userName;
            this._passWord = passWord;
        }

        public EmailResponse SendNotification(EmailRequest request)
        {
            try
            {
                _exchangeService.Credentials = new WebCredentials(this._userName, this._passWord, this._domain);
                EmailMessage emailMessage = new EmailMessage(_exchangeService);
                emailMessage.Body = new MessageBody(request.BodyType == Enums.BodyType.HTML ? BodyType.HTML : BodyType.Text, request.Content);
                emailMessage.Subject = request.Subject;
                emailMessage.ToRecipients.AddRange(request.To);
                if (request.HasAttachment)
                {
                    request.Attachments.ForEach(_ =>
                    {
                        emailMessage.Attachments.AddFileAttachment(_.Name, _.Content);
                    });
                }
                emailMessage.Save();
                emailMessage.SendAndSaveCopy();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return new EmailResponse(){ SentStatus=Enums.Status.Sent};
        }
    }
}
