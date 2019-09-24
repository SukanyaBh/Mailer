//using Mailer.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Mailer.Models;
//using Mailer.Contracts;
//using Mailer.Core.Services;
//using Mailer.Core.Models;
//using Mailer.Contracts.Models;

//namespace DemoSendEmail
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            //INotificationContract notificationService = new SMTPEmailService("smtp.gmail.com", 587, "sukanyabhavanibatla@gmail.com", "$ukanya0494");
//            //List<string> toMails = new List<string>() { "sukanya.b@technovert.com"};
//            //notificationService.SendNotification(new EmailRequest() { FromMail = "sukanyabhavanibatla@gmail.com", To = toMails, Content="Test", Subject="Test Email" });

//            IEmailService service = new SMTPService(new SMTPConfig() { Host = "smtp.gmail.com", Port = 587, Username = "sukanyabhavanibatla@gmail.com", Password = "$ukanya0494" });
//            List<string> toMails = new List<string>() { "sukanya.b@technovert.com" };
//            Console.WriteLine(service.Notify(new Mailer.Contracts.Models.EmailRequest("Test Email", DateTime.UtcNow) { FromEmail = "sukanyabhavanibatla@gmail.com", To = toMails, Content = "Test Email" }).Status);
//            Console.Read();
//        }
//    }
//}
