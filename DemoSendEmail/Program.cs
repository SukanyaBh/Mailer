using Notification.Mail.SMTP;
using System;
using System.Collections.Generic;
using Notification.Mail;
using Notification.Mail.Contracts;
using Notification.Mail.Concerns;

namespace DemoSendEmail
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //INotificationContract notificationService = new SMTPEmailService("smtp.gmail.com", 587, "sukanyabhavanibatla@gmail.com", "$ukanya0494");
            //List<string> toMails = new List<string>() { "sukanya.b@technovert.com"};
            //notificationService.SendNotification(new EmailRequest() { FromMail = "sukanyabhavanibatla@gmail.com", To = toMails, Content="Test", Subject="Test Email" });

            //IEmailContract service = new SMTPService(new SMTPConfig() { Host = "smtp.gmail.com", Port = 587, Username = "ms.mahendra666@gmail.com", Password = "M@hi9847" });
            //List<string> toMails = new List<string>() { "mahendra.k@technovert.com" };
            //Console.WriteLine(service.Notify(new EmailRequest("Test Email", DateTime.UtcNow) { FromEmail = "ms.mahendra666@gmail.com", To = toMails, Content = "Test Email" }).Status);
            //Console.Read();
        }
    }
}
