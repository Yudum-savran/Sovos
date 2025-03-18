using SovosProject.Core.Aggregates.Entities;

namespace SovosProject.Infrastructure.Repository
{
    public interface IInvoiceRepository
    {
        Task AddAsync(InvoiceHeader invoice);
        Task<List<InvoiceHeader>> GetAllAsync();
        Task<InvoiceHeader?> GetByIdAsync(string invoiceId);
        Task<List<InvoiceHeader>> GetUnprocessedInvoicesAsync();
        Task UpdateAsync(InvoiceHeader invoice);
    }
}
