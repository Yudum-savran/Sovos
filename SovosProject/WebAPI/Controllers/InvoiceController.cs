using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SovosProject.Application.Interfaces;
using SovosProject.Application.Models;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IValidator<InvoiceHeaderDto> _invoiceValidator;

        public InvoiceController(IInvoiceService invoiceService, IValidator<InvoiceHeaderDto> invoiceValidator)
        {
            _invoiceService=invoiceService;
            _invoiceValidator=invoiceValidator;
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice(InvoiceHeaderDto value)
        {
            ValidationResult validationResult = await _invoiceValidator.ValidateAsync(value);
            if(!validationResult.IsValid) 
                throw new ValidationException(validationResult.Errors);
            await _invoiceService.AddInvoiceAsync(value);
            return Ok("Invoice added successfully");
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
    }
}
