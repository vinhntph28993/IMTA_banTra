namespace WebsiteBanTraiCay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateaccountgg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGoogle",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Gender = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                        Image = c.String(),
                        Access = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Created_at = c.DateTime(nullable: false),
                        Created_by = c.Int(nullable: false),
                        Updated_at = c.DateTime(nullable: false),
                        Updated_by = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailID = c.String(),
                        IsEmailVerified = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                        ResetPasswordCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserGoogle");
        }
    }
}
