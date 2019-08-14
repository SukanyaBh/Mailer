using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts
{
    /// <summary>
    /// Base interface for the notification service
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface INotificationService<TRequest,TResponse> where TRequest:INotificationRequest where TResponse : INotificationResponse
    {
        TResponse Notify(TRequest request);

        Task<TResponse> NotifyAsync(TRequest request);
    }
}
