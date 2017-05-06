namespace ITrackERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MachineRequirements", "FromDate", c => c.DateTime());
            AddColumn("dbo.MachineRequirements", "ToDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MachineRequirements", "ToDate");
            DropColumn("dbo.MachineRequirements", "FromDate");
        }
    }
}
