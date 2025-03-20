using Microsoft.EntityFrameworkCore;
using SovosProject.Core.Entities;

namespace SovosProject.Infrastructure.Data
{
    public class SovosProjectDbContext : DbContext
    {
        public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<MailLog> MailLogs { get; set; }

        public SovosProjectDbContext(DbContextOptions<SovosProjectDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceHeader>()
              .HasMany(i => i.InvoiceLines)
              .WithOne(il => il.InvoiceHeader)
              .HasForeignKey(il => il.InvoiceHeaderId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InvoiceHeader>()
              .Property(i => i.Processed)
              .HasDefaultValue("Unprocessed");
       }
    }
}
