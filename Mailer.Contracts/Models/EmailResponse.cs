using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts.Models
{
    /// <summary>
    /// Base class for Email notifications response
    /// </summary>
    public class EmailResponse:NotificationResponse, IEmailResponse
    {
    }
}
