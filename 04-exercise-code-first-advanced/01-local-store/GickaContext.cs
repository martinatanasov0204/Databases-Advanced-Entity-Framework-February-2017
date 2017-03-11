namespace _01_local_store
{
    using _01_local_store.Migrations;
    using System.Data.Entity;
    public class GickaContext : DbContext
    {
        public GickaContext()
            : base("name=GickaContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GickaContext, Configuration>());
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}