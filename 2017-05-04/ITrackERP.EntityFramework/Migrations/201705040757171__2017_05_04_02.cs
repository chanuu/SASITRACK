namespace ITrackERP.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _2017_05_04_02 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DaliyPlanHeaders", newName: "DailyPlanHeaders");
            DropForeignKey("dbo.DailyCutPlanItems", "DailyPlanHeaderId", "dbo.DailyCutPlanHeaders");
            DropIndex("dbo.DailyCutPlanItems", new[] { "DailyPlanHeaderId" });
            RenameColumn(table: "dbo.DailyPlanItems", name: "DaliyPlanHeaderId", newName: "DailyPlanHeaderId");
            RenameIndex(table: "dbo.DailyPlanItems", name: "IX_DaliyPlanHeaderId", newName: "IX_DailyPlanHeaderId");
            AlterTableAnnotations(
                "dbo.DailyPlanHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Date = c.DateTime(),
                        PlanBy = c.String(),
                        Remark = c.String(),
                        Status = c.String(),
                        ApprovedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_DailyPlanHeader_MustHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_DailyPlanHeader_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_DaliyPlanHeader_MustHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_DaliyPlanHeader_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterColumn("dbo.DailyPlanHeaders", "Date", c => c.DateTime());
            AlterColumn("dbo.DailyPlanHeaders", "Remark", c => c.String());
            DropTable("dbo.DailyCutPlanItems",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DailyCutPlanItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DailyCutPlanItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DailyCutPlanHeaders",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DailyCutPlanHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DailyCutPlanHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DailyCutPlanHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Date = c.DateTime(),
                        PlanBy = c.String(),
                        Remark = c.String(),
                        Status = c.String(),
                        ApprovedBy = c.String(),
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
                    { "DynamicFilter_DailyCutPlanHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DailyCutPlanHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DailyCutPlanItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        DailyPlanHeaderId = c.Guid(nullable: false),
                        StyleNo = c.String(),
                        PONo = c.String(),
                        Color = c.String(),
                        Size = c.String(),
                        Length = c.String(),
                        NoOfPlys = c.Int(nullable: false),
                        NoOfItem = c.Int(nullable: false),
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
                    { "DynamicFilter_DailyCutPlanItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DailyCutPlanItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.DailyPlanHeaders", "Remark", c => c.Int(nullable: false));
            AlterColumn("dbo.DailyPlanHeaders", "Date", c => c.DateTime(nullable: false));
            AlterTableAnnotations(
                "dbo.DailyPlanHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Date = c.DateTime(),
                        PlanBy = c.String(),
                        Remark = c.String(),
                        Status = c.String(),
                        ApprovedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_DailyPlanHeader_MustHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_DailyPlanHeader_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_DaliyPlanHeader_MustHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_DaliyPlanHeader_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            RenameIndex(table: "dbo.DailyPlanItems", name: "IX_DailyPlanHeaderId", newName: "IX_DaliyPlanHeaderId");
            RenameColumn(table: "dbo.DailyPlanItems", name: "DailyPlanHeaderId", newName: "DaliyPlanHeaderId");
            CreateIndex("dbo.DailyCutPlanItems", "DailyPlanHeaderId");
            AddForeignKey("dbo.DailyCutPlanItems", "DailyPlanHeaderId", "dbo.DailyCutPlanHeaders", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.DailyPlanHeaders", newName: "DaliyPlanHeaders");
        }
    }
}
