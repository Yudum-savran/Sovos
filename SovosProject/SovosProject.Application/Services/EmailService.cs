using Microsoft.Extensions.Options;
using MimeKit;
using SovosProject.Application.Email;
using SovosProject.Application.Interfaces;
using SovosProject.Application.Models;
using MailKit.Net.Smtp;
using SovosProject.Application.Common;

namespace SovosProject.Application.Services
{
    public class EmailService:IEmailService
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailService(IOptions<EmailConfiguration> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        public async Task<GenericResult<bool>> SendEmailAsync(MailLogDto mailLogDto)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Gönderen", mailLogDto.FromEmail ?? _emailConfig.SenderEmail));
            mailMessage.To.Add(new MailboxAddress("Alıcı", mailLogDto.ToEmail));
            mailMessage.Subject = mailLogDto.Subject;

            var mailBody = new TextPart("html") { Text = mailLogDto.Body };
            mailMessage.Body = mailBody;
            try
            {
                using var client = new SmtpClient();
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, false);
                await client.AuthenticateAsync(_emailConfig.SenderEmail, _emailConfig.Password);
                await client.SendAsync(mailMessage);
                await client.DisconnectAsync(true);

                return GenericResult<bool>.Success(true);

            }
            catch (Exception ex)
            {
                return GenericResult<bool>.Failure(Error.InternalServerError($"Email gönderilirken hata alındı. {ex.Message}"));
            }
        }
    }
}
