using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Concerns
{
    public class NotificationRequest :INotificationRequest
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime SendTime { get; set; }
    }

    public class NotificationRequest<T> : NotificationRequest, INotificationRequest<T> where T : IAgentRawRequest
    {
        /// <summary>
        /// Gets or sets the raw request of specified agent. All agent specified properties will be included.
        /// </summary>
        /// <value>
        /// The raw request.
        /// </value>
        public T RawRequest { get; set; }
    }

    public class BaseAgentRawRequest : IAgentRawRequest
    {

    }
}
