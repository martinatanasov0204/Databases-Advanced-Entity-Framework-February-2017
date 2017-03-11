namespace _09_hospital_database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diagnoses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Medicaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        DateOFBirth = c.DateTime(nullable: false),
                        Picture = c.Binary(),
                        MedicalInsurence = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visitations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitationDateTime = c.DateTime(nullable: false),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitations", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Medicaments", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Diagnoses", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Visitations", new[] { "Patient_Id" });
            DropIndex("dbo.Medicaments", new[] { "Patient_Id" });
            DropIndex("dbo.Diagnoses", new[] { "Patient_Id" });
            DropTable("dbo.Visitations");
            DropTable("dbo.Patients");
            DropTable("dbo.Medicaments");
            DropTable("dbo.Diagnoses");
        }
    }
}
