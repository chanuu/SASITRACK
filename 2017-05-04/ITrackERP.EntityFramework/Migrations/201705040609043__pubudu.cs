namespace ITrackERP.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _pubudu : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CertificateCategories", newName: "CategorySetups");
            DropForeignKey("dbo.CertificateSubCategories", "CertificateCategoryId", "dbo.CertificateCategories");
            DropForeignKey("dbo.Certificates", "CertificateSubCategoryId", "dbo.CertificateSubCategories");
            DropForeignKey("dbo.DocumentSubCategories", "DocumentCategoryId", "dbo.DocumentCategories");
            DropForeignKey("dbo.DocumentSubSubCategories", "DocumentSubCategoryId", "dbo.DocumentSubCategories");
            DropForeignKey("dbo.PolicySubCategories", "PolicyCategoryId", "dbo.PolicyCategories");
            DropForeignKey("dbo.PolicySubSubCategories", "PolicySubCategoryId", "dbo.PolicySubCategories");
            DropForeignKey("dbo.TestReportSubCategories", "TestReportCategoryId", "dbo.TestReportCategories");
            DropIndex("dbo.CertificateSubCategories", new[] { "CertificateCategoryId" });
            DropIndex("dbo.Certificates", new[] { "CertificateSubCategoryId" });
            DropIndex("dbo.DocumentSubCategories", new[] { "DocumentCategoryId" });
            DropIndex("dbo.DocumentSubSubCategories", new[] { "DocumentSubCategoryId" });
            DropIndex("dbo.PolicySubCategories", new[] { "PolicyCategoryId" });
            DropIndex("dbo.PolicySubSubCategories", new[] { "PolicySubCategoryId" });
            DropIndex("dbo.TestReportSubCategories", new[] { "TestReportCategoryId" });
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        EventHeaderId = c.Guid(nullable: false),
                        Name = c.String(),
                        Url = c.String(),
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
                    { "DynamicFilter_Album_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Album_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventHeaders", t => t.EventHeaderId, cascadeDelete: true)
                .Index(t => t.EventHeaderId);
            
            CreateTable(
                "dbo.EventHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Type = c.String(),
                        Date = c.DateTime(),
                        Frequency = c.String(),
                        ExpectedDate = c.DateTime(),
                        Department = c.String(),
                        Venue = c.String(),
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
                    { "DynamicFilter_EventHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_EventHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invitees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        EventHeaderId = c.Guid(nullable: false),
                        Name = c.String(),
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
                    { "DynamicFilter_Invitee_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Invitee_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventHeaders", t => t.EventHeaderId, cascadeDelete: true)
                .Index(t => t.EventHeaderId);
            
            CreateTable(
                "dbo.AssetVerificationDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        AssetVerificationHeaderId = c.Guid(nullable: false),
                        BarcodeId = c.String(),
                        AssetId = c.String(),
                        UsedBy = c.String(),
                        Condition = c.String(),
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
                    { "DynamicFilter_AssetVerificationDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetVerificationDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetVerificationHeaders", t => t.AssetVerificationHeaderId, cascadeDelete: true)
                .Index(t => t.AssetVerificationHeaderId);
            
            CreateTable(
                "dbo.AssetVerificationHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        AssetVerificationNo = c.String(),
                        Date = c.DateTime(),
                        LocationCode = c.String(),
                        ApprovedBy = c.String(),
                        ApprovedAt = c.DateTime(),
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
                    { "DynamicFilter_AssetVerificationHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetVerificationHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        CustomeFiledSetupId = c.Guid(nullable: false),
                        Type = c.String(),
                        CustomField1 = c.String(),
                        CustomField2 = c.String(),
                        CustomField3 = c.String(),
                        CustomField4 = c.String(),
                        CustomField5 = c.String(),
                        CustomField6 = c.String(),
                        Category1 = c.String(),
                        Category2 = c.String(),
                        Category3 = c.String(),
                        Category4 = c.String(),
                        Category5 = c.String(),
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
                    { "DynamicFilter_Files_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Files_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            AlterTableAnnotations(
                "dbo.CategorySetups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Type = c.String(),
                        Name = c.String(),
                        LevelNo = c.String(),
                        CategoryName = c.String(),
                        Remark = c.String(),
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
                        "DynamicFilter_CategorySetup_MustHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_CategorySetup_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_CertificateCategory_MustHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_CertificateCategory_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AddColumn("dbo.AssetLedgers", "UsedByLocation", c => c.String());
            AddColumn("dbo.CategorySetups", "Type", c => c.String());
            AddColumn("dbo.CategorySetups", "LevelNo", c => c.String());
            AddColumn("dbo.CategorySetups", "CategoryName", c => c.String());
            AddColumn("dbo.Departments", "BarcodeNo", c => c.String());
            AddColumn("dbo.Departments", "Length", c => c.Double(nullable: false));
            AddColumn("dbo.Departments", "Width", c => c.Double(nullable: false));
            DropTable("dbo.CertificateSubCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CertificateSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_CertificateSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Certificates",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Certificate_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Certificate_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DocumentCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DocumentCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DocumentCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DocumentSubCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DocumentSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DocumentSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DocumentSubSubCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DocumentSubSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DocumentSubSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PolicyCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PolicyCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_PolicyCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PolicySubCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PolicySubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_PolicySubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PolicySubSubCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PolicySubSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_PolicySubSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TestReportCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TestReportCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_TestReportCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TestReportSubCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TestReportSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_TestReportSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestReportSubCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        TestReportCategoryId = c.Guid(nullable: false),
                        Name = c.String(),
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
                    { "DynamicFilter_TestReportSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_TestReportSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestReportCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Name = c.String(),
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
                    { "DynamicFilter_TestReportCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_TestReportCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PolicySubSubCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        PolicySubCategoryId = c.Guid(nullable: false),
                        Name = c.String(),
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
                    { "DynamicFilter_PolicySubSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_PolicySubSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PolicySubCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        PolicyCategoryId = c.Guid(nullable: false),
                        Name = c.String(),
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
                    { "DynamicFilter_PolicySubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_PolicySubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PolicyCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Name = c.String(),
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
                    { "DynamicFilter_PolicyCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_PolicyCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentSubSubCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        DocumentSubCategoryId = c.Guid(nullable: false),
                        Name = c.String(),
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
                    { "DynamicFilter_DocumentSubSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DocumentSubSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentSubCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        DocumentCategoryId = c.Guid(nullable: false),
                        Name = c.String(),
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
                    { "DynamicFilter_DocumentSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DocumentSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Name = c.String(),
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
                    { "DynamicFilter_DocumentCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DocumentCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        CertificateSubCategoryId = c.Guid(nullable: false),
                        Name = c.String(),
                        IssuedDate = c.DateTime(),
                        DateOfExpiry = c.DateTime(),
                        Description = c.String(),
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
                    { "DynamicFilter_Certificate_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Certificate_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CertificateSubCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        CertificateCategoryId = c.Guid(nullable: false),
                        Name = c.String(),
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
                    { "DynamicFilter_CertificateSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_CertificateSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AssetVerificationDetails", "AssetVerificationHeaderId", "dbo.AssetVerificationHeaders");
            DropForeignKey("dbo.Invitees", "EventHeaderId", "dbo.EventHeaders");
            DropForeignKey("dbo.Albums", "EventHeaderId", "dbo.EventHeaders");
            DropIndex("dbo.AssetVerificationDetails", new[] { "AssetVerificationHeaderId" });
            DropIndex("dbo.Invitees", new[] { "EventHeaderId" });
            DropIndex("dbo.Albums", new[] { "EventHeaderId" });
            DropColumn("dbo.Departments", "Width");
            DropColumn("dbo.Departments", "Length");
            DropColumn("dbo.Departments", "BarcodeNo");
            DropColumn("dbo.CategorySetups", "CategoryName");
            DropColumn("dbo.CategorySetups", "LevelNo");
            DropColumn("dbo.CategorySetups", "Type");
            DropColumn("dbo.AssetLedgers", "UsedByLocation");
            AlterTableAnnotations(
                "dbo.CategorySetups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        Type = c.String(),
                        Name = c.String(),
                        LevelNo = c.String(),
                        CategoryName = c.String(),
                        Remark = c.String(),
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
                        "DynamicFilter_CategorySetup_MustHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_CategorySetup_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_CertificateCategory_MustHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_CertificateCategory_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            DropTable("dbo.Files",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Files_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Files_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AssetVerificationHeaders",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AssetVerificationHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetVerificationHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AssetVerificationDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AssetVerificationDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetVerificationDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Invitees",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Invitee_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Invitee_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.EventHeaders",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EventHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_EventHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Albums",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Album_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Album_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            CreateIndex("dbo.TestReportSubCategories", "TestReportCategoryId");
            CreateIndex("dbo.PolicySubSubCategories", "PolicySubCategoryId");
            CreateIndex("dbo.PolicySubCategories", "PolicyCategoryId");
            CreateIndex("dbo.DocumentSubSubCategories", "DocumentSubCategoryId");
            CreateIndex("dbo.DocumentSubCategories", "DocumentCategoryId");
            CreateIndex("dbo.Certificates", "CertificateSubCategoryId");
            CreateIndex("dbo.CertificateSubCategories", "CertificateCategoryId");
            AddForeignKey("dbo.TestReportSubCategories", "TestReportCategoryId", "dbo.TestReportCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PolicySubSubCategories", "PolicySubCategoryId", "dbo.PolicySubCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PolicySubCategories", "PolicyCategoryId", "dbo.PolicyCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DocumentSubSubCategories", "DocumentSubCategoryId", "dbo.DocumentSubCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DocumentSubCategories", "DocumentCategoryId", "dbo.DocumentCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Certificates", "CertificateSubCategoryId", "dbo.CertificateSubCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CertificateSubCategories", "CertificateCategoryId", "dbo.CertificateCategories", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.CategorySetups", newName: "CertificateCategories");
        }
    }
}
