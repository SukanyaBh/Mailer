using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts
{
    public interface INotificationRequest
    {
        int Id { get; set; }
        string Subject { get; set; }
        DateTime SendTime { get; set; }
    }
}
