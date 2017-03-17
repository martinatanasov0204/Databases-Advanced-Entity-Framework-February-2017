using _09_shared_albums.Migrations;

namespace _09_shared_albums
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
        public virtual DbSet<Tags> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Albums>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Albums)
                .Map(m => m.ToTable("TagAlbums").MapRightKey("Tag_Id"));

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
