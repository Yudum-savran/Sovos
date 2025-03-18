using SovosProject.Core.Aggregates.Entities;

namespace SovosProject.Infrastructure.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public Task AddAsync(InvoiceHeader invoice)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceHeader>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceHeader?> GetByIdAsync(string invoiceId)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceHeader>> GetUnprocessedInvoicesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(InvoiceHeader invoice)
        {
            throw new NotImplementedException();
        }
    }
}
