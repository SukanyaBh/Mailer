using Notification.Concerns;
using Notification.Contracts;
using Notification.Mail.Concerns;
using System.Threading.Tasks;

namespace Notification.Mail.Contracts
{
    /// <summary>
    /// Email contract
    /// </summary>
    /// <seealso cref="Notification.Contracts.INotificationContract{Notification.Mail.Concerns.EmailRequest, Notification.Mail.Concerns.EmailResponse}" />
    public interface IEmailContract : INotificationContract<EmailRequest, EmailResponse> 
    {

    }

    public interface IEmailContract<T> : INotificationContract<EmailRequest<T>,EmailResponse> where T : IAgentRawRequest
    {
        
    }
}
