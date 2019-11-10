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
    // IEmailContract contract = new SendGridService(sendGridConifg);
    // IEmailContract contract = new AmazonEmailService(amazonEmailConfig);
    
    // Creating Request
    List<EmailAddress> toMails = new List<EmailAddress>();
    toMails.Add(new EmailAddress("toemail"));
    var attachments = new List<Attachments>(); 
    var request = new EmailRequest("Test Email", DateTime.UtcNow)
    {
        FromEmail = new EmailAddress("fromemail"),
        To = toMails,
        Content = "Test Email",
        Attachments = attachments
    };
    
    // Call notify method to send email
    var response =await contract.NotifyAsync(request);
    //Check status of email
    var status = response.Status
    // Raw response of email agent
    var rawResponse = response.RawResponse;
```
# Dynamic Html template

```c#
    // While creating agent instance you can send your own INotificationBodyParser which will parse html template and build dynamic         template
    INotificationBodyParser parser = null; //Create your notification body parser object
    //For body request use INotificationBodyRequest
    IEmailContract contract = new SMTPService(config,parser);
    // To use default INotificationBodyParser no need of sending parser parameter
    
    //Creating Default Email Body request for dynamic template
    string html = ""; // Assign your template string here
     Dictionary<string, object> tokens = new Dictionary<string, object>();
     tokens.Add("Heading", "Test Ignore");
     tokens.Add("Desc", "This came from unit test");
     var bodyRequest = new EmailBodyRequest()
     {
        HtmlContent = html,
        Values = tokens
     };
     
     // Creating Request
    List<EmailAddress> toMails = new List<EmailAddress>();
    toMails.Add(new EmailAddress("toemail"));
    var attachments = new List<Attachments>(); 
    var request = new EmailRequest("Test Email", DateTime.UtcNow)
    {
        FromEmail = new EmailAddress("fromemail"),
        To = toMails,
        Content = "Test Email",
        Attachments = attachments,
        IsBodyHtml = true
    }; 
    
    var response = await contract.ParseTemplateAndNotifyAsync(bodyRequest, request);
        
```
For Dummy html template [click here](https://raw.githubusercontent.com/SukanyaBh/Mailer/master/Notification.UnitTest/Mail/Test_Template.html)
