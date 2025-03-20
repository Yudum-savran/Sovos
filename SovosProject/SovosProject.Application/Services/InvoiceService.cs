using AutoMapper;
using SovosProject.Application.Common;
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
        public async Task<GenericResult<bool>> AddInvoiceAsync(InvoiceHeaderDto value)
        {
            try
            {
                if (value == null)
                    return GenericResult<bool>.Failure(Error.BadRequest("Fatura verileri gereklidir."));

                var invoiceHeader = _mapper.Map<InvoiceHeader>(value);
                await _invoiceRepository.AddInvoiceAsync(invoiceHeader);

                return GenericResult<bool>.Success(true);
            }
            catch (Exception ex)
            {

                return GenericResult<bool>.Failure(Error.InternalServerError($"Fatura eklenirken bir hata oluştu: {ex.Message}"));
            }
        }

        public async Task<GenericResult<List<InvoiceHeaderDto>>> GetAllInvoicesAsync()
        {
            try
            {
                var invoices = await _invoiceRepository.GetAllAsync();
                if (invoices == null || !invoices.Any())
                    return GenericResult<List<InvoiceHeaderDto>>.Failure(Error.NotFound("Fatura bulunamadı."));

                var invoiceDtos = _mapper.Map<List<InvoiceHeaderDto>>(invoices);
                return GenericResult<List<InvoiceHeaderDto>>.Success(invoiceDtos);
            }
            catch (Exception ex)
            {

                return GenericResult<List<InvoiceHeaderDto>>.Failure(Error.InternalServerError($"Faturalar alınırken bir hata oluştu: {ex.Message}"));
            }
        }

        public async Task<GenericResult<InvoiceHeaderDto>> GetInvoiceByIdAsync(string invoiceId)
        {
            try
            {
                if (string.IsNullOrEmpty(invoiceId))
                    return GenericResult<InvoiceHeaderDto>.Failure(Error.BadRequest("Fatura idsi zorunlu."));

                var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
                if (invoice == null)
                    return GenericResult<InvoiceHeaderDto>.Failure(Error.NotFound("Fatura bulunamadı"));

                var invoiceDto = _mapper.Map<InvoiceHeaderDto>(invoice);
                return GenericResult<InvoiceHeaderDto>.Success(invoiceDto);
            }
            catch (Exception ex)
            {

                return GenericResult<InvoiceHeaderDto>.Failure(Error.InternalServerError($"Fatura alınırken bir hata oluştu: {ex.Message}"));
            }
        }
    }
}
