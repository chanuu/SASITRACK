namespace ITrackERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailyProductionSummaries", "LineInTotal", c => c.Int(nullable: false));
            AddColumn("dbo.DailyProductionSummaries", "LineOutTotal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DailyProductionSummaries", "LineOutTotal");
            DropColumn("dbo.DailyProductionSummaries", "LineInTotal");
        }
    }
}
