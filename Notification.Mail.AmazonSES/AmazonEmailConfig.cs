using Amazon;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Mail.AmazonSES
{
    public class AmazonEmailConfig
    {
        public RegionEndpoint RegionEndPoint { get; set; }

        public string AwsAccessKeyId { get; set; }

        public string AwsSecretAccessKey { get; set; }

        public AmazonEmailConfig(RegionEndpoint regionEndpoint,string awsAccessKeyId,string awsSecretAccessKey) 
        {
            this.RegionEndPoint = regionEndpoint;
            this.AwsAccessKeyId = awsAccessKeyId;
            this.AwsSecretAccessKey = awsSecretAccessKey;
        }
    }
}
