namespace BusWebAPI.DAL.Implementation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class peopleonbusinitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PeopleOnBus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Department = c.String(),
                        Team = c.String(),
                        FullName = c.String(),
                        PersonalNumber = c.Int(nullable: false),
                        ExitReason = c.String(),
                        MefakedName = c.String(),
                        Comments = c.String(),
                        BusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Buses", t => t.BusID, cascadeDelete: true)
                .Index(t => t.BusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeopleOnBus", "BusID", "dbo.Buses");
            DropIndex("dbo.PeopleOnBus", new[] { "BusID" });
            DropTable("dbo.PeopleOnBus");
        }
    }
}
