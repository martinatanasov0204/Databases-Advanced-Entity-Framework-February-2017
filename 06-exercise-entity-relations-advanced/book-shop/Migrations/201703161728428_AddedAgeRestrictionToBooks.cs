namespace _01_book_shop_system_DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAgeRestrictionToBooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "AgeRestriction", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "AgeRestriction");
        }
    }
}
