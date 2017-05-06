namespace ITrackERP.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _pp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyProductionSummaries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        DayendID = c.String(),
                        Date = c.DateTime(nullable: false),
                        LineNo = c.String(),
                        StyleNo = c.String(),
                        PoNo = c.String(),
                        Color = c.String(),
                        Size = c.String(),
                        Length = c.String(),
                        CutQty = c.Int(nullable: false),
                        LineIn = c.Int(nullable: false),
                        LineInCumm = c.Int(nullable: false),
                        LineOut = c.Int(nullable: false),
                        LineOutCumm = c.Int(nullable: false),
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
                    { "DynamicFilter_DailyProductionSummary_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DailyProductionSummary_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IndividualProductionDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        EmployeeID = c.String(),
                        EmployeeName = c.String(),
                        StyleNo = c.String(),
                        Date = c.DateTime(nullable: false),
                        HourNo = c.Int(nullable: false),
                        WorkstationNo = c.Int(nullable: false),
                        OperationNo = c.String(),
                        LineNo = c.String(),
                        Module = c.String(),
                        OperationName = c.String(),
                        Pcs = c.Int(nullable: false),
                        SMV = c.Double(nullable: false),
                        SAH = c.Double(nullable: false),
                        Efficiency = c.Double(nullable: false),
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
                    { "DynamicFilter_IndividualProductionDetails_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_IndividualProductionDetails_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IndividualProductionDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_IndividualProductionDetails_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_IndividualProductionDetails_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DailyProductionSummaries",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DailyProductionSummary_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DailyProductionSummary_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
