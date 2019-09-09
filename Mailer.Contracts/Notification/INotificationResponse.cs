using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mailer.Contracts.Enums;

namespace Mailer.Contracts
{
    /// <summary>
    /// Base response interface for all types of notifications
    /// </summary>
    public interface INotificationResponse
    {
        NotificationStatus Status { get; set; }
    }
}
