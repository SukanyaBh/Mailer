using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.Concerns;
using Notification.Mail.Concerns;
using Notification.Mail.SMTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Notification.UnitTest.Mail
{
    [TestClass]
    public class SMTPUnitTest
    {

        [TestMethod]
        public void Notify_Test()
        {
            var service = this.GetSMTPService();
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress(""));
            var request = new EmailRequest("Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress(""),
                To = toMails,
                Content = "Test Email"
            };
            var result = service.Notify(request);
            Assert.AreEqual(NotificationStatus.Pending, result.Status);
        }

        [TestMethod]
        public async Task NotifyAsync_Test()
        {
            var service = this.GetSMTPService();
            var pdfContent = File.ReadAllBytes("./Mail/dummy.pdf");
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress(""));
            var request = new EmailRequest("Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress(""),
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
            var html = File.ReadAllText("./Mail/Test_Template.html");
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
            toMails.Add(new EmailAddress(""));
            var request = new EmailRequest("Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress(""),
                To = toMails,
                Content = "Test Email",
                IsBodyHtml = true
            };
            var result = service.ParseTemplateAndNotify(bodyRequest, request);

            Assert.AreEqual(NotificationStatus.Pending, result.Status);
        }

        [TestMethod]
        public async Task ParseTemplateAndNotifyAsync_Test()
        {
            var html = File.ReadAllText("./Mail/Test_Template.html");
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
            toMails.Add(new EmailAddress(""));
            var request = new EmailRequest("Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress(""),
                To = toMails,
                Content = "Test Email",
                IsBodyHtml = true
            };
            var result = await service.ParseTemplateAndNotifyAsync(bodyRequest, request);

            Assert.AreEqual(NotificationStatus.Sent, result.Status);
        }



        private SMTPService GetSMTPService()
        {
            var smtpService = new SMTPService(new SMTPConfig("","", 587, "smtp.gmail.com"));
            return smtpService;
        }
    }
}
