using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts
{
    public interface IEmailService : INotificationService<IEmailRequest,IEmailResponse>
    {

    }
}
