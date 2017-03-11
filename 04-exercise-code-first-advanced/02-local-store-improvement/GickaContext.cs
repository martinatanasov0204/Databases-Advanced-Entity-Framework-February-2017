namespace _02_local_store_improvement
{
    using System.Data.Entity;

    public partial class GickaContext : DbContext
    {
        public GickaContext()
            : base("name=GickaContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
