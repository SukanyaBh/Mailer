using Notification.Concerns;
using System.Threading.Tasks;

namespace Notification.Contracts
{
    public interface INotificationContract<TRequest, TResponse>
        where TRequest : INotificationRequest where TResponse : INotificationResponse
    {
        TResponse Notify(TRequest request);

        Task<TResponse> NotifyAsync(TRequest request);

        TResponse ParseTemplateAndNotify(INotificationBodyRequest templateRequest, TRequest request);

        Task<TResponse> ParseTemplateAndNotifyAsync(INotificationBodyRequest templateRequest, TRequest request);
    }
}
