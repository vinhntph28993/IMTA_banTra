namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteurl_1forconfig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Configs", "Url_1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Configs", "Url_1", c => c.String());
        }
    }
}
