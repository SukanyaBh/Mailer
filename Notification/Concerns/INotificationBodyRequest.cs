using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Concerns
{
    /// <summary>
    /// INotificationBodyRequests
    /// </summary>
    public interface INotificationBodyRequest
    {
        string HtmlContent { get; set; }
    }

    /// <summary>
    /// Default Notification Body request
    /// </summary>
    /// <seealso cref="Notification.Concerns.INotificationBodyRequest" />
    public class NotificationBodyRequest : INotificationBodyRequest
    {
        public Dictionary<string, object> Values { get; set; }
        public string HtmlContent { get; set; }
    }
}
