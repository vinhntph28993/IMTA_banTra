namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableevent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        URL = c.String(),
                        Detail = c.String(),
                        Status = c.Int(),
                        Type = c.String(),
                        Created_At = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Event");
        }
    }
}
