# Notification
Email sending implemented in a generic way

# Email Usage
```c#
    // SMTP configuration
    var config = new SMTPConfig("email", "password", 587, "smtp.gmail.com");
    
    // Creating SMTPSevice object.
    IEmailContract contract = new SMTPService(config);
    
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
    
