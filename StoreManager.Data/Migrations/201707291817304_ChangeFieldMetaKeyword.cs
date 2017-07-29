namespace StoreManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFieldMetaKeyword : DbMigration
    {
        public override void Up()
        {
            //RenameColumn("PostCategories", "MetaKeyWord", "MetaKeyword", null);
            //RenameColumn("Posts", "MetaKeyWord", "MetaKeyword", null);
        }
        
        public override void Down()
        {
            //RenameColumn("PostCategories", "MetaKeyWord", "MetaKeyword", null);
            //RenameColumn("Posts", "MetaKeyWord", "MetaKeyword",null);
        }
    }
}
