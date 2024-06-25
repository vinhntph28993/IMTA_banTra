namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateurlforlogoweb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configs", "Url_1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Configs", "Url_1");
        }
    }
}
