using SovosProject.Application.Email;
using SovosProject.Application.Models;

namespace SovosProject.Application.Interfaces
{
    public interface IInvoiceEmailService
    {
        Task InvoiceSendEmailAsync(InvoiceMailLogDto invoiceMailLogDto);
    }
}
