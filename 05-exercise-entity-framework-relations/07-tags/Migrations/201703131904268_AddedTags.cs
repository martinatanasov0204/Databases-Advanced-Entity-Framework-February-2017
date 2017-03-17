namespace _07_tags.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Tags",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Signature = c.String(),
                    })
                .PrimaryKey(t => t.Id);            
            CreateTable(
                "dbo.TagAlbums",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Albums_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Albums_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Albums_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Albums_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagAlbums", "Albums_Id", "dbo.Albums");
            DropForeignKey("dbo.TagAlbums", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagAlbums", new[] { "Albums_Id" });
            DropIndex("dbo.TagAlbums", new[] { "Tag_Id" });
            DropIndex("dbo.Tags", new[] { "Signature" });
            DropTable("dbo.TagAlbums");
            DropTable("dbo.Tags");
        }
    }
}
