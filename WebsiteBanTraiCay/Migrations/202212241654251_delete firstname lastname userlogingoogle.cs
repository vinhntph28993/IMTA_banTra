namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletefirstnamelastnameuserlogingoogle : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserGoogle", "FirstName");
            DropColumn("dbo.UserGoogle", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserGoogle", "LastName", c => c.String());
            AddColumn("dbo.UserGoogle", "FirstName", c => c.String());
        }
    }
}
