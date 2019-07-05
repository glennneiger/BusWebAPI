namespace BusWebAPI.DAL.Implementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userRegistrationAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonalID = c.Int(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Password_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Passwords", t => t.Password_ID)
                .Index(t => t.Password_ID);
            
            CreateTable(
                "dbo.Passwords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HashedPassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Password_ID", "dbo.Passwords");
            DropIndex("dbo.Users", new[] { "Password_ID" });
            DropTable("dbo.Passwords");
            DropTable("dbo.Users");
        }
    }
}
