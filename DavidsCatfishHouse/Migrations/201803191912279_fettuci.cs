namespace DavidsCatfishHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fettuci : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Start", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "End", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "End", c => c.DateTime());
            AlterColumn("dbo.Events", "Start", c => c.DateTime());
        }
    }
}
