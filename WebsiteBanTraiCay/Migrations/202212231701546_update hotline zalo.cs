namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatehotlinezalo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configs", "Zalo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Configs", "Zalo");
        }
    }
}
