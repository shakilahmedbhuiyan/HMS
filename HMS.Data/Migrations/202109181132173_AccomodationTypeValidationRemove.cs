namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccomodationTypeValidationRemove : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AccomodationTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AccomodationTypes", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
