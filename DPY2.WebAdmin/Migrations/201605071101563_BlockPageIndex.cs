namespace DPY2.WebAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlockPageIndex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blocks", "PageIndex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blocks", "PageIndex");
        }
    }
}
