namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelogoweb1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configs", "LogoWeb", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Configs", "LogoWeb");
        }
    }
}
