using SovosProject.Core.Aggregates.Entities;

namespace SovosProject.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task AddInvoiceAsync(InvoiceHeader invoice);
        Task<List<InvoiceHeader>> GetAllInvoicesAsync();
        Task<InvoiceHeader?> GetInvoiceByIdAsync(string invoiceId);
    }
}
