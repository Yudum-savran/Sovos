using Microsoft.EntityFrameworkCore;
using SovosProject.Core.Entities;
using SovosProject.Core.Repository;
using SovosProject.Infrastructure.Data;

namespace SovosProject.Infrastructure.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly SovosProjectDbContext _context;

        public InvoiceRepository(SovosProjectDbContext context)
        {
            _context=context;
        }

        public async Task AddAsync(InvoiceHeader invoice)
        {
            await _context.InvoiceHeaders.AddAsync(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<List<InvoiceHeader>> GetAllAsync()
        {
            return await _context.InvoiceHeaders.Include(i => i.InvoiceLines).ToListAsync();
        }

        public async Task<InvoiceHeader?> GetByIdAsync(string invoiceId)
        {
            return await _context.InvoiceHeaders.Include(i => i.InvoiceLines)
             .FirstOrDefaultAsync(i => i.InvoiceId == invoiceId);
        }

        public async Task UpdateAsync(InvoiceHeader invoice)
        {
            _context.InvoiceHeaders.Update(invoice);
            await _context.SaveChangesAsync();
        }
    }
}
