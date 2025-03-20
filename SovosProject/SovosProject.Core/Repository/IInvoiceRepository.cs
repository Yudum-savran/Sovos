using SovosProject.Core.Entities;

namespace SovosProject.Core.Repository
{
    public interface IInvoiceRepository
    {
        Task AddInvoiceAsync(InvoiceHeader invoice);
        Task<List<InvoiceHeader>> GetAllAsync();
        Task<InvoiceHeader?> GetByIdAsync(string invoiceId);
        Task UpdateAsync(InvoiceHeader invoice);
    }
}
