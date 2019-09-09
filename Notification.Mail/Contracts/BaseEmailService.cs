using Notification.Contracts;
using Notification.Mail.Concerns;
using Notification.Mail.Services;

namespace Notification.Mail.Contracts
{
    public abstract class BaseEmailService :BaseNotificationService<EmailRequest,EmailResponse>
       ,IEmailContract
    {
        public BaseEmailService(INotificationBodyResolver notificationBodyResolver):base(notificationBodyResolver)
        {
            if (notificationBodyResolver == null)
            {
                notificationBodyResolver = new EmailBodyResolver();
            }
        }
    }
}
