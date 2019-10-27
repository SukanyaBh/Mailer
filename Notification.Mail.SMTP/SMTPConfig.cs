namespace Notification.Mail.SMTP
{
    public class SMTPConfig
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }

        public SMTPConfig(string userName, string password, int port, string host)
        {
            this.Username = userName;
            this.Password = password;
            this.Port = port;
            this.Host = host;
        }
    }
}
