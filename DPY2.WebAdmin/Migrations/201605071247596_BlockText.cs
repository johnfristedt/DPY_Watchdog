namespace DPY2.WebAdmin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlockText : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blocks", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blocks", "Text");
        }
    }
}
