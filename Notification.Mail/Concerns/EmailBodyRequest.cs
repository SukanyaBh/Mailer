using Notification.Concerns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Mail.Concerns
{
    public class EmailBodyRequest : INotificationBodyRequest
    {
        public string HtmlContent { get; set; }

        public Dictionary<string, object> Values { get; set; }
    }
}
