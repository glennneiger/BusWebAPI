namespace BusWebAPI.DAL.Implementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isHiddenPeopleOnBusAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PeopleOnBus", "IsHidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PeopleOnBus", "IsHidden");
        }
    }
}
