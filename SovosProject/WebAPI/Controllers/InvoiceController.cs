using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using SovosProject.Application.Interfaces;
using SovosProject.Application.Models;
using SovosProject.Application.Services;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceEmailService _invoiceEmailService;
        private readonly IValidator<InvoiceHeaderDto> _invoiceValidator;

        public InvoiceController(IInvoiceService invoiceService, IValidator<InvoiceHeaderDto> invoiceValidator, IInvoiceEmailService invoiceEmailService)
        {
            _invoiceService=invoiceService;
            _invoiceValidator=invoiceValidator;
            _invoiceEmailService=invoiceEmailService;
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice(InvoiceHeaderDto value)
        {
            ValidationResult validationResult = await _invoiceValidator.ValidateAsync(value);
            if(!validationResult.IsValid) 
                throw new ValidationException(validationResult.Errors);
            await _invoiceService.AddInvoiceAsync(value);
            return CreatedAtAction(nameof(GetInvoiceById), new { id = value.Id }, value);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return Ok(invoices);
        }

        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> GetInvoiceById(string invoiceId)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(invoiceId);
            if (invoice == null)
                return NotFound("Invoice not found");
            return Ok(invoice);
        }

        [HttpPost("sendEmail")]
        public async Task<IActionResult> SendInvoiceEmail(InvoiceMailLogDto invoiceMailLogDto)
        {         

            await _invoiceEmailService.InvoiceSendEmailAsync(invoiceMailLogDto);

            return Ok(new { Message = "Fatura e-postası başarıyla gönderildi." });
        }
    }
}
