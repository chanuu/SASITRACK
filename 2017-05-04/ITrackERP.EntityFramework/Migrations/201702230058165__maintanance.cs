namespace ITrackERP.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _maintanance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobCardHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        JobcardNo = c.String(),
                        Date = c.DateTime(),
                        AssetNo = c.String(),
                        Description = c.String(),
                        TotalCost = c.Double(nullable: false),
                        DoneBy = c.String(),
                        CheckedBy = c.String(),
                        Remark = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_JobCardHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_JobCardHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobCardItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        JobCardHeaderId = c.Guid(nullable: false),
                        ItemCode = c.String(),
                        SerialNo = c.String(),
                        Amount = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_JobCardItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_JobCardItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobCardHeaders", t => t.JobCardHeaderId, cascadeDelete: true)
                .Index(t => t.JobCardHeaderId);
            
            CreateTable(
                "dbo.ReceiveNoteItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        ItemMasterId = c.Guid(nullable: false),
                        StockReceiveHeaderId = c.Guid(nullable: false),
                        ItemCode = c.String(),
                        PurchasePrice = c.Double(nullable: false),
                        Nos = c.Int(nullable: false),
                        isIncludeSerials = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ReceiveNoteItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ReceiveNoteItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StockReceiveHeaders", t => t.StockReceiveHeaderId, cascadeDelete: true)
                .Index(t => t.StockReceiveHeaderId);
            
            CreateTable(
                "dbo.SerialItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        ReceiveNoteItemId = c.Guid(nullable: false),
                        SerialNo = c.String(),
                        Status = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SerialItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_SerialItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReceiveNoteItems", t => t.ReceiveNoteItemId, cascadeDelete: true)
                .Index(t => t.ReceiveNoteItemId);
            
            CreateTable(
                "dbo.StockReceiveHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        ReceiveNoteNo = c.String(),
                        Date = c.DateTime(),
                        Remark = c.String(),
                        By = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_StockReceiveHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_StockReceiveHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockLedgers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        ItemCode = c.String(),
                        Date = c.DateTime(),
                        TransactionType = c.String(),
                        DocNo = c.String(),
                        UsedStock = c.Int(nullable: false),
                        BalanceStock = c.Int(nullable: false),
                        Status = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_StockLedger_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_StockLedger_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceiveNoteItems", "StockReceiveHeaderId", "dbo.StockReceiveHeaders");
            DropForeignKey("dbo.SerialItems", "ReceiveNoteItemId", "dbo.ReceiveNoteItems");
            DropForeignKey("dbo.JobCardItems", "JobCardHeaderId", "dbo.JobCardHeaders");
            DropIndex("dbo.SerialItems", new[] { "ReceiveNoteItemId" });
            DropIndex("dbo.ReceiveNoteItems", new[] { "StockReceiveHeaderId" });
            DropIndex("dbo.JobCardItems", new[] { "JobCardHeaderId" });
            DropTable("dbo.StockLedgers",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_StockLedger_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_StockLedger_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.StockReceiveHeaders",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_StockReceiveHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_StockReceiveHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.SerialItems",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SerialItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_SerialItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ReceiveNoteItems",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ReceiveNoteItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ReceiveNoteItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.JobCardItems",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_JobCardItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_JobCardItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.JobCardHeaders",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_JobCardHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_JobCardHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
