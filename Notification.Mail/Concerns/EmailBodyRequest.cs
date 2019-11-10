using Notification.Concerns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Mail.Concerns
{
    /// <summary>
    /// Default EmailBodyRequest
    /// </summary>
    /// <seealso cref="Notification.Concerns.INotificationBodyRequest" />
    public class EmailBodyRequest : INotificationBodyRequest
    {
        public string HtmlContent { get; set; }

        public Dictionary<string, object> Values { get; set; }
    }
}
