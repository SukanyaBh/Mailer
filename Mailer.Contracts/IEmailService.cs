using Mailer.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts
{
    /// <summary>
    /// Base interface for the Email service
    /// Child interface of NotificationService Interface
    /// </summary>
    public interface IEmailService : INotificationService<EmailRequest,EmailResponse>
    {
        EmailResponse ParseTemplateAndNotify(ITemplateRequest templateRequest, EmailRequest request);

        Task<EmailResponse> ParseTemplateAndNotifyAsync(ITemplateRequest templateRequest, EmailRequest request);
    }
}
