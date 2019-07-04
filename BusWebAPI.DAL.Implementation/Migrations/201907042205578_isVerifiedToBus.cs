namespace BusWebAPI.DAL.Implementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isVerifiedToBus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PeopleOnBus", "IsVerified", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PeopleOnBus", "IsVerified");
        }
    }
}
