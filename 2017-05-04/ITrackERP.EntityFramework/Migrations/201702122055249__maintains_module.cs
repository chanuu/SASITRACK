namespace ITrackERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _maintains_module : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomeFiledSetups", "ItemMasterId", "dbo.ItemMasters");
            DropIndex("dbo.CustomeFiledSetups", new[] { "ItemMasterId" });
            RenameColumn(table: "dbo.CustomeFiledSetups", name: "ItemMasterId", newName: "ItemMaster_Id");
            AddColumn("dbo.AssetDisposalHeaders", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Assets", "CustomeFiledSetupId", c => c.Guid(nullable: false));
            AddColumn("dbo.AssetTransferHeaders", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.AssetTransferHeaders", "FromLocation", c => c.String());
            AddColumn("dbo.AssetTransferHeaders", "ToLocation", c => c.String());
            AddColumn("dbo.ItemMasters", "SerialItem", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CustomeFiledSetups", "ItemMaster_Id", c => c.Guid());
            CreateIndex("dbo.Assets", "CustomeFiledSetupId");
            CreateIndex("dbo.CustomeFiledSetups", "ItemMaster_Id");
            AddForeignKey("dbo.Assets", "CustomeFiledSetupId", "dbo.CustomeFiledSetups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomeFiledSetups", "ItemMaster_Id", "dbo.ItemMasters", "Id");
            DropColumn("dbo.ItemMasters", "SerialItems");
            DropColumn("dbo.MachineRequirements", "FromDate");
            DropColumn("dbo.MachineRequirements", "ToDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MachineRequirements", "ToDate", c => c.DateTime());
            AddColumn("dbo.MachineRequirements", "FromDate", c => c.DateTime());
            AddColumn("dbo.ItemMasters", "SerialItems", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.CustomeFiledSetups", "ItemMaster_Id", "dbo.ItemMasters");
            DropForeignKey("dbo.Assets", "CustomeFiledSetupId", "dbo.CustomeFiledSetups");
            DropIndex("dbo.CustomeFiledSetups", new[] { "ItemMaster_Id" });
            DropIndex("dbo.Assets", new[] { "CustomeFiledSetupId" });
            AlterColumn("dbo.CustomeFiledSetups", "ItemMaster_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.ItemMasters", "SerialItem");
            DropColumn("dbo.AssetTransferHeaders", "ToLocation");
            DropColumn("dbo.AssetTransferHeaders", "FromLocation");
            DropColumn("dbo.AssetTransferHeaders", "Date");
            DropColumn("dbo.Assets", "CustomeFiledSetupId");
            DropColumn("dbo.AssetDisposalHeaders", "Date");
            RenameColumn(table: "dbo.CustomeFiledSetups", name: "ItemMaster_Id", newName: "ItemMasterId");
            CreateIndex("dbo.CustomeFiledSetups", "ItemMasterId");
            AddForeignKey("dbo.CustomeFiledSetups", "ItemMasterId", "dbo.ItemMasters", "Id", cascadeDelete: true);
        }
    }
}
