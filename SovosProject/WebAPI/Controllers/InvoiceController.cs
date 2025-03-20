using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SovosProject.Application.Interfaces;
using SovosProject.Application.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceEmailService _invoiceEmailService;
        private readonly IValidator<InvoiceHeaderDto> _invoiceValidator;
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(IInvoiceService invoiceService, IValidator<InvoiceHeaderDto> invoiceValidator, IInvoiceEmailService invoiceEmailService, ILogger<InvoiceController> logger)
        {
            _invoiceService=invoiceService;
            _invoiceValidator=invoiceValidator;
            _invoiceEmailService=invoiceEmailService;
            _logger=logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice(InvoiceHeaderDto value)
        {
              _logger.LogInformation("AddInvoice metoduna başlandı. Invoice ID: {InvoiceId}", value.InvoiceId);

            ValidationResult validationResult = await _invoiceValidator.ValidateAsync(value);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Validasyon başarısız oldu.");
                throw new ValidationException(validationResult.Errors);
            }

            _logger.LogInformation("Validasyon başarılı. Invoice ID: {InvoiceId}. Faturayı eklemeye devam ediliyor.", value.InvoiceId);
            await _invoiceService.AddInvoiceAsync(value);
            _logger.LogInformation("Invoice ID: {InvoiceId} başarıyla eklendi.", value.InvoiceId);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            _logger.LogInformation("GetAllInvoices metoduna başlandı.");
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            if(invoices.IsSuccess || !invoices.Value.Any())
            {
                _logger.LogWarning("Fatura listesi boş veya null döndü.");
            }

            _logger.LogInformation("Faturalar başarıyla getirildi.");
            return Ok(invoices);
        }

        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> GetInvoiceById(string invoiceId)
        {
            _logger.LogInformation("GetInvoiceById metoduna başlandı. InvoiceId: {InvoiceId}", invoiceId);

            var invoice = await _invoiceService.GetInvoiceByIdAsync(invoiceId);
            if (invoice == null)
            {
                _logger.LogWarning("Bu idye ait fatura bulunamadı");
            }
            _logger.LogInformation("Invoice başarıyla getirildi. InvoiceId: {InvoiceId}", invoiceId);
            return Ok(invoice);
        }

        [HttpPost("sendEmail")]
        public async Task<IActionResult> SendInvoiceEmail(InvoiceMailLogDto invoiceMailLogDto)
        {
            _logger.LogInformation("SendInvoiceEmail metoduna başlandı.");
            await _invoiceEmailService.InvoiceSendEmailAsync(invoiceMailLogDto);
            _logger.LogInformation("Fatura e-postası başarıyla gönderildi.");

            return Ok(new { Message = "Fatura e-postası başarıyla gönderildi." });
        }
    }
}
