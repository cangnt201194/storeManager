namespace StoreManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Errors", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Errors", "CreatedDateP");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Errors", "CreatedDateP", c => c.DateTime(nullable: false));
            DropColumn("dbo.Errors", "CreatedDate");
        }
    }
}
