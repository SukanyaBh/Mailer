using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Concerns
{
    public class NotificationResponse : INotificationResponse
    {
        public NotificationStatus Status { get; set; }
    }
}
