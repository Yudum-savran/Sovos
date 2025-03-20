using SovosProject.Core.Entities;

namespace SovosProject.Core.Repository
{
    public interface IEmailLogRepository
    {
        Task AddEmailLogAsync(MailLog mailLog);
    }
}
