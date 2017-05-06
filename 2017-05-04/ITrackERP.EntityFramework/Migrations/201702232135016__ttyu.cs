namespace ITrackERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _ttyu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SerialItems", "ItemCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SerialItems", "ItemCode");
        }
    }
}
