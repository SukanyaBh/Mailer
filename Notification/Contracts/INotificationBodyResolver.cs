using Notification.Concerns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Contracts
{
    public interface INotificationBodyResolver
    {
        string Resolve(INotificationBodyRequest request);
    }
}
