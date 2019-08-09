using Mailer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mailer.Models;
using Mailer.Contracts;

namespace DemoSendEmail
{
    public class Program
    {
        public static void Main(string[] args)
        {
            INotificationContract notificationService = new SMTPEmailService("smtp.gmail.com", 587, "sukanyabhavanibatla@gmail.com", "$ukanya0494");
            List<string> toMails = new List<string>() { "sukanya.b@technovert.com"};
            notificationService.SendNotification(new EmailRequest() { FromMail = "sukanyabhavanibatla@gmail.com", To = toMails, Content="Test", Subject="Test Email" });
        }
    }
}
