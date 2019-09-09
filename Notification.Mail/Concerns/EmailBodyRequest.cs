using Notification.Concerns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Mail.Concerns
{
    public class EmailBodyRequest : INotificationBodyRequest
    {
        public string HtmlContent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Dictionary<string, object> Values { get; set; }
    }
}
