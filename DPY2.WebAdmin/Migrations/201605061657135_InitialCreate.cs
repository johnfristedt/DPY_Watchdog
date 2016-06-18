namespace DPY2.WebAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pages", t => t.PageId, cascadeDelete: true)
                .Index(t => t.PageId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Text = c.String(),
                        ImageFileName = c.String(),
                        BlockId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blocks", t => t.BlockId, cascadeDelete: true)
                .Index(t => t.BlockId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Text = c.String(),
                        BlockId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blocks", t => t.BlockId, cascadeDelete: true)
                .Index(t => t.BlockId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "BlockId", "dbo.Blocks");
            DropForeignKey("dbo.Projects", "BlockId", "dbo.Blocks");
            DropForeignKey("dbo.Blocks", "PageId", "dbo.Pages");
            DropIndex("dbo.Skills", new[] { "BlockId" });
            DropIndex("dbo.Projects", new[] { "BlockId" });
            DropIndex("dbo.Blocks", new[] { "PageId" });
            DropTable("dbo.Skills");
            DropTable("dbo.Projects");
            DropTable("dbo.Pages");
            DropTable("dbo.Blocks");
        }
    }
}
