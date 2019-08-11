using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts.Models
{
    public class EmailRequest : NotificationRequest
    {
        public EmailRequest(string subject,DateTime sendTime)
        {
            this.Subject = subject;
            this.SendTime = sendTime;
        }
        public string Content { get; set; }
        public string FromEmail { get; set; }
        public List<string> To { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public List<EmailAttachment> Attachments { get; set; }
    }

    public class EmailAttachment {
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}

