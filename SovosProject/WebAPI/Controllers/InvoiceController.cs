using Microsoft.AspNetCore.Mvc;
using SovosProject.Application.Services;
using SovosProject.Core.Aggregates.Entities;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        public InvoiceController(InvoiceService invoiceService)
        {
            _invoiceService=invoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice(InvoiceHeader invoice)
        {
            await _invoiceService.AddInvoiceAsync(invoice);
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
