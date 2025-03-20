using SovosProject.Application.Common;
using SovosProject.Application.Models;

namespace SovosProject.Application.Interfaces
{
    public interface IEmailService
    {
        Task<GenericResult<bool>> SendEmailAsync(MailLogDto mailLogDto);
    }
}
