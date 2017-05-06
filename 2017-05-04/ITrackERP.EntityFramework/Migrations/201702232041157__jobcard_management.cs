namespace ITrackERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _jobcard_management : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobCardHeaders", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobCardHeaders", "Status");
        }
    }
}
