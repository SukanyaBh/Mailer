using Notification.Concerns;

namespace Notification.Mail.Concerns
{
    public class EmailResponse : NotificationResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailResponse"/> class.
        /// </summary>
        /// <param name="status">The status.</param>
        public EmailResponse(NotificationStatus status = NotificationStatus.Pending) 
        {
            this.Status = status;
        }
    }
}
