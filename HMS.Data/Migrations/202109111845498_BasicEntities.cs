namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccomodationPackages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NoOfRoom = c.Int(nullable: false),
                        FeePerNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccomodationTypeId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccomodationTypes", t => t.AccomodationTypeId_Id)
                .Index(t => t.AccomodationTypeId_Id);
            
            CreateTable(
                "dbo.AccomodationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Accomodations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccomodationPachageID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        AccomodationPackage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccomodationPackages", t => t.AccomodationPackage_Id)
                .Index(t => t.AccomodationPackage_Id);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccomodationID = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accomodations", t => t.AccomodationID, cascadeDelete: true)
                .Index(t => t.AccomodationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "AccomodationID", "dbo.Accomodations");
            DropForeignKey("dbo.Accomodations", "AccomodationPackage_Id", "dbo.AccomodationPackages");
            DropForeignKey("dbo.AccomodationPackages", "AccomodationTypeId_Id", "dbo.AccomodationTypes");
            DropIndex("dbo.Bookings", new[] { "AccomodationID" });
            DropIndex("dbo.Accomodations", new[] { "AccomodationPackage_Id" });
            DropIndex("dbo.AccomodationPackages", new[] { "AccomodationTypeId_Id" });
            DropTable("dbo.Bookings");
            DropTable("dbo.Accomodations");
            DropTable("dbo.AccomodationTypes");
            DropTable("dbo.AccomodationPackages");
        }
    }
}
