using Notification.Concerns;
using Notification.Mail.Concerns;
using Notification.Mail.Contracts;
using Notification.Mail.SendGrid;
using Notification.Mail.SMTP;
using System;
using System.Collections.Generic;

namespace DemoSendEmail
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEmailContract contract = new SMTPService(new SMTPConfig("", "v@rP@ssw0rd=FuckU", 587, "smtp.gmail.com"));
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress(""));
            var request = new EmailRequest("Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress(""),
                To = toMails,
                Content = "Test Email"
            };
            var response = contract.NotifyAsync(request);
        }
    }

    public interface IProduct 
    {
        void Get();
    }

    public interface IProduct<T> : IProduct 
    {
        void GetAll(T request);
    }

    public class Product<T> : IProduct<T>
    {
        public void Get()
        {
            throw new System.NotImplementedException();
        }

        public void GetAll(T request)
        {
            throw new System.NotImplementedException();
        }
    }
}
