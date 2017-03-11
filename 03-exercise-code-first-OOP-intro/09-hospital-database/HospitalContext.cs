namespace _09_hospital_database
{
    using _09_hospital_database.Migrations;
    using System.Data.Entity;
    public class HospitalContext : DbContext
    {
        public HospitalContext()
            : base("name=HospitalContext.cs")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HospitalContext, Configuration>());
        }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Visitation> Visitations { get; set; }
        public virtual DbSet<Medicament> Medicines { get; set; }
        public virtual DbSet<Diagnose> Diagnoses { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }
    }
}