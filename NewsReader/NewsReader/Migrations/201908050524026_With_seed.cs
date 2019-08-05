namespace NewsReader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class With_seed : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            RenameTable(name: "dbo.Countries", newName: "Country");
            DropForeignKey("dbo.News", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.News", "Country_Id", "dbo.Countries");
            DropIndex("dbo.News", new[] { "Category_Id" });
            DropIndex("dbo.News", new[] { "Country_Id" });
            RenameColumn(table: "dbo.News", name: "Category_Id", newName: "IdCategory");
            RenameColumn(table: "dbo.News", name: "Country_Id", newName: "IdCountry");
            AlterColumn("dbo.News", "Title", c => c.String(maxLength: 150));
            AlterColumn("dbo.News", "Content", c => c.String(maxLength: 1000));
            AlterColumn("dbo.News", "IdCategory", c => c.Int(nullable: false));
            AlterColumn("dbo.News", "IdCountry", c => c.Int(nullable: false));
            CreateIndex("dbo.News", "IdCategory");
            CreateIndex("dbo.News", "IdCountry");
            AddForeignKey("dbo.News", "IdCategory", "dbo.Category", "Id", cascadeDelete: true);
            AddForeignKey("dbo.News", "IdCountry", "dbo.Country", "Id", cascadeDelete: true);
            DropColumn("dbo.Category", "DateCreated");
            DropColumn("dbo.Country", "DateCreated");
            DropColumn("dbo.News", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Country", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Category", "DateCreated", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.News", "IdCountry", "dbo.Country");
            DropForeignKey("dbo.News", "IdCategory", "dbo.Category");
            DropIndex("dbo.News", new[] { "IdCountry" });
            DropIndex("dbo.News", new[] { "IdCategory" });
            AlterColumn("dbo.News", "IdCountry", c => c.Int());
            AlterColumn("dbo.News", "IdCategory", c => c.Int());
            AlterColumn("dbo.News", "Content", c => c.String());
            AlterColumn("dbo.News", "Title", c => c.String());
            RenameColumn(table: "dbo.News", name: "IdCountry", newName: "Country_Id");
            RenameColumn(table: "dbo.News", name: "IdCategory", newName: "Category_Id");
            CreateIndex("dbo.News", "Country_Id");
            CreateIndex("dbo.News", "Category_Id");
            AddForeignKey("dbo.News", "Country_Id", "dbo.Countries", "Id");
            AddForeignKey("dbo.News", "Category_Id", "dbo.Categories", "Id");
            RenameTable(name: "dbo.Country", newName: "Countries");
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
