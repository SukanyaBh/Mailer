using Notification.Concerns;
using System;
using System.Collections.Generic;

namespace Notification.Mail.Concerns
{

    public class EmailRequest : NotificationRequest
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

        /// <summary>
        /// Gets or sets the html content or plan text content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets from email.
        /// </summary>
        /// <value>
        /// From email.
        /// </value>
        public EmailAddress FromEmail { get; set; }

        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        public List<EmailAddress> To { get; set; }

        /// <summary>
        /// Gets or sets the cc.
        /// </summary>
        /// <value>
        /// The cc.
        /// </value>
        public List<EmailAddress> CC { get; set; }

        /// <summary>
        /// Gets or sets the BCC.
        /// </summary>
        /// <value>
        /// The BCC.
        /// </value>
        public List<EmailAddress> BCC { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>
        /// The attachments.
        /// </value>
        public List<EmailAttachment> Attachments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is body HTML.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is body HTML; otherwise, <c>false</c>.
        /// </value>
        public bool IsBodyHtml { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is set high importance.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is set high importance; otherwise, <c>false</c>.
        /// </value>
        public bool IsSetHighImportance { get; set; }
    }

    public class EmailRequest<T> : NotificationRequest<T> where T : IAgentRawRequest
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
