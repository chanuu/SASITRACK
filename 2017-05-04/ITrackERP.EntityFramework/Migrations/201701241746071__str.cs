namespace ITrackERP.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _str : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ElasticDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        StyleId = c.Guid(nullable: false),
                        FabricColour = c.String(),
                        ElasticColour = c.String(),
                        Cumption = c.String(),
                        Width = c.Double(nullable: false),
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
                    { "DynamicFilter_ElasticDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ElasticDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Styles", t => t.StyleId, cascadeDelete: true)
                .Index(t => t.StyleId);
            
            CreateTable(
                "dbo.FabricDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        StyleId = c.Guid(nullable: false),
                        FabricType = c.String(),
                        isFullyInspected = c.Boolean(nullable: false),
                        isPartiallyInspected = c.Boolean(nullable: false),
                        ShrinkageToSteam = c.Double(nullable: false),
                        ShrinkageToWashing = c.Double(nullable: false),
                        ShrinkageToFusing = c.Double(nullable: false),
                        FabricRelaxation24Hours = c.Double(nullable: false),
                        LayingOnPins = c.Double(nullable: false),
                        LotOnToFollow = c.Double(nullable: false),
                        FaceToFace = c.Double(nullable: false),
                        BlockAndRelayOnPins = c.Double(nullable: false),
                        TwillDirection = c.Double(nullable: false),
                        NapUp = c.Double(nullable: false),
                        NapDown = c.Double(nullable: false),
                        Custom = c.Double(nullable: false),
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
                    { "DynamicFilter_FabricDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_FabricDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Styles", t => t.StyleId, cascadeDelete: true)
                .Index(t => t.StyleId);
            
            CreateTable(
                "dbo.SewingThreadAndNeedleDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        StyleId = c.Guid(nullable: false),
                        SeamType = c.String(),
                        SPI = c.String(),
                        TKTNo = c.String(),
                        NeedleType = c.String(),
                        NeedleSize = c.String(),
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
                    { "DynamicFilter_SewingThreadAndNeedleDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_SewingThreadAndNeedleDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Styles", t => t.StyleId, cascadeDelete: true)
                .Index(t => t.StyleId);
            
            CreateTable(
                "dbo.ZipperDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        StyleId = c.Guid(nullable: false),
                        FabricColour = c.String(),
                        ZipperColour = c.String(),
                        ZipperLength = c.Double(nullable: false),
                        Size = c.String(),
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
                    { "DynamicFilter_ZipperDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ZipperDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Styles", t => t.StyleId, cascadeDelete: true)
                .Index(t => t.StyleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZipperDetails", "StyleId", "dbo.Styles");
            DropForeignKey("dbo.SewingThreadAndNeedleDetails", "StyleId", "dbo.Styles");
            DropForeignKey("dbo.FabricDetails", "StyleId", "dbo.Styles");
            DropForeignKey("dbo.ElasticDetails", "StyleId", "dbo.Styles");
            DropIndex("dbo.ZipperDetails", new[] { "StyleId" });
            DropIndex("dbo.SewingThreadAndNeedleDetails", new[] { "StyleId" });
            DropIndex("dbo.FabricDetails", new[] { "StyleId" });
            DropIndex("dbo.ElasticDetails", new[] { "StyleId" });
            DropTable("dbo.ZipperDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ZipperDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ZipperDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.SewingThreadAndNeedleDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SewingThreadAndNeedleDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_SewingThreadAndNeedleDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.FabricDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FabricDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_FabricDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ElasticDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ElasticDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ElasticDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
