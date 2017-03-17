namespace _09_shared_albums.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyAlbumsPhotographers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photographers", "Albums_Id", c => c.Int());
            CreateIndex("dbo.Photographers", "Albums_Id");
            AddForeignKey("dbo.Photographers", "Albums_Id", "dbo.Albums", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photographers", "Albums_Id", "dbo.Albums");
            DropIndex("dbo.Photographers", new[] { "Albums_Id" });
            DropColumn("dbo.Photographers", "Albums_Id");
        }
    }
}
