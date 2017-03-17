namespace _06_albums.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAlbumsAndPictures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BackgroundColor = c.String(),
                        Private = c.Boolean(nullable: false),
                        Photographer_Id = c.Int(),
                        Picture_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photographers", t => t.Photographer_Id)
                .ForeignKey("dbo.Pictures", t => t.Picture_Id)
                .Index(t => t.Photographer_Id)
                .Index(t => t.Picture_Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Caption = c.String(),
                        PathOnFileSystem = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Picture_Id", "dbo.Pictures");
            DropForeignKey("dbo.Albums", "Photographer_Id", "dbo.Photographers");
            DropIndex("dbo.Albums", new[] { "Picture_Id" });
            DropIndex("dbo.Albums", new[] { "Photographer_Id" });
            DropTable("dbo.Pictures");
            DropTable("dbo.Albums");
        }
    }
}
