namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateloginusergoogle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserGoogle", "GroupId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserGoogle", "GroupId");
        }
    }
}
