using _07_tags.Migrations;

namespace _07_tags
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PhotographyContext : DbContext
    {
        public PhotographyContext()
            : base("name=PhotographyContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotographyContext, Configuration>());
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<Photographers> Photographers { get; set; }
        public virtual DbSet<Pictures> Pictures { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photographers>()
                .HasMany(e => e.Albums)
                .WithOptional(e => e.Photographers)
                .HasForeignKey(e => e.Photographer_Id);

            modelBuilder.Entity<Pictures>()
                .HasMany(e => e.Albums)
                .WithOptional(e => e.Pictures)
                .HasForeignKey(e => e.Picture_Id);
        }
    }
}
