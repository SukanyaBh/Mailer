# Notification
Common wrapper for sending notificaions using agents like SMTP, Sendgrid, Amazonses...

## Installation

Commands to install SMTP, Sendgrid , Amazonses Wrappers

```bash
Install-Package Notification.Mail.SMTP -Version 1.1.1
Install-Package Notification.Mail.SendGrid -Version 1.1.1
Install-Package Notification.Mail.AmazonSES -Version 1.1.1
```
Nuget links:
[Notification.Mail.SMTP](https://www.nuget.org/packages/Notification.Mail.SMTP/),
[Notification.Mail.SendGrid](https://www.nuget.org/packages/Notification.Mail.SendGrid/),
[Notification.Mail.Amazonses](https://www.nuget.org/packages/Notification.Mail.AmazonSES/)

# Email Usage
```c#
    // configuration
    var config = new SMTPConfig("email", "password", 587, "smtp.gmail.com");
    //var amazonEmailConfig = new SendGridConfig(Region, "accesskeyId", "accessKey");
    //var sendGridConifg = new AmazonEmailConfig("apiKey");
    
    // Creating Agent instance.
    IEmailContract contract = new SMTPService(config);
    // IEmailContract contract = new SendGridService(config);
    // IEmailContract contract = new AmazonEmailService(config);
    
    // Creating Request
    List<EmailAddress> toMails = new List<EmailAddress>();
    toMails.Add(new EmailAddress("toemail"));
    var request = new EmailRequest("Test Email", DateTime.UtcNow)
    {
        FromEmail = new EmailAddress("fromemail"),
        To = toMails,
        Content = "Test Email"
    };
    
    // Call notify method to send email
    var response =await contract.NotifyAsync(request);
    
    // Raw response of email agent
    var rawResponse = response.RawResponse;
    
