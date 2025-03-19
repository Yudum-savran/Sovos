using SovosProject.Core.Aggregates.Entities;

namespace SovosProject.Application.Models
{
    public class InvoiceLineDto
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public int Quantity { get;  set; }
        public string UnitCode { get;  set; }
        public decimal UnitPrice { get;  set; }
    }
}
