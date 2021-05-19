using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts
{
    public class Enums
    {
        public enum NotificationType {
            Email,
            SMS,
            PushNotification
        }

        public enum NotificationStatus
        {
            Sent = 1,
            Pending,
            Failed,
        }
    }
}


