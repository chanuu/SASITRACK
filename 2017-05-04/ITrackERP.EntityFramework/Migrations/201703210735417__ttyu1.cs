namespace ITrackERP.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _ttyu1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LayoutHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        DividingPlanHeaderId = c.Guid(nullable: false),
                        LayoutJson = c.String(),
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
                    { "DynamicFilter_LayoutHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_LayoutHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DividingPlanHeaders", t => t.DividingPlanHeaderId, cascadeDelete: true)
                .Index(t => t.DividingPlanHeaderId);
            
            CreateTable(
                "dbo.LayoutItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        LayoutHeaderId = c.Guid(nullable: false),
                        Key = c.String(),
                        Size = c.String(),
                        Source = c.String(),
                        Position = c.String(),
                        Group = c.String(),
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
                    { "DynamicFilter_LayoutItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_LayoutItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LayoutHeaders", t => t.LayoutHeaderId, cascadeDelete: true)
                .Index(t => t.LayoutHeaderId);
            
            CreateTable(
                "dbo.Elements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Name = c.String(),
                        Length = c.Double(nullable: false),
                        Width = c.Double(nullable: false),
                        Category = c.String(),
                        Path = c.String(),
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
                    { "DynamicFilter_Element_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Element_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LayoutItems", "LayoutHeaderId", "dbo.LayoutHeaders");
            DropForeignKey("dbo.LayoutHeaders", "DividingPlanHeaderId", "dbo.DividingPlanHeaders");
            DropIndex("dbo.LayoutItems", new[] { "LayoutHeaderId" });
            DropIndex("dbo.LayoutHeaders", new[] { "DividingPlanHeaderId" });
            DropTable("dbo.Elements",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Element_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Element_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.LayoutItems",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LayoutItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_LayoutItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.LayoutHeaders",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LayoutHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_LayoutHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
