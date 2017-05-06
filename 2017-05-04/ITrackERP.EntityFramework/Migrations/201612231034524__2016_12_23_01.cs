namespace ITrackERP.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _2016_12_23_01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        AssetNo = c.String(),
                        AssetName = c.String(),
                        Description = c.String(),
                        AlternetAsset = c.String(),
                        AssetStatus = c.String(),
                        WarrantyPeriod = c.String(),
                        PurchaseLocation = c.String(),
                        Location = c.String(),
                        AssetUsedBy = c.String(),
                        Category01 = c.String(),
                        Category02 = c.String(),
                        Category03 = c.String(),
                        Category04 = c.String(),
                        Category05 = c.String(),
                        CustomField1 = c.String(),
                        CustomField2 = c.String(),
                        CustomField3 = c.String(),
                        CustomField4 = c.String(),
                        CustomField5 = c.String(),
                        CustomField6 = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchasePrice = c.String(),
                        SupplierName = c.String(),
                        DepreciationMode = c.String(),
                        CurrentValue = c.String(),
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
                    { "DynamicFilter_Asset_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Asset_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Assets",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Asset_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Asset_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
