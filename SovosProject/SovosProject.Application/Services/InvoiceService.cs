using AutoMapper;
using SovosProject.Application.Interfaces;
using SovosProject.Application.Models;
using SovosProject.Core.Entities;
using SovosProject.Core.Repository;

namespace SovosProject.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper=mapper;
        }
        public async Task AddInvoiceAsync(InvoiceHeaderDto value)
        {
            try
            {
                if (value == null) throw new ArgumentNullException(nameof(value), "parameters invoice not found");
                var invoiceHeader = _mapper.Map<InvoiceHeader>(value);
                await _invoiceRepository.AddAsync(invoiceHeader);
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while adding the invoice.", ex);
            }
        }

        public async Task<List<InvoiceHeaderDto>> GetAllInvoicesAsync()
        {
            try
            {
                var invoices = await _invoiceRepository.GetAllAsync();
                if (invoices == null || !invoices.Any())
                    return new List<InvoiceHeaderDto>();

                var invoiceDtos = _mapper.Map<List<InvoiceHeaderDto>>(invoices);
                return invoiceDtos;

            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while adding the invoice.", ex);
            }
        }

        public async Task<InvoiceHeaderDto?> GetInvoiceByIdAsync(string invoiceId)
        {
            try
            {
                if (string.IsNullOrEmpty(invoiceId))
                    throw new KeyNotFoundException("Parameters id is null object");

                var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
                if (invoice == null) return null;

                var invoiceDto = _mapper.Map<InvoiceHeaderDto>(invoice);
                return invoiceDto;
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while adding the invoice.", ex);
            }
        }
    }
}
