using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.Concerns;
using Notification.Mail.Concerns;
using Notification.Mail.SendGrid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Notification.UnitTest.Mail
{
    [TestClass]
    public class SendGridUnitTest
    {

        [TestMethod]
        public void Notify_Test()
        {
            var service = this.GetSendGridService();
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress(""));
            var request = new EmailRequest("Send grid Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress(""),
                To = toMails,
                Content = "Test Email",
            };
            var result = service.Notify(request);
            Assert.AreEqual(NotificationStatus.Pending, result.Status);
        }

        [TestMethod]
        public async Task NotifyAsync_Test()
        {
            var service = this.GetSendGridService();
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress(""));
            var request = new EmailRequest("Send grid  Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress(""),
                To = toMails,
                Content = "Test Email"
            };
            var result =await service.NotifyAsync(request);
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
            var service = this.GetSendGridService();
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress(""));
            var request = new EmailRequest("Send grid  Test Email", DateTime.UtcNow)
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
            var service = this.GetSendGridService();
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress(""));
            var request = new EmailRequest("Send grid  Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress(""),
                To = toMails,
                Content = "Test Email",
                IsBodyHtml = true
            };
            var result = await service.ParseTemplateAndNotifyAsync(bodyRequest, request);

            Assert.AreEqual(NotificationStatus.Sent, result.Status);
        }

        private SendGridService GetSendGridService()
        {
            var apiKey = "";
            var sendGridConifg = new SendGridConfig(apiKey);
            var service = new SendGridService(sendGridConifg);
            return service;
        }
    }
}
