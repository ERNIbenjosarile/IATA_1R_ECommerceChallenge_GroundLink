using Microsoft.EntityFrameworkCore;

namespace X_Hackathon.Domain
{
    public class DatabaseContext : DbContext
    {
#pragma warning disable IDE0290 // Use primary constructor
        public DatabaseContext(DbContextOptions options) : base(options)
#pragma warning restore IDE0290 // Use primary constructor
        {
            AirwayBills = Set<AirwayBill>();
            PackingLists = Set<PackingList>();
            CommercialInvoices = Set<CommercialInvoice>();
            Products = Set<Product>();
        }

        public DbSet<AirwayBill> AirwayBills { get; set; }
        public DbSet<CommercialInvoice> CommercialInvoices { get; set; }
        public DbSet<PackingList> PackingLists { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
