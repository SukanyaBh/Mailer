using System;
using System.Collections.Generic;
using System.Text;
using static Mailer.Enums;

namespace Mailer.Models
{
    public class EmailRequest
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string FromMail { get; set; }
        public List<string> To { get; set; }
        public BodyType BodyType { get; set; }
        public bool HasAttachment { get; set; }
        public List<Attachment> Attachments { get; set; }
    }

    public class Attachment
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }

}
