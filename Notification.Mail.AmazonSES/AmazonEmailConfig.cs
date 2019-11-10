using Amazon;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notification.Mail.AmazonSES
{
    /// <summary>
    /// AmazonEmailConfig
    /// </summary>
    public class AmazonEmailConfig
    {
        /// <summary>
        /// Gets or sets the region end point.
        /// </summary>
        /// <value>
        /// The region end point.
        /// </value>
        public RegionEndpoint RegionEndPoint { get; set; }

        /// <summary>
        /// Gets or sets the aws access key identifier.
        /// </summary>
        /// <value>
        /// The aws access key identifier.
        /// </value>
        public string AwsAccessKeyId { get; set; }

        /// <summary>
        /// Gets or sets the aws secret access key.
        /// </summary>
        /// <value>
        /// The aws secret access key.
        /// </value>
        public string AwsSecretAccessKey { get; set; }

        public AmazonEmailConfig(RegionEndpoint regionEndpoint,string awsAccessKeyId,string awsSecretAccessKey) 
        {
            this.RegionEndPoint = regionEndpoint;
            this.AwsAccessKeyId = awsAccessKeyId;
            this.AwsSecretAccessKey = awsSecretAccessKey;
        }
    }
}
