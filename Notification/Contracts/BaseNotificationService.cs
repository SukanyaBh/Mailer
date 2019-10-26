using Notification.Concerns;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Contracts
{
    public abstract class BaseNotificationService<TRequest, TResponse> :
        INotificationContract<TRequest, TResponse> where TRequest : INotificationRequest where TResponse : INotificationResponse
    {
        protected INotificationBodyParser NotificationBodyParser { get; set; }

        public BaseNotificationService(INotificationBodyParser notificationBodyResolver)
        {
            this.NotificationBodyParser = notificationBodyResolver;
        }

        public abstract TResponse Notify(TRequest request);

        public abstract Task<TResponse> NotifyAsync(TRequest request);

        public abstract TResponse ParseTemplateAndNotify(INotificationBodyRequest templateRequest, TRequest request);

        public abstract Task<TResponse> ParseTemplateAndNotifyAsync(INotificationBodyRequest templateRequest, TRequest  request);

        protected string PraseTemplate(INotificationBodyRequest request)
        {
            return this.NotificationBodyParser.Parse(request);
        }

    }
}
