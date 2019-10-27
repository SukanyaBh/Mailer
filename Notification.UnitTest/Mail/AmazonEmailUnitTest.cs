﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notification.Concerns;
using Notification.Mail.AmazonSES;
using Notification.Mail.Concerns;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notification.UnitTest.Mail
{
    [TestClass]
    public class AmazonEmailUnitTest
    {
        [TestMethod]
        public void Notify_Test()
        {
            var service = this.GetAmazonEmailService();
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress("mahendrakukka16@gmail.com"));
            var request = new EmailRequest<BaseAgentRawRequest>("Amazon ses Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress("ms.mahendra666@gmail.com"),
                To = toMails,
                Content = "Test Email",
            };
            var result = service.Notify(request);
            Assert.AreEqual(NotificationStatus.Pending, result.Status);
        }

        [TestMethod]
        public async Task NotifyAsync_Test()
        {
            var service = this.GetAmazonEmailService();
            List<EmailAddress> toMails = new List<EmailAddress>();
            toMails.Add(new EmailAddress("mahendrakukka16@gmail.com"));
            var request = new EmailRequest<BaseAgentRawRequest>("Send grid  Test Email", DateTime.UtcNow)
            {
                FromEmail = new EmailAddress("ms.mahendra666@gmail.com"),
                To = toMails,
                Content = "Test Email"
            };
            var result = await service.NotifyAsync(request);
            Assert.AreEqual(NotificationStatus.Sent, result.Status);
        }

        private AmazonEmailService GetAmazonEmailService()
        {
            
            var amazonEmailConfig = new AmazonEmailConfig(Amazon.RegionEndpoint.USEast1, "AKIAIYHOE24EJQ75ZCHQ", "TeYY50TsRepRFR6LVVdDeP8BV2c1ADqVYZb8GR0y");
            var service = new AmazonEmailService(amazonEmailConfig);
            return service;
        }
    }
}
