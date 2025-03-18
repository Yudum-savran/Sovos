namespace SovosProject.Core.Aggregates.Entities
{
    public class InvoiceLine
    {
        public int Id { get;private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public string UnitCode { get; private set; }
        public decimal UnitPrice { get; private set; }
        public string InvoiceHeaderId { get; set; }
        public InvoiceHeader InvoiceHeader { get; set; }
        public InvoiceLine(int id, string name, int quantity, string unitCode, decimal unitPrice)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            UnitCode = unitCode;
            UnitPrice = unitPrice;
        }
    }
}
