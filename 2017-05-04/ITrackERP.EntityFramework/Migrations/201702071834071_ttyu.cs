namespace ITrackERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ttyu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EstimateConsumptiones", "EstimateConsumptionNo", c => c.Double(nullable: false));
            AlterColumn("dbo.EstimateConsumptiones", "TotalFabricPlan", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EstimateConsumptiones", "TotalFabricPlan", c => c.String());
            AlterColumn("dbo.EstimateConsumptiones", "EstimateConsumptionNo", c => c.String());
        }
    }
}
