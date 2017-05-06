namespace ITrackERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _poNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndividualProductionDetails", "PoNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndividualProductionDetails", "PoNo");
        }
    }
}
