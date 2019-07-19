namespace NewsReader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Region = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Image = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Country_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.News", "Category_Id", "dbo.Categories");
            DropIndex("dbo.News", new[] { "Country_Id" });
            DropIndex("dbo.News", new[] { "Category_Id" });
            DropTable("dbo.News");
            DropTable("dbo.Countries");
            DropTable("dbo.Categories");
        }
    }
}
