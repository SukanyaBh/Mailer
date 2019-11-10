using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Mail.Concerns
{
    public class EmailAttachment
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the file content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public byte[] Content { get; set; }

        /// <summary>
        /// Gets or sets the mime type of the content you are attaching. For example, application/pdf or image/jpeg
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }
    }
}
