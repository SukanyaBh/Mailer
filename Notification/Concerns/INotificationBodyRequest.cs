using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Concerns
{
    public interface INotificationBodyRequest
    {
        string HtmlContent { get; set; }
    }

    public class NotificationBodyRequest : INotificationBodyRequest
    {
        public Dictionary<string, object> Values { get; set; }
        public string HtmlContent { get; set; }
    }
}
