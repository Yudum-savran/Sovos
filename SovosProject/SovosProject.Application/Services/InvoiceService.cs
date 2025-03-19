using SovosProject.Application.Interfaces;
using SovosProject.Core.Aggregates.Entities;
using SovosProject.Infrastructure.Repository;

namespace SovosProject.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task AddInvoiceAsync(InvoiceHeader invoice)
        {
            try
            {
               if (invoice == null) throw new ArgumentNullException(nameof(invoice), "parameters invoice not found");
                await _invoiceRepository.AddAsync(invoice);
            }
            catch (Exception ex)
            {

               throw new Exception("An error occurred while adding the invoice.", ex);
            }
        }

        public async Task<List<InvoiceHeader>> GetAllInvoicesAsync()
        {
            try
            {
                return await _invoiceRepository.GetAllAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while adding the invoice.", ex);
            }
        }

        public async Task<InvoiceHeader?> GetInvoiceByIdAsync(string invoiceId)
        {
            try
            {
                if (invoiceId == null)
                    throw new KeyNotFoundException("Parameters id is null object");
                return await _invoiceRepository.GetByIdAsync(invoiceId);
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while adding the invoice.", ex);
            }
        }
    }
}
