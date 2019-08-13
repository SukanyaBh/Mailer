using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts.Models
{
    public class SMTPEmailRequest : EmailRequest, IEmailRequest
    {
        public SMTPEmailRequest(string subject, string content) : base(subject,content)
        {
        }
    }
}
