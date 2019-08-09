using Mailer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mailer.Contracts
{
    public interface INotificationContract
    {
        EmailResponse SendNotification(EmailRequest request);
    }
}
