namespace StoreManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTableApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.ApplicationUsers", "Id");
            DropColumn("dbo.ApplicationUsers", "PositionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUsers", "PositionID", c => c.Int());
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.ApplicationUsers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropColumn("dbo.Orders", "CustomerId");
        }
    }
}
