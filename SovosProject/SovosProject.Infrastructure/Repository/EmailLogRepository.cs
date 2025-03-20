using Microsoft.EntityFrameworkCore;
using SovosProject.Core.Entities;
using SovosProject.Core.Repository;
using SovosProject.Infrastructure.Data;

namespace SovosProject.Infrastructure.Repository
{
    public class EmailLogRepository : IEmailLogRepository
    {
        private readonly SovosProjectDbContext _context;

        public EmailLogRepository(SovosProjectDbContext context)
        {
            _context=context;
        }
        public async Task AddEmailLogAsync(MailLog mailLog)
        {
            await _context.MailLogs.AddAsync(mailLog);
            await _context.SaveChangesAsync();
        }
    }
}
