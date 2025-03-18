namespace SovosProject.Core.Aggregates.Entities
{
    public class InvoiceHeader
    {
        public int Id { get; set; }
        public string InvoiceId { get; private set; }
        public string SenderTitle { get; private set; }
        public string ReceiverTitle { get; private set; }
        public DateTime Date { get;private set; }
        public string Email { get;private set; }
        public List<InvoiceLine> InvoiceLines { get; private set; } = new();

        public InvoiceHeader(string invoiceId, string senderTitle, string receiverTitle, DateTime date, string email)
        {
            InvoiceId = invoiceId;
            SenderTitle = senderTitle;
            ReceiverTitle = receiverTitle;
            Date = date;
            Email = email;
        }
    }
}
