using Notification.Concerns;
using Notification.Contracts;
using Notification.Mail.Concerns;
using System.Threading.Tasks;

namespace Notification.Mail.Contracts
{
    public interface IEmailContract<T> : INotificationContract<EmailRequest<T>,EmailResponse> where T : IAgentRawRequest
    {
        
    }
}
