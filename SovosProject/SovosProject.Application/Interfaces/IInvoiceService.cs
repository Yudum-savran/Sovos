using SovosProject.Application.Models;

namespace SovosProject.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task AddInvoiceAsync(InvoiceHeaderDto invoice);
        Task<List<InvoiceHeaderDto>> GetAllInvoicesAsync();
        Task<InvoiceHeaderDto?> GetInvoiceByIdAsync(string invoiceId);
    }
}
