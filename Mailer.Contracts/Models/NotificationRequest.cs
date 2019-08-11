﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts.Models
{
    public class NotificationRequest:INotificationRequest
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime SendTime { get; set; }
    }
}
