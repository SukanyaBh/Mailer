using Notification.Concerns;
using System.Threading.Tasks;

namespace Notification.Contracts
{
    /// <summary>
    /// INotificationContract
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface INotificationContract<TRequest, TResponse>
        where TRequest : INotificationRequest where TResponse : INotificationResponse
    {
        /// <summary>
        /// Notifies the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        TResponse Notify(TRequest request);

        /// <summary>
        /// Notifies the asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TResponse> NotifyAsync(TRequest request);

        /// <summary>
        /// Parses the template and notify.
        /// </summary>
        /// <param name="templateRequest">The template request.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        TResponse ParseTemplateAndNotify(INotificationBodyRequest templateRequest, TRequest request);

        /// <summary>
        /// Parses the template and notify asynchronous.
        /// </summary>
        /// <param name="templateRequest">The template request.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TResponse> ParseTemplateAndNotifyAsync(INotificationBodyRequest templateRequest, TRequest request);
    }
}
