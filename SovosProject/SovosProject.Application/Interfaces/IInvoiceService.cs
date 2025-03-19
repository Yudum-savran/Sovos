using SovosProject.Application.Models;
using SovosProject.Core.Aggregates.Entities;

namespace SovosProject.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task AddInvoiceAsync(InvoiceHeaderDto invoice);
        Task<List<InvoiceHeaderDto>> GetAllInvoicesAsync();
        Task<InvoiceHeaderDto?> GetInvoiceByIdAsync(string invoiceId);
    }
}
