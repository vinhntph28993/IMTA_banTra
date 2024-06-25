namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelogoweb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configs", "LogoIconWeb", c => c.String());
            AddColumn("dbo.Configs", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Configs", "Url");
            DropColumn("dbo.Configs", "LogoIconWeb");
        }
    }
}
