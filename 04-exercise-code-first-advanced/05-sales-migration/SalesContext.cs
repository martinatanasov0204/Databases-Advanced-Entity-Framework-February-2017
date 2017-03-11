namespace _05_sales_migration
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=SalesContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<StoreLocations> StoreLocations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Sales)
                .WithOptional(e => e.Customers)
                .HasForeignKey(e => e.Customer_Id);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.Sales)
                .WithOptional(e => e.Products)
                .HasForeignKey(e => e.Product_Id);

            modelBuilder.Entity<StoreLocations>()
                .HasMany(e => e.Sales)
                .WithOptional(e => e.StoreLocations)
                .HasForeignKey(e => e.StoreLocation_Id);
        }
    }
}
