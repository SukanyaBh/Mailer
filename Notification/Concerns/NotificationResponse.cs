﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Concerns
{
    public class NotificationResponse : INotificationResponse
    {
        public NotificationStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the raw response of specific agent
        /// </summary>
        /// <value>
        /// The raw response.
        /// </value>
        public object RawResponse { get; set; }
    }
}
