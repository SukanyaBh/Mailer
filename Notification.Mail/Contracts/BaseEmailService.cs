using Notification.Concerns;
using Notification.Contracts;
using Notification.Mail.Concerns;
using Notification.Mail.Services;

namespace Notification.Mail.Contracts
{
    public abstract class BaseEmailService<T> :BaseNotificationService<EmailRequest<T>,EmailResponse>, IEmailContract<T> where T : IAgentRawRequest
       
    {
        public BaseEmailService(INotificationBodyResolver notificationBodyResolver = null):base(notificationBodyResolver)
        {
            if (this.NotificationBodyResolver == null)
            {
                 this.NotificationBodyResolver= new EmailBodyResolver();
            }            
        }
    }
}
