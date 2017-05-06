namespace ITrackERP.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _document_mangement_tbls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CertificateCategories",
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
                    { "DynamicFilter_CertificateCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_CertificateCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CertificateCategories", t => t.CertificateCategoryId, cascadeDelete: true)
                .Index(t => t.CertificateCategoryId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CertificateSubCategories", t => t.CertificateSubCategoryId, cascadeDelete: true)
                .Index(t => t.CertificateSubCategoryId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DailyCutPlanHeaders", t => t.DailyPlanHeaderId, cascadeDelete: true)
                .Index(t => t.DailyPlanHeaderId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentCategories", t => t.DocumentCategoryId, cascadeDelete: true)
                .Index(t => t.DocumentCategoryId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentSubCategories", t => t.DocumentSubCategoryId, cascadeDelete: true)
                .Index(t => t.DocumentSubCategoryId);
            
            CreateTable(
                "dbo.IssueNoteHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        StyleId = c.Guid(nullable: false),
                        StyleNo = c.String(),
                        IssueNoteNo = c.String(),
                        IssueTo = c.String(),
                        IssueType = c.String(),
                        IssuedBy = c.String(),
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
                    { "DynamicFilter_IssueNoteHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_IssueNoteHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Styles", t => t.StyleId, cascadeDelete: true)
                .Index(t => t.StyleId);
            
            CreateTable(
                "dbo.IssueNoteItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        IssueNoteHeaderId = c.Guid(nullable: false),
                        CutNo = c.String(),
                        Color = c.String(),
                        Size = c.String(),
                        NoOfPlys = c.String(),
                        NoOfItem = c.String(),
                        PONo = c.String(),
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
                    { "DynamicFilter_IssueNoteItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_IssueNoteItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IssueNoteHeaders", t => t.IssueNoteHeaderId, cascadeDelete: true)
                .Index(t => t.IssueNoteHeaderId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PolicyCategories", t => t.PolicyCategoryId, cascadeDelete: true)
                .Index(t => t.PolicyCategoryId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PolicySubCategories", t => t.PolicySubCategoryId, cascadeDelete: true)
                .Index(t => t.PolicySubCategoryId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestReportCategories", t => t.TestReportCategoryId, cascadeDelete: true)
                .Index(t => t.TestReportCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestReportSubCategories", "TestReportCategoryId", "dbo.TestReportCategories");
            DropForeignKey("dbo.PolicySubSubCategories", "PolicySubCategoryId", "dbo.PolicySubCategories");
            DropForeignKey("dbo.PolicySubCategories", "PolicyCategoryId", "dbo.PolicyCategories");
            DropForeignKey("dbo.IssueNoteHeaders", "StyleId", "dbo.Styles");
            DropForeignKey("dbo.IssueNoteItems", "IssueNoteHeaderId", "dbo.IssueNoteHeaders");
            DropForeignKey("dbo.DocumentSubSubCategories", "DocumentSubCategoryId", "dbo.DocumentSubCategories");
            DropForeignKey("dbo.DocumentSubCategories", "DocumentCategoryId", "dbo.DocumentCategories");
            DropForeignKey("dbo.DailyCutPlanItems", "DailyPlanHeaderId", "dbo.DailyCutPlanHeaders");
            DropForeignKey("dbo.Certificates", "CertificateSubCategoryId", "dbo.CertificateSubCategories");
            DropForeignKey("dbo.CertificateSubCategories", "CertificateCategoryId", "dbo.CertificateCategories");
            DropIndex("dbo.TestReportSubCategories", new[] { "TestReportCategoryId" });
            DropIndex("dbo.PolicySubSubCategories", new[] { "PolicySubCategoryId" });
            DropIndex("dbo.PolicySubCategories", new[] { "PolicyCategoryId" });
            DropIndex("dbo.IssueNoteItems", new[] { "IssueNoteHeaderId" });
            DropIndex("dbo.IssueNoteHeaders", new[] { "StyleId" });
            DropIndex("dbo.DocumentSubSubCategories", new[] { "DocumentSubCategoryId" });
            DropIndex("dbo.DocumentSubCategories", new[] { "DocumentCategoryId" });
            DropIndex("dbo.DailyCutPlanItems", new[] { "DailyPlanHeaderId" });
            DropIndex("dbo.Certificates", new[] { "CertificateSubCategoryId" });
            DropIndex("dbo.CertificateSubCategories", new[] { "CertificateCategoryId" });
            DropTable("dbo.TestReportSubCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TestReportSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_TestReportSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.TestReportCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_TestReportCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_TestReportCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PolicySubSubCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PolicySubSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_PolicySubSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PolicySubCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PolicySubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_PolicySubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PolicyCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PolicyCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_PolicyCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.IssueNoteItems",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_IssueNoteItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_IssueNoteItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.IssueNoteHeaders",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_IssueNoteHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_IssueNoteHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DocumentSubSubCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DocumentSubSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DocumentSubSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DocumentSubCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DocumentSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DocumentSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DocumentCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DocumentCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DocumentCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
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
            DropTable("dbo.Certificates",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Certificate_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Certificate_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CertificateSubCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CertificateSubCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_CertificateSubCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CertificateCategories",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CertificateCategory_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_CertificateCategory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
