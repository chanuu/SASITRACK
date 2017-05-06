namespace ITrackERP.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _plan_tbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyPlanItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        DaliyPlanHeaderId = c.Guid(nullable: false),
                        StyleNo = c.String(),
                        PoNO = c.String(),
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
                    { "DynamicFilter_DailyPlanItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DailyPlanItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DaliyPlanHeaders", t => t.DaliyPlanHeaderId, cascadeDelete: true)
                .Index(t => t.DaliyPlanHeaderId);
            
            CreateTable(
                "dbo.DaliyPlanHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        PlanBy = c.String(),
                        Remark = c.Int(nullable: false),
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
                    { "DynamicFilter_DaliyPlanHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DaliyPlanHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailyPlanItems", "DaliyPlanHeaderId", "dbo.DaliyPlanHeaders");
            DropIndex("dbo.DailyPlanItems", new[] { "DaliyPlanHeaderId" });
            DropTable("dbo.DaliyPlanHeaders",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DaliyPlanHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DaliyPlanHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DailyPlanItems",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DailyPlanItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DailyPlanItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
