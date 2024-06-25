namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmessfacebook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configs", "MessFacebook", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Configs", "MessFacebook");
        }
    }
}
