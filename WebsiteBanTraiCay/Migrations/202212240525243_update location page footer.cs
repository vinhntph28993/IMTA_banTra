namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelocationpagefooter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "Location");
        }
    }
}
