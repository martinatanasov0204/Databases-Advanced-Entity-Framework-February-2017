namespace _01_book_shop_system_DB
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using _01_book_shop_system_DB.Migrations;
    using Models;

    public class BookSystemContext : DbContext
    {
        public BookSystemContext()
            : base("name=BookSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookSystemContext, Configuration>());
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(r => r.RelatedBooks)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("BookId");
                    m.MapRightKey("RelatedId");
                    m.ToTable("RelatedBooks");
                });
            //Author
            modelBuilder.Entity<Author>().HasKey(a => a.Id);
            modelBuilder.Entity<Author>().Property(c => c.LastName).IsRequired();

            //Book
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Book>().Property(c => c.Title).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Title).HasMaxLength(50);

            modelBuilder.Entity<Book>().Property(b => b.Description).HasMaxLength(1000);

            //Category
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}