namespace ShoppingList_Team2_Master.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somethingColin : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ShoppingListItemModels", "Contents");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingListItemModels", "Contents", c => c.String());
        }
    }
}
