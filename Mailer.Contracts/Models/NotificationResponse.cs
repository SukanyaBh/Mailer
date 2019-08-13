using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mailer.Contracts.Enums;

namespace Mailer.Contracts.Models
{
    /// <summary>
    /// Base response class for all types of notifications
    /// </summary>
    public class NotificationResponse:INotificationResponse
    {
        public NotificationStatus Status { get; set; }
    }
}
