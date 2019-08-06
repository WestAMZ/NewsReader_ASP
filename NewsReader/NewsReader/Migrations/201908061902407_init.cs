namespace NewsReader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 150),
                        Content = c.String(maxLength: 1000),
                        Image = c.String(),
                        Published = c.DateTime(nullable: false),
                        IdCategory = c.Int(nullable: false),
                        IdCountry = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.IdCategory, cascadeDelete: true)
                .ForeignKey("dbo.Country", t => t.IdCountry, cascadeDelete: true)
                .Index(t => t.IdCategory)
                .Index(t => t.IdCountry);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Region = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "IdCountry", "dbo.Country");
            DropForeignKey("dbo.News", "IdCategory", "dbo.Category");
            DropIndex("dbo.News", new[] { "IdCountry" });
            DropIndex("dbo.News", new[] { "IdCategory" });
            DropTable("dbo.Country");
            DropTable("dbo.News");
            DropTable("dbo.Category");
        }
    }
}
