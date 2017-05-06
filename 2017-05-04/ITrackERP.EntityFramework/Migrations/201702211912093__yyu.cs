namespace ITrackERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _yyu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomeFiledSetups", "ItemMaster_Id", "dbo.ItemMasters");
            DropIndex("dbo.CustomeFiledSetups", new[] { "ItemMaster_Id" });
            AddColumn("dbo.ItemMasters", "CustomeFiledSetupId", c => c.Guid(nullable: false));
            CreateIndex("dbo.ItemMasters", "CustomeFiledSetupId");
            AddForeignKey("dbo.ItemMasters", "CustomeFiledSetupId", "dbo.CustomeFiledSetups", "Id", cascadeDelete: true);
            DropColumn("dbo.CustomeFiledSetups", "ItemMaster_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomeFiledSetups", "ItemMaster_Id", c => c.Guid());
            DropForeignKey("dbo.ItemMasters", "CustomeFiledSetupId", "dbo.CustomeFiledSetups");
            DropIndex("dbo.ItemMasters", new[] { "CustomeFiledSetupId" });
            DropColumn("dbo.ItemMasters", "CustomeFiledSetupId");
            CreateIndex("dbo.CustomeFiledSetups", "ItemMaster_Id");
            AddForeignKey("dbo.CustomeFiledSetups", "ItemMaster_Id", "dbo.ItemMasters", "Id");
        }
    }
}
