using Notification.Concerns;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Contracts
{
    /// <summary>
    /// Base Notification service
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <seealso cref="Notification.Contracts.INotificationContract{TRequest, TResponse}" />
    public abstract class BaseNotificationService<TRequest, TResponse> :
        INotificationContract<TRequest, TResponse> where TRequest : INotificationRequest where TResponse : INotificationResponse
    {
        /// <summary>
        /// Gets or sets the notification body parser.
        /// </summary>
        /// <value>
        /// The notification body parser.
        /// </value>
        protected INotificationBodyParser NotificationBodyParser { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseNotificationService{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="notificationBodyResolver">The notification body resolver.</param>
        public BaseNotificationService(INotificationBodyParser notificationBodyResolver)
        {
            this.NotificationBodyParser = notificationBodyResolver;
        }

        /// <summary>
        /// Notifies the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public abstract TResponse Notify(TRequest request);

        /// <summary>
        /// Notifies the asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public abstract Task<TResponse> NotifyAsync(TRequest request);

        /// <summary>
        /// Parses the template and notify.
        /// Use this method when body need to parsed. You can use NotificationBodyRequest to send type of request you want to send.
        /// </summary>
        /// <param name="templateRequest">The template request.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public abstract TResponse ParseTemplateAndNotify(INotificationBodyRequest templateRequest, TRequest request);

        /// <summary>
        /// Parses the template and notify asynchronous.
        /// Use this method when body need to parsed. You can use NotificationBodyRequest to send type of request you want to send.
        /// </summary>
        /// <param name="templateRequest">The template request.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public abstract Task<TResponse> ParseTemplateAndNotifyAsync(INotificationBodyRequest templateRequest, TRequest  request);

        protected string PraseTemplate(INotificationBodyRequest request)
        {
            return this.NotificationBodyParser.Parse(request);
        }
    }
}
