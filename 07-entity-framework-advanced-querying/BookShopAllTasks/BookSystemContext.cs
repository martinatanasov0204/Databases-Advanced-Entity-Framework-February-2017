namespace BookShopAllTasks
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookSystemContext : DbContext
    {
        public BookSystemContext()
            : base("name=BookSystemContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Category)
                .WithMany(e => e.Book)
                .Map(m => m.ToTable("CategoryBook"));

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Book1)
                .WithMany(e => e.Book2)
                .Map(m => m.ToTable("RelatedBooks").MapLeftKey("BookId").MapRightKey("RelatedId"));
        }
    }
}
