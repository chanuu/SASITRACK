namespace ITrackERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _ttxz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CuttingMasters", "isCuttingStarted", c => c.Boolean(nullable: false));
            AddColumn("dbo.CuttingMasters", "CuttingStartedDate", c => c.DateTime());
            AddColumn("dbo.CuttingMasters", "isCuttingFinised", c => c.Boolean(nullable: false));
            AddColumn("dbo.CuttingMasters", "CuttingFinishedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CuttingMasters", "CuttingFinishedDate");
            DropColumn("dbo.CuttingMasters", "isCuttingFinised");
            DropColumn("dbo.CuttingMasters", "CuttingStartedDate");
            DropColumn("dbo.CuttingMasters", "isCuttingStarted");
        }
    }
}
