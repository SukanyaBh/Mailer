using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Mail.Concerns
{
    public class EmailAttachment
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}
