namespace _03_sales_database
{
    using _03_sales_database.Models;
    using System.Data.Entity;

    public class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=SalesContext")
        {
            Database.SetInitializer(new SeedDatabase());
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }


    }
}