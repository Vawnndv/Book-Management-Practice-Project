namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategoryIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "CategoryId" });
            AlterColumn("dbo.Books", "CategoryId", c => c.Int());
            CreateIndex("dbo.Books", "CategoryId");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "CategoryId" });
            AlterColumn("dbo.Books", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "CategoryId");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
