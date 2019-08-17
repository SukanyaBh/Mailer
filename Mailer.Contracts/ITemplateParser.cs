using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailer.Contracts
{
    /// <summary>
    /// Interface for parsing email templates
    /// </summary>
    public interface ITemplateParser
    {
        string Parse(ITemplateRequest request);
    }

    public interface ITemplateRequest
    {
        string HtmlContent { get; set; }
    }

    public class TemplateRequest : ITemplateRequest
    {
        public Dictionary<string, object> Values { get; set; }
        public string HtmlContent { get; set; }
    }
}
