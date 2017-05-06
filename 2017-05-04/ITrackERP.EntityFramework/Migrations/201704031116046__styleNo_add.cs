namespace ITrackERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _styleNo_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrderHeaders", "StyleNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkOrderHeaders", "StyleNo");
        }
    }
}
