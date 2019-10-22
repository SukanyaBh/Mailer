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
}
