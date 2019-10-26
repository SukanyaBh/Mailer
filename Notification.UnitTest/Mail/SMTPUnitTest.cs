using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.Concerns;
using Notification.Mail.Concerns;
using Notification.Mail.SMTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Notification.Mail.UnitTest
{
    [TestClass]
    public class SMTPUnitTest
    {

        [TestMethod]
        public void Notify_Test()
        {
            var service = this.GetSMTPService();
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress("mahendrakukka16@gmail.com"));
            var request = new EmailRequest<BaseAgentRawRequest>("Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress("ms.mahendra666@gmail.com"),
                To = toMails,
                Content = "Test Email"
            };
            var result = service.Notify(request);
            Assert.AreEqual(NotificationStatus.Sent, result.Status);
        }

        [TestMethod]
        public async Task NotifyAsync_Test()
        {
            var service = this.GetSMTPService();
            var pdfContent = File.ReadAllBytes("./Mail/dummy.pdf");
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress("mahendrakukka16@gmail.com"));
            var request = new EmailRequest<BaseAgentRawRequest>("Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress("ms.mahendra666@gmail.com"),
                To = toMails,
                Content = "Please Ignore it once",
                Attachments = new List<EmailAttachment>()
            };

            request.Attachments.Add(new EmailAttachment() { Content = pdfContent, Name = "Dummy.pdf" });
            var result = await service.NotifyAsync(request);
            Assert.AreEqual(NotificationStatus.Sent, result.Status);
        }

        [TestMethod]
        public void ParseTemplateAndNotify_Test()
        {
            var html = File.ReadAllText("./Test_Template.html");
            Dictionary<string, object> tokens = new Dictionary<string, object>();
            tokens.Add("Heading", "Test Ignore");
            tokens.Add("Desc", "This came from unit test");
            var bodyRequest = new EmailBodyRequest()
            {
                HtmlContent = html,
                Values = tokens
            };
            var service = this.GetSMTPService();
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress("mahendrakukka16@gmail.com"));
            var request = new EmailRequest<BaseAgentRawRequest>("Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress("ms.mahendra666@gmail.com"),
                To = toMails,
                Content = "Test Email",
                IsBodyHtml = true
            };
            var result = service.ParseTemplateAndNotify(bodyRequest, request);

            Assert.AreEqual(NotificationStatus.Sent, result.Status);
        }

        [TestMethod]
        public async Task ParseTemplateAndNotifyAsync_Test()
        {
            var html = File.ReadAllText("./Test_Template.html");
            Dictionary<string, object> tokens = new Dictionary<string, object>();
            tokens.Add("Heading", "Test Ignore");
            tokens.Add("Desc", "This came from unit test");
            var bodyRequest = new EmailBodyRequest()
            {
                HtmlContent = html,
                Values = tokens
            };
            var service = this.GetSMTPService();
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress("mahendrakukka16@gmail.com"));
            var request = new EmailRequest<BaseAgentRawRequest>("Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress("ms.mahendra666@gmail.com"),
                To = toMails,
                Content = "Test Email",
                IsBodyHtml = true
            };
            var result = await service.ParseTemplateAndNotifyAsync(bodyRequest, request);

            Assert.AreEqual(NotificationStatus.Sent, result.Status);
        }



        private SMTPService GetSMTPService()
        {
            var smtpService = new SMTPService(new SMTPConfig() { Host = "smtp.gmail.com", Port = 587, Username = "ms.mahendra666@gmail.com", Password = "M@hi9847" });
            return smtpService;
        }
    }
}
