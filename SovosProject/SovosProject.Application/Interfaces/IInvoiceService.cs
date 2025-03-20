using SovosProject.Application.Common;
using SovosProject.Application.Models;
using SovosProject.Core.Entities;

namespace SovosProject.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task<GenericResult<bool>> AddInvoiceAsync(InvoiceHeaderDto invoice);
        Task<GenericResult<List<InvoiceHeaderDto>>> GetAllInvoicesAsync();
        Task<GenericResult<InvoiceHeaderDto>> GetInvoiceByIdAsync(string invoiceId);
    }
}
