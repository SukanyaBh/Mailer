﻿using Notification.Concerns;

namespace Notification.Mail.Concerns
{
    public class EmailResponse : NotificationResponse
    {
        public EmailResponse(NotificationStatus status = NotificationStatus.Pending) 
        {
            this.Status = status;
        }
    }
}
