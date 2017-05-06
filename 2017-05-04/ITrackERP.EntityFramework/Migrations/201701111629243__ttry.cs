namespace ITrackERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _ttry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndividualProductionDetails", "Color", c => c.String());
            AddColumn("dbo.IndividualProductionDetails", "Size", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndividualProductionDetails", "Size");
            DropColumn("dbo.IndividualProductionDetails", "Color");
        }
    }
}
