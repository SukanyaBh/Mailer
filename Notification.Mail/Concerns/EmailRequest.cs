using Notification.Concerns;
using System;
using System.Collections.Generic;

namespace Notification.Mail.Concerns
{
    public class EmailRequest<T> : NotificatonRequest<T>
    {
        /// <summary>
        /// Base class for Email notifications request
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        public EmailRequest(string subject, DateTime sendTime)
        {
            this.Subject = subject;
            this.SendTime = sendTime;
        }

        public string Content { get; set; }
        public EmailAddress FromEmail { get; set; }
        public List<EmailAddress> To { get; set; }
        public List<EmailAddress> CC { get; set; }
        public List<EmailAddress> BCC { get; set; }
        public List<EmailAttachment> Attachments { get; set; }

        public bool IsBodyHtml { get; set; }

        public bool IsSetHighImportance { get; set; }
    }

    public class EmailAddress
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public EmailAddress(string email, string name = null)
        {
            this.Email = email;
            this.Name = name ?? email;
        }
    }
}
