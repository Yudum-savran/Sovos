using Microsoft.EntityFrameworkCore;
using SovosProject.Core.Aggregates.Entities;

namespace SovosProject.Infrastructure.Data
{
    public class SovosProjectDbContext: DbContext
    {
        public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }

        public SovosProjectDbContext(DbContextOptions<SovosProjectDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<InvoiceHeader>()
                .HasMany(i => i.InvoiceLines)
                .WithOne()
                .HasForeignKey(il => il.InvoiceHeaderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
