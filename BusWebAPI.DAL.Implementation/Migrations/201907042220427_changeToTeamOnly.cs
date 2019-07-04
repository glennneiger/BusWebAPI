namespace BusWebAPI.DAL.Implementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeToTeamOnly : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PeopleOnBus", "Department");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PeopleOnBus", "Department", c => c.String());
        }
    }
}
