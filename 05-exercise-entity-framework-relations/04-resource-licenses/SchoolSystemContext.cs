using _04_resource_licenses.Migrations;

namespace _04_resource_licenses
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SchoolSystemContext : DbContext
    {
        public SchoolSystemContext()
            : base("name=SchoolSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolSystemContext, Configuration>());
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Homework> Homework { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<License> Licenses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>()
                .HasMany(e => e.Resources)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("ResourcesCourses").MapLeftKey("Course_Id"));

            modelBuilder.Entity<Courses>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("StudentCourses").MapLeftKey("Course_Id").MapRightKey("Student_Id"));

            modelBuilder.Entity<Students>()
                .HasMany(e => e.Homework)
                .WithOptional(e => e.Students)
                .HasForeignKey(e => e.Student_Id);
        }
    }
}
