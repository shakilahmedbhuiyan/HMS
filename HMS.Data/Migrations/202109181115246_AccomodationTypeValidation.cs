namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccomodationTypeValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccomodationTypes", "Name", c => c.String(nullable: true, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AccomodationTypes", "Name", c => c.String());
        }
    }
}
