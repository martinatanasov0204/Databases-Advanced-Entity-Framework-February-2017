namespace _09_hospital_database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDoctors : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medicaments", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Medicaments", new[] { "Patient_Id" });
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Specialty = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientMedicaments",
                c => new
                    {
                        Patient_Id = c.Int(nullable: false),
                        Medicament_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_Id, t.Medicament_Id })
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Medicaments", t => t.Medicament_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id)
                .Index(t => t.Medicament_Id);
            
            AddColumn("dbo.Visitations", "DoctorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Visitations", "DoctorId");
            AddForeignKey("dbo.Visitations", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
            DropColumn("dbo.Medicaments", "Patient_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicaments", "Patient_Id", c => c.Int());
            DropForeignKey("dbo.PatientMedicaments", "Medicament_Id", "dbo.Medicaments");
            DropForeignKey("dbo.PatientMedicaments", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Visitations", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.PatientMedicaments", new[] { "Medicament_Id" });
            DropIndex("dbo.PatientMedicaments", new[] { "Patient_Id" });
            DropIndex("dbo.Visitations", new[] { "DoctorId" });
            DropColumn("dbo.Visitations", "DoctorId");
            DropTable("dbo.PatientMedicaments");
            DropTable("dbo.Doctors");
            CreateIndex("dbo.Medicaments", "Patient_Id");
            AddForeignKey("dbo.Medicaments", "Patient_Id", "dbo.Patients", "Id");
        }
    }
}
