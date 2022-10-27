using PharmacySystem.DAL.Model;
using PharmacySystem.DAL.Sequence;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public int GetNextSequenceValue()
        {
            var rawQuery = Database.SqlQuery<int>("SELECT NEXT VALUE FOR [dbo].[Unit_Sequence];");
            var task = rawQuery.SingleAsync();
            int nextVal = task.Result;
            return nextVal;
        }
    }
}
