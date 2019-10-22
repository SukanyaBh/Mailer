using HandlebarsDotNet;
using Notification.Concerns;
using Notification.Contracts;
using Notification.Mail.Concerns;

namespace Notification.Mail.Services
{
    class EmailBodyResolver : INotificationBodyResolver
    {
        public string Resolve(INotificationBodyRequest request)
        {
            var templateRequest = request as EmailBodyRequest;
            var compiledTemplate = Handlebars.Compile(request.HtmlContent);
            return compiledTemplate.Invoke(templateRequest.Values);
        }
    }
}
