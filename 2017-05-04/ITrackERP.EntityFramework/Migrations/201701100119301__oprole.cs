namespace ITrackERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _oprole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IndividualProductionDetails", "OperationRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IndividualProductionDetails", "OperationRole");
        }
    }
}
