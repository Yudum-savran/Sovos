using SovosProject.Application.Interfaces;
using SovosProject.Application.Models;
using SovosProject.Core.Repository;


namespace SovosProject.Application.Services
{
    public class InvoiceEmailService : IInvoiceEmailService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IEmailService _emailService;

        public InvoiceEmailService(IInvoiceRepository invoiceRepository, IEmailService emailService)
        {
            _invoiceRepository=invoiceRepository;
            _emailService=emailService;
        }

        public async Task InvoiceSendEmailAsync(InvoiceMailLogDto invoiceMailLogDto)
        {

            var unprocessedInvoices = await _invoiceRepository.GetUnprocessedInvoicesAsync();

            foreach (var invoice in unprocessedInvoices)
            {
                var bodyText = $"""
                  <html>
                  <body>
                      <p>{invoice.InvoiceLines.Count} kalem ürün içeren {invoice.InvoiceId} nolu faturanız başarıyla işlenmiştir.</p>
                  </body>
                  </html>
                  """;

                var mailLogDto = new MailLogDto
                {
                    FromEmail = invoiceMailLogDto.FromEmail,
                    ToEmail = invoiceMailLogDto.ToEmail,
                    Subject = invoiceMailLogDto.Subject,
                    Body = bodyText
                };

                await _emailService.SendEmailAsync(mailLogDto);
                invoice.Processed = "Processed";
                await _invoiceRepository.UpdateAsync(invoice);

            }
        }
    }
}
