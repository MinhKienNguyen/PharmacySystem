using PharmacySystem.DAL.Model;
using System.Data.Entity;

namespace PharmacySystem.DAL.Entity
{
    public class DBPharmacyContext : DbContext
    {
        public DBPharmacyContext() : base("ContactsConnectionString")
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
