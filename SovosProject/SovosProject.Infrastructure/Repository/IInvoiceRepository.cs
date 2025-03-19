using SovosProject.Core.Aggregates.Entities;

namespace SovosProject.Infrastructure.Repository
{
    public interface IInvoiceRepository
    {
        Task AddAsync(InvoiceHeader invoice);
        Task<List<InvoiceHeader>> GetAllAsync();
        Task<InvoiceHeader?> GetByIdAsync(string invoiceId);
        Task UpdateAsync(InvoiceHeader invoice);
    }
}
