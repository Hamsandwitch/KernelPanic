namespace ShoppingList_Team2_Master.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListModelsController : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(),
                        Color = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ShoppingListItemModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ListId = c.Int(nullable: false),
                        Name = c.String(),
                        IsChecked = c.Boolean(nullable: false),
                        Purchased = c.Boolean(nullable: false),
                        Contents = c.String(),
                        Priority = c.Int(),
                        Note = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ListModels", t => t.ListId, cascadeDelete: true)
                .Index(t => t.ListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingListItemModels", "ListId", "dbo.ListModels");
            DropIndex("dbo.ShoppingListItemModels", new[] { "ListId" });
            DropTable("dbo.ShoppingListItemModels");
            DropTable("dbo.ListModels");
        }
    }
}
