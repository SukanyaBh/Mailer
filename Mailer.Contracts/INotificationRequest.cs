using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts
{
    /// <summary>
    /// Base request interface for all types of notifications
    /// </summary>
    public interface INotificationRequest
    {
        int Id { get; set; }
        string Subject { get; set; }
        DateTime SendTime { get; set; }
    }
}
