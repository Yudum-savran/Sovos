using SovosProject.Core.Aggregates.Entities;

namespace SovosProject.Core.Repository
{
    public interface IInvoiceRepository
    {
        Task AddAsync(InvoiceHeader invoice);
        Task<List<InvoiceHeader>> GetAllAsync();
        Task<InvoiceHeader?> GetByIdAsync(string invoiceId);
        Task UpdateAsync(InvoiceHeader invoice);
    }
}
