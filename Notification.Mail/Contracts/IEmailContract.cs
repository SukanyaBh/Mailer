using Notification.Contracts;
using Notification.Mail.Concerns;
using System.Threading.Tasks;

namespace Notification.Mail.Contracts
{
    public interface IEmailContract : INotificationContract<EmailRequest,EmailResponse>
    {
        
    }
}
