using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts.Models
{
    /// <summary>
    /// Concrete class for SMTP specific emails request
    /// </summary>
    public class SMTPEmailRequest : EmailRequest
    {
        public SMTPEmailRequest(string subject, DateTime sendTime) : base(subject, sendTime)
        {
        }
    }
}
