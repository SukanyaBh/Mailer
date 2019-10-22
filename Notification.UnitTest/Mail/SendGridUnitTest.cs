using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.Concerns;
using Notification.Mail.Concerns;
using Notification.Mail.SendGrid;
using System;
using System.Collections.Generic;
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
            toMails.Add(new EmailAddress("mahendrakukka16@gmail.com"));
            var request = new EmailRequest<SendGridRawRequest>("Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress("ms.mahendra666@gmail.com"),
                To = toMails,
                Content = "Test Email",
            };
            var result = service.Notify(request);
            Assert.AreEqual(NotificationStatus.Sent, result.Status);
        }

        [TestMethod]
        public async Task NotifyAsync_Test()
        {
            var service = this.GetSendGridService();
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress("mahendrakukka16@gmail.com"));
            var request = new EmailRequest<SendGridRawRequest>("Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress("ms.mahendra666@gmail.com"),
                To = toMails,
                Content = "Test Email"
            };
            var result =await service.NotifyAsync(request);
            Assert.AreEqual(NotificationStatus.Sent, result.Status);
        }

        private SendGridService GetSendGridService()
        {
            var sendGridConifg = new SendGridConfig()
            {
                ApiKey = "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"
            };
            var service = new SendGridService(sendGridConifg);
            return service;
        }
    }
}
