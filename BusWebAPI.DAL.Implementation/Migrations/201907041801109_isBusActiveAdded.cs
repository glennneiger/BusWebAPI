namespace BusWebAPI.DAL.Implementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isBusActiveAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buses", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buses", "IsActive");
        }
    }
}
