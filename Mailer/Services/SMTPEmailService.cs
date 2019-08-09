using Mailer.Contracts;
using Mailer.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Mailer.Services
{
    public class SMTPEmailService:INotificationContract
    {
        public string _host { get; set; }
        public int _port { get; set; }
        public string _userName { get; set; }
        public string _passWord { get; set; }

        public SMTPEmailService(string host, int port, string userName, string passWord)
        {
            this._host = host;
            this._port = port;
            this._userName = userName;
            this._passWord = passWord;
        }

        public EmailResponse SendNotification(EmailRequest request)
        {
            SmtpClient client = new SmtpClient(this._host, this._port);
            client.EnableSsl = true;
            try
            {
                client.Credentials = new NetworkCredential(this._userName, this._passWord);
                MailAddress fromMail = new MailAddress(request.FromMail);
                //MailAddressCollection toMails = new MailAddressCollection();

                MailMessage mailMessage = new MailMessage();
                mailMessage.Subject = request.Subject;
                mailMessage.Body = request.Content;
                if (request.Attachments!=null && request.Attachments.Count!=0)
                {
                    request.Attachments.ForEach(_ =>
                    {
                    //mailMessage.Attachments.Add(new System.Net.Mail.Attachment() { });
                });
                }
                mailMessage.From = new MailAddress(request.FromMail);
                request.To.ForEach(_ =>
                {
                    mailMessage.To.Add(new MailAddress(_));
                });
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return new EmailResponse() { SentStatus=Enums.Status.Sent};
        }
    }
}
