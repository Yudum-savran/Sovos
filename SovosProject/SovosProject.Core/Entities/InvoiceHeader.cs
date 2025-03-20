namespace SovosProject.Core.Entities
{
    public class InvoiceHeader
    {
        public int Id { get; set; }
        public string InvoiceId { get; set; }
        public string SenderTitle { get; set; }
        public string ReceiverTitle { get;  set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public List<InvoiceLine> InvoiceLines { get; set; } = new();
        public string Processed { get; set; }

        public InvoiceHeader(string invoiceId, string senderTitle, string receiverTitle, DateTime date, string email, string processed)
        {
            InvoiceId = invoiceId;
            SenderTitle = senderTitle;
            ReceiverTitle = receiverTitle;
            Date = date;
            Email = email;
            Processed = processed;
        }
    }
}
