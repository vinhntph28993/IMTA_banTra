namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addapitalkto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configs", "APITalkTo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Configs", "APITalkTo");
        }
    }
}
