using System.Text.Json.Serialization;

namespace SovosProject.Core.Entities
{
    public class InvoiceLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get;  set; }
        public string UnitCode { get;  set; }
        public decimal UnitPrice { get;  set; }
        public int InvoiceHeaderId { get; set; }
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
