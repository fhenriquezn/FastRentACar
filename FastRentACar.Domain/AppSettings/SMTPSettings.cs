namespace FastRentACar.Domain.AppSettings
{
    public class SMTPSettings
    {
        public string Host { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public string FromMail { get; set; }

        public string FromName { get; set; }

        public bool EnableSsl { get; set; }
    }
}
