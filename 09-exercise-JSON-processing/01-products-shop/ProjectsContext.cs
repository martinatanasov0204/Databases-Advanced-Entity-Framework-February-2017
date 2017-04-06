namespace _01_products_shop
{
    using System.Data.Entity;
    using _01_products_shop.Models;
    public class ProjectsContext : DbContext
    {
        public ProjectsContext()
            : base("name=ProjectsContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<ProjectsContext>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.ProductsSold).WithRequired(p => p.Seller);

            modelBuilder.Entity<User>().HasMany(u => u.ProductsBought).WithOptional(p => p.Buyer);

            modelBuilder.Entity<User>().HasMany(u => u.Friends).WithMany().Map(mc =>
            {
                mc.MapLeftKey("UserId");
                mc.MapRightKey("FriendId");
                mc.ToTable("UserFriends");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}