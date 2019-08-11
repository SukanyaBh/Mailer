using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts
{
    public interface INotificationService<TRequest,TResponse> where TRequest:INotificationRequest where TResponse : INotificationResponse
    {
        TResponse Notify(TRequest request);
    }
}
