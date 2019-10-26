using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Mail.SendGrid
{
    public class SendGridConfig
    {
        public string ApiKey { get; set; }

        public string Host { get; set; }

        public string Version { get; set; }

        public string UrlPath { get; set; }

        public Dictionary<string, string> RequestHeaders { get; set; }

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
