using Microsoft.Extensions.Options;
using MimeKit;
using SovosProject.Application.Email;
using SovosProject.Application.Interfaces;
using MailKit.Net.Smtp;
using SovosProject.Application.Models;


namespace SovosProject.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;

        public InvoiceHeaderDto InvoiceHeader { get; set; }

        public EmailService(IOptions<EmailConfiguration> emailConfig)
        {
            _emailConfig=emailConfig.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var mailMessage = new MimeMessage();
                mailMessage.From.Add(new MailboxAddress("Gönderen", "savran.yudum@gmail.com"));
                mailMessage.To.Add(new MailboxAddress("Alıcı", "1997yudum@gmail.com"));
                mailMessage.Subject= mailRequest.Subject;

                string bodyText = $"{InvoiceHeader.TotalItems} kalem ürün içeren {InvoiceHeader.InvoiceId} nolu faturanız başarıyla işlenmiştir.";

                mailMessage.Body = new TextPart("Invoice")
                {
                    Text = bodyText
                };


                using var client = new SmtpClient();
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, false);
                await client.AuthenticateAsync(_emailConfig.SenderEmail, _emailConfig.Password);
                await client.SendAsync(mailMessage);
                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                throw new Exception("Mail sender not success",ex);
            }
            

        }
    }
}
