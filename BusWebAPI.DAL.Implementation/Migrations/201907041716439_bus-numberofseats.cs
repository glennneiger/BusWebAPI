namespace BusWebAPI.DAL.Implementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class busnumberofseats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buses", "NumberOfSeats", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buses", "NumberOfSeats");
        }
    }
}
