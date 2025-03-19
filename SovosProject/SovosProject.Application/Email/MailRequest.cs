namespace SovosProject.Application.Email
{
    public class MailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; } = "Fatura Bilgilendirme Maili";
        public string Body { get; set; }
    }
}
