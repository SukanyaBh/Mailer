using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mailer.Contracts.Enums;

namespace Mailer.Contracts.Models
{
    /// <summary>
    /// Concrete class for SMTP specific email response
    /// </summary>
    public class SMTPEmailResponse : EmailResponse
    {
        public SMTPEmailResponse(NotificationStatus status)
        {
                
        }
    }
}
