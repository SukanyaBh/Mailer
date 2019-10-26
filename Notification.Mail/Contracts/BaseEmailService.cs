using Notification.Concerns;
using Notification.Contracts;
using Notification.Mail.Concerns;
using Notification.Mail.Services;

namespace Notification.Mail.Contracts
{
    public abstract class BaseEmailService<T> :BaseNotificationService<EmailRequest<T>,EmailResponse>, IEmailContract<T> where T : IAgentRawRequest
       
    {
        public BaseEmailService(INotificationBodyParser parser = null):base(parser)
        {
            if (this.NotificationBodyParser == null)
            {
                 this.NotificationBodyParser= new EmailBodyResolver();
            }            
        }
    }
}
