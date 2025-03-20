using SovosProject.Application.Email;
using SovosProject.Application.Models;

namespace SovosProject.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailLogDto mailLogDto);
    }
}
