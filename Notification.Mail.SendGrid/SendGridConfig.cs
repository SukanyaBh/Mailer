using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Mail.SendGrid
{
    /// <summary>
    /// SendGridConfig
    /// </summary>
    public class SendGridConfig
    {
        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>
        /// The API key.
        /// </value>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the URL path.
        /// </summary>
        /// <value>
        /// The URL path.
        /// </value>
        public string UrlPath { get; set; }

        /// <summary>
        /// Gets or sets the request headers.
        /// </summary>
        /// <value>
        /// The request headers.
        /// </value>
        public Dictionary<string, string> RequestHeaders { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendGridConfig"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="host">The host.</param>
        /// <param name="requestHeaders">The request headers.</param>
        /// <param name="version">The version.</param>
        /// <param name="urlPath">The URL path.</param>
        public SendGridConfig(string apiKey,string host = null,Dictionary<string , string> requestHeaders = null, string version = "v3", string urlPath = null) 
        {
            this.ApiKey = apiKey;
            this.Host = host;
            this.Version = version;
            this.UrlPath = urlPath;
            this.RequestHeaders = requestHeaders;
        }
    }
}
