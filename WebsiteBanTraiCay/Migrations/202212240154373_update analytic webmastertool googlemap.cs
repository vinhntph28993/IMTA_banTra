namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateanalyticwebmastertoolgooglemap : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configs", "Analytic", c => c.String());
            AddColumn("dbo.Configs", "WebMasterTool", c => c.String());
            AddColumn("dbo.Configs", "Google_Maps", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Configs", "Google_Maps");
            DropColumn("dbo.Configs", "WebMasterTool");
            DropColumn("dbo.Configs", "Analytic");
        }
    }
}
