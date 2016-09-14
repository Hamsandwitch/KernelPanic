namespace ShoppingList_Team2_Master.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userIdInttoString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ListModels", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ListModels", "UserId", c => c.Int(nullable: false));
        }
    }
}
