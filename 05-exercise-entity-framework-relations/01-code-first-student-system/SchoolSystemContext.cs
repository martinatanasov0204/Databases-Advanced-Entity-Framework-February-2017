using _01_code_first_student_system.Migrations;

namespace _01_code_first_student_system
{
    using _01_code_first_student_system.Models;
    using System.Data.Entity;
    public class SchoolSystemContext : DbContext
    {
        public SchoolSystemContext()
            : base("name=SchoolSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolSystemContext, Configuration>());
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Resources> Resources { get; set; }
        public virtual DbSet<Student> Students { get; set; }

    }
}