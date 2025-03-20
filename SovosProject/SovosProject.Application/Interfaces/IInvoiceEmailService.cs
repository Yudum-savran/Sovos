using SovosProject.Application.Common;
using SovosProject.Application.Email;
using SovosProject.Application.Models;

namespace SovosProject.Application.Interfaces
{
    public interface IInvoiceEmailService
    {
        Task<GenericResult<bool>> InvoiceSendEmailAsync(InvoiceMailLogDto invoiceMailLogDto);
    }
}
