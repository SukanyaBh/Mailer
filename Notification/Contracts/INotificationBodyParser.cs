using Notification.Concerns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Contracts
{
    /// <summary>
    /// Abstract for Notificaiton body parser
    /// </summary>
    public interface INotificationBodyParser
    {
        /// <summary>
        /// Parses the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        string Parse(INotificationBodyRequest request);
    }
}
