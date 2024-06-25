namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpaytotalusergg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserGoogle", "PayTotal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserGoogle", "PayTotal");
        }
    }
}
