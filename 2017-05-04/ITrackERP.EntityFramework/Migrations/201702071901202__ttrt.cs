namespace ITrackERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _ttrt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EstimateConsumptiones", "EstimateConsumptionNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EstimateConsumptiones", "EstimateConsumptionNo", c => c.Double(nullable: false));
        }
    }
}
