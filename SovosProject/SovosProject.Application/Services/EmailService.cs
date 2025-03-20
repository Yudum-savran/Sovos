using Microsoft.Extensions.Options;
using MimeKit;
using SovosProject.Application.Email;
using SovosProject.Application.Interfaces;
using MailKit.Net.Smtp;
using SovosProject.Application.Models;
using SovosProject.Core.Entities;
using SovosProject.Core.Repository;
using SovosProject.Application.Job;


namespace SovosProject.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly IEmailLogRepository _emailLogRepository;

        public InvoiceHeaderDto InvoiceHeader { get; set; }

        public EmailService(IOptions<EmailConfiguration> emailConfig, IEmailLogRepository emailLogRepository)
        {
            _emailConfig=emailConfig.Value;
            _emailLogRepository=emailLogRepository;
        }

        public async Task SendEmailAsync(MailLogDto mailLogDto)
        {
            var mailLog = new MailLog
            {
                FromEmail = mailLogDto.FromEmail ?? _emailConfig.SenderEmail,
                ToEmail = mailLogDto.ToEmail,
                Subject = mailLogDto.Subject,
                Body = mailLogDto.Body
            };

            try
            {
                var mailMessage = new MimeMessage();
                mailMessage.From.Add(new MailboxAddress("Gönderen", mailLogDto.FromEmail));
                mailMessage.To.Add(new MailboxAddress("Alıcı", mailLogDto.ToEmail));
                mailMessage.Subject= mailLogDto.Subject;

                //string bodyText = $"{InvoiceHeader.TotalItems} kalem ürün içeren {InvoiceHeader.InvoiceId} nolu faturanız başarıyla işlenmiştir.";
                string bodyText = $"{mailLogDto.Body}";

                mailMessage.Body = new TextPart("plain")
                {
                    Text = bodyText
                };


                using var client = new SmtpClient();
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, false);
                await client.AuthenticateAsync(_emailConfig.SenderEmail, _emailConfig.Password);
                await client.SendAsync(mailMessage);
                await client.DisconnectAsync(true);
                 
                mailLog.IsSuccess = true;
                mailLog.ErrorMessage= null;
                Console.WriteLine("Mail başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                mailLog.IsSuccess= false;
                mailLog.ErrorMessage= ex.Message;
                Console.WriteLine($"Mail gönderilirken hata oluştu: {ex.Message}");
                throw new Exception("Mail sender not success", ex);
            }

            await _emailLogRepository.AddEmailLogAsync(mailLog);

        }
    }
}
