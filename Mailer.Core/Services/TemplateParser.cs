using HandlebarsDotNet;
using Mailer.Contracts;

namespace Mailer.Core.Services
{
    /// <summary>
    /// Used for parsing email templates
    /// </summary>
    public class TemplateParser : ITemplateParser
    {
        public string Parse(ITemplateRequest request)
        {
            var templateRequest = request as TemplateRequest;
            var compiledTemplate = Handlebars.Compile(request.HtmlContent);
            return compiledTemplate.Invoke(templateRequest.Values);
        }
    }
}
