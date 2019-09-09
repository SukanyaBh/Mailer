using HandlebarsDotNet;
using Mailer.Contracts;
using Mailer.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Core.Services
{
    public abstract class BaseEmailService : IEmailService
    {
        private ITemplateParser TemplateParser { get; set; }

        public BaseEmailService(ITemplateParser parser)
        {
            if (parser == null)
            {
                parser= new TemplateParser();
            }
            this.TemplateParser = parser;
        }

        public abstract EmailResponse Notify(EmailRequest request);

        public abstract Task<EmailResponse> NotifyAsync(EmailRequest request);

        public abstract EmailResponse ParseTemplateAndNotify(ITemplateRequest templateRequest, EmailRequest request);

        public abstract Task<EmailResponse> ParseTemplateAndNotifyAsync(ITemplateRequest templateRequest, EmailRequest request);

        protected string PraseTemplate(ITemplateRequest request)
        {
            return this.TemplateParser.Parse(request);
        }
    }   
}
