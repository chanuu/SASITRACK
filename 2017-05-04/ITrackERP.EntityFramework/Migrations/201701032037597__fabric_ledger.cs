namespace ITrackERP.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _fabric_ledger : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FabricLedgers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        MarkerNo = c.String(),
                        RollNo = c.String(),
                        NotedLength = c.Double(nullable: false),
                        Type = c.String(),
                        Date = c.DateTime(nullable: false),
                        MarkerLength = c.Double(nullable: false),
                        NoOfFlys = c.Int(nullable: false),
                        FabricUsed = c.Double(nullable: false),
                        NotedBalance = c.Double(nullable: false),
                        ActualBalance = c.Double(nullable: false),
                        StyleNo = c.String(),
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
                    { "DynamicFilter_FabricLedger_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_FabricLedger_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FabricLedgers",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FabricLedger_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_FabricLedger_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
