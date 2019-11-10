using Notification.Concerns;
using Notification.Contracts;
using Notification.Mail.Concerns;
using Notification.Mail.Services;

namespace Notification.Mail.Contracts
{
    public abstract class BaseEmailService :BaseNotificationService<EmailRequest,EmailResponse>, IEmailContract
       
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEmailService"/> class.
        /// </summary>
        /// <param name="parser">The notification body parser if null service will use default parser to parse body or you can pass your custom parser.</param>
        public BaseEmailService(INotificationBodyParser parser = null):base(parser)
        {
            if (this.NotificationBodyParser == null)
            {
                 this.NotificationBodyParser= new EmailBodyResolver();
            }            
        }
    }
}
