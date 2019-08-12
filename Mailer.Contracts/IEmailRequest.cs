using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts
{
    public interface IEmailRequest : INotificationRequest
    {
        string Content { get; set; }
        string FromEmail { get; set; }
        List<string> To { get; set; }
        List<string> CC { get; set; }
        List<string> BCC { get; set; }
    }
}
