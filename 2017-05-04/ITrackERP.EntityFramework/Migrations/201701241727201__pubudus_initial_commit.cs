namespace ITrackERP.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _pubudus_initial_commit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetDisposalDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        AssetDisposalHeaderId = c.Guid(nullable: false),
                        AssetNo = c.String(),
                        Description = c.String(),
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
                    { "DynamicFilter_AssetDisposalDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetDisposalDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetDisposalHeaders", t => t.AssetDisposalHeaderId, cascadeDelete: true)
                .Index(t => t.AssetDisposalHeaderId);
            
            CreateTable(
                "dbo.AssetDisposalHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        DisposalNoteNo = c.String(),
                        Type = c.String(),
                        DisposalBy = c.String(),
                        ApprovedBy = c.String(),
                        Remark = c.String(),
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
                    { "DynamicFilter_AssetDisposalHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetDisposalHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssetLedgers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        TransactionID = c.String(),
                        Date = c.DateTime(),
                        AssetID = c.String(),
                        DocType = c.String(),
                        DocNo = c.String(),
                        AssetType = c.String(),
                        UsedBy = c.String(),
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
                    { "DynamicFilter_AssetLedger_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetLedger_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssetTransferDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        AssetTransferHeaderId = c.Guid(nullable: false),
                        AssetNo = c.String(),
                        Description = c.String(),
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
                    { "DynamicFilter_AssetTransferDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetTransferDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetTransferHeaders", t => t.AssetTransferHeaderId, cascadeDelete: true)
                .Index(t => t.AssetTransferHeaderId);
            
            CreateTable(
                "dbo.AssetTransferHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        TransferNoteNo = c.String(),
                        RequisitionNo = c.String(),
                        Type = c.String(),
                        TransferBy = c.String(),
                        ApprovedBy = c.String(),
                        Remark = c.String(),
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
                    { "DynamicFilter_AssetTransferHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetTransferHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AttatchmentDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        OperationPoolId = c.Guid(nullable: false),
                        AttatchmentType = c.String(),
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
                    { "DynamicFilter_AttatchmentDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AttatchmentDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OperationPools", t => t.OperationPoolId, cascadeDelete: true)
                .Index(t => t.OperationPoolId);
            
            CreateTable(
                "dbo.OperationPools",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        OperationCode = c.String(),
                        OperationName = c.String(),
                        MachineType = c.String(),
                        SMV = c.Double(nullable: false),
                        SMVType = c.String(),
                        Remark = c.String(),
                        PartName = c.String(),
                        OperationRole = c.String(),
                        OperationGrade = c.String(),
                        MachineSpeed = c.String(),
                        SeamLength = c.String(),
                        SeamAllowance = c.String(),
                        SPI = c.String(),
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
                    { "DynamicFilter_OperationPool_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_OperationPool_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FolderDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        OperationPoolId = c.Guid(nullable: false),
                        FolderType = c.String(),
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
                    { "DynamicFilter_FolderDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_FolderDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OperationPools", t => t.OperationPoolId, cascadeDelete: true)
                .Index(t => t.OperationPoolId);
            
            CreateTable(
                "dbo.FootDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        OperationPoolId = c.Guid(nullable: false),
                        FootType = c.String(),
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
                    { "DynamicFilter_FootDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_FootDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OperationPools", t => t.OperationPoolId, cascadeDelete: true)
                .Index(t => t.OperationPoolId);
            
            CreateTable(
                "dbo.NeedleDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        OperationPoolId = c.Guid(nullable: false),
                        NeedleType = c.String(),
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
                    { "DynamicFilter_NeedleDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_NeedleDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OperationPools", t => t.OperationPoolId, cascadeDelete: true)
                .Index(t => t.OperationPoolId);
            
            CreateTable(
                "dbo.ThreadDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        OperationPoolId = c.Guid(nullable: false),
                        ThreadType = c.String(),
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
                    { "DynamicFilter_ThreadDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ThreadDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OperationPools", t => t.OperationPoolId, cascadeDelete: true)
                .Index(t => t.OperationPoolId);
            
            CreateTable(
                "dbo.WorkCycleImages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        OperationPoolId = c.Guid(nullable: false),
                        WorkCycleImagePath = c.String(),
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
                    { "DynamicFilter_WorkCycleImage_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_WorkCycleImage_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OperationPools", t => t.OperationPoolId, cascadeDelete: true)
                .Index(t => t.OperationPoolId);
            
            CreateTable(
                "dbo.WorkCycleVideos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        OperationPoolId = c.Guid(nullable: false),
                        WorkCycleVideoPath = c.String(),
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
                    { "DynamicFilter_WorkCycleVideo_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_WorkCycleVideo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OperationPools", t => t.OperationPoolId, cascadeDelete: true)
                .Index(t => t.OperationPoolId);
            
            CreateTable(
                "dbo.Awards",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                        AwardName = c.String(),
                        AwardDate = c.DateTime(),
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
                    { "DynamicFilter_Award_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Award_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        FullName = c.String(),
                        NicNo = c.String(),
                        EPFNo = c.String(),
                        ETFNo = c.String(),
                        DateOfBirth = c.DateTime(),
                        Gender = c.String(),
                        MaritalStatus = c.String(),
                        Department = c.String(),
                        Designation = c.String(),
                        JobStatus = c.String(),
                        Address = c.String(),
                        MobileNo = c.String(),
                        LandNo = c.String(),
                        EmailAddress = c.String(),
                        EmergencyContactNo = c.String(),
                        EmergencyContactPerson = c.String(),
                        ImagePath = c.String(),
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
                    { "DynamicFilter_Employee_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Employee_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PastEmployeements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                        CompanyName = c.String(),
                        Designation = c.String(),
                        FromDate = c.DateTime(),
                        ToDate = c.DateTime(),
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
                    { "DynamicFilter_PastEmployeement_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_PastEmployeement_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                        FromDesignation = c.String(),
                        ToDesignation = c.String(),
                        PromotedDate = c.DateTime(),
                        JobDescription = c.String(),
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
                    { "DynamicFilter_Promotion_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Promotion_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Departments",
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
                    { "DynamicFilter_Department_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Department_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DividingPlanHeaders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        StyleId = c.Guid(nullable: false),
                        LineNo = c.String(),
                        TotalEmployee = c.Int(nullable: false),
                        Target = c.Int(nullable: false),
                        ProductionPerHour = c.Int(nullable: false),
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
                    { "DynamicFilter_DividingPlanHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DividingPlanHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Styles", t => t.StyleId, cascadeDelete: true)
                .Index(t => t.StyleId);
            
            CreateTable(
                "dbo.DividingPlanItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        DividingPlanHeaderId = c.Guid(nullable: false),
                        OperationNo = c.String(),
                        OperationName = c.String(),
                        SMVType = c.String(),
                        MachineType = c.String(),
                        OperationRole = c.String(),
                        PartName = c.String(),
                        SMV = c.Double(nullable: false),
                        WorkstationNo = c.Int(nullable: false),
                        OpNo = c.Int(nullable: false),
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
                    { "DynamicFilter_DividingPlanItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DividingPlanItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DividingPlanHeaders", t => t.DividingPlanHeaderId, cascadeDelete: true)
                .Index(t => t.DividingPlanHeaderId);
            
            CreateTable(
                "dbo.MachineRequirementItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        MachineRequirementId = c.Guid(nullable: false),
                        MachineType = c.String(),
                        Nos = c.Int(nullable: false),
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
                    { "DynamicFilter_MachineRequirementItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_MachineRequirementItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MachineRequirements", t => t.MachineRequirementId, cascadeDelete: true)
                .Index(t => t.MachineRequirementId);
            
            CreateTable(
                "dbo.MachineRequirements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        StyleId = c.Guid(nullable: false),
                        StyleNo = c.String(),
                        LineNo = c.String(),
                        Remark = c.String(),
                        LocationCode = c.String(),
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
                    { "DynamicFilter_MachineRequirement_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_MachineRequirement_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Styles", t => t.StyleId, cascadeDelete: true)
                .Index(t => t.StyleId);
            
            CreateTable(
                "dbo.MachineTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        MachineTypeName = c.String(),
                        Category1 = c.String(),
                        Category2 = c.String(),
                        Remark = c.String(),
                        isProductionMachine = c.Boolean(nullable: false),
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
                    { "DynamicFilter_MachineType_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_MachineType_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RentMachines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(nullable: false),
                        RentManagementID = c.String(),
                        MachineType = c.String(),
                        MachineSerialNo = c.String(),
                        RentBarcode = c.String(),
                        FromDate = c.DateTime(),
                        ToDate = c.DateTime(),
                        Remark = c.String(),
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
                    { "DynamicFilter_RentMachine_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_RentMachine_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MachineRequirements", "StyleId", "dbo.Styles");
            DropForeignKey("dbo.MachineRequirementItems", "MachineRequirementId", "dbo.MachineRequirements");
            DropForeignKey("dbo.DividingPlanHeaders", "StyleId", "dbo.Styles");
            DropForeignKey("dbo.DividingPlanItems", "DividingPlanHeaderId", "dbo.DividingPlanHeaders");
            DropForeignKey("dbo.Promotions", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.PastEmployeements", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Awards", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.WorkCycleVideos", "OperationPoolId", "dbo.OperationPools");
            DropForeignKey("dbo.WorkCycleImages", "OperationPoolId", "dbo.OperationPools");
            DropForeignKey("dbo.ThreadDetails", "OperationPoolId", "dbo.OperationPools");
            DropForeignKey("dbo.NeedleDetails", "OperationPoolId", "dbo.OperationPools");
            DropForeignKey("dbo.FootDetails", "OperationPoolId", "dbo.OperationPools");
            DropForeignKey("dbo.FolderDetails", "OperationPoolId", "dbo.OperationPools");
            DropForeignKey("dbo.AttatchmentDetails", "OperationPoolId", "dbo.OperationPools");
            DropForeignKey("dbo.AssetTransferDetails", "AssetTransferHeaderId", "dbo.AssetTransferHeaders");
            DropForeignKey("dbo.AssetDisposalDetails", "AssetDisposalHeaderId", "dbo.AssetDisposalHeaders");
            DropIndex("dbo.MachineRequirements", new[] { "StyleId" });
            DropIndex("dbo.MachineRequirementItems", new[] { "MachineRequirementId" });
            DropIndex("dbo.DividingPlanItems", new[] { "DividingPlanHeaderId" });
            DropIndex("dbo.DividingPlanHeaders", new[] { "StyleId" });
            DropIndex("dbo.Promotions", new[] { "EmployeeId" });
            DropIndex("dbo.PastEmployeements", new[] { "EmployeeId" });
            DropIndex("dbo.Awards", new[] { "EmployeeId" });
            DropIndex("dbo.WorkCycleVideos", new[] { "OperationPoolId" });
            DropIndex("dbo.WorkCycleImages", new[] { "OperationPoolId" });
            DropIndex("dbo.ThreadDetails", new[] { "OperationPoolId" });
            DropIndex("dbo.NeedleDetails", new[] { "OperationPoolId" });
            DropIndex("dbo.FootDetails", new[] { "OperationPoolId" });
            DropIndex("dbo.FolderDetails", new[] { "OperationPoolId" });
            DropIndex("dbo.AttatchmentDetails", new[] { "OperationPoolId" });
            DropIndex("dbo.AssetTransferDetails", new[] { "AssetTransferHeaderId" });
            DropIndex("dbo.AssetDisposalDetails", new[] { "AssetDisposalHeaderId" });
            DropTable("dbo.RentMachines",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_RentMachine_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_RentMachine_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.MachineTypes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MachineType_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_MachineType_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.MachineRequirements",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MachineRequirement_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_MachineRequirement_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.MachineRequirementItems",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MachineRequirementItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_MachineRequirementItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DividingPlanItems",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DividingPlanItem_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DividingPlanItem_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.DividingPlanHeaders",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DividingPlanHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_DividingPlanHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Departments",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Department_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Department_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Promotions",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Promotion_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Promotion_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PastEmployeements",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PastEmployeement_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_PastEmployeement_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Employees",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Employee_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Employee_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Awards",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Award_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Award_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.WorkCycleVideos",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_WorkCycleVideo_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_WorkCycleVideo_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.WorkCycleImages",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_WorkCycleImage_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_WorkCycleImage_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ThreadDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ThreadDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ThreadDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.NeedleDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_NeedleDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_NeedleDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.FootDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FootDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_FootDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.FolderDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_FolderDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_FolderDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.OperationPools",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OperationPool_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_OperationPool_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AttatchmentDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AttatchmentDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AttatchmentDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AssetTransferHeaders",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AssetTransferHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetTransferHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AssetTransferDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AssetTransferDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetTransferDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AssetLedgers",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AssetLedger_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetLedger_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AssetDisposalHeaders",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AssetDisposalHeader_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetDisposalHeader_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AssetDisposalDetails",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_AssetDisposalDetail_MustHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_AssetDisposalDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
