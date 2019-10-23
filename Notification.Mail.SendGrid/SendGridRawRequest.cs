using Notification.Concerns;
using Notification.Mail.Concerns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Mail.SendGrid
{
    public class SendGridRawRequest : BaseAgentRawRequest, IAgentRawRequest
    {
        public bool UsePreDefinedTemplate { get; set; }

        public string TemplateId { get; set; }

        public object DynamicValues { get; set; }

    }
}
