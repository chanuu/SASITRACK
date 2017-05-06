using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using ITrackERP.Authorization.Roles;
using ITrackERP.MultiTenancy;
using ITrackERP.Users;
using ITRACK.Company;
using ITRACK.Costing;
using ITRACK.Cutting;
using ITrackERP.Buyer;
using ITrackERP.Company;
using ITrackERP.Master;
using ITrackERP.Assets;
using ITrackERP.Cutting;
using ITrackERP.Production;
using ITrackERP.TAW;
using ITrackERP.Employees;
using ITrackERP.Maintenance;

using ITrackERP.ComlianceAndSafety;
using ITrackERP.HR;

namespace ITrackERP.EntityFramework
{
    public class ITrackERPDbContext : AbpZeroDbContext<Tenant, Role, User>
    {

        public virtual IDbSet<Style> Styles { get; set; }

        public virtual IDbSet<WorkOrderHeader> WorkOrders { get; set; }

        public virtual IDbSet<WorkOrderRatio>WorkOrderRatios { get; set; }

        public virtual IDbSet<CuttingRatio> CuttingRatios { get; set; }

        public virtual IDbSet<CuttingRatioItem> CuttingRatioItems { get; set; }

        public virtual IDbSet<BuyerProfile> Buyers { get; set; }

        public virtual IDbSet<CuttingMaster> CuttingMasters { get; set; }

        public virtual IDbSet<CuttingItem> CuttingItems { get; set; }

        public virtual IDbSet<DailyPlanHeader> DailyPlanHeaders{ get; set; }

        public virtual IDbSet<DailyPlanItem> DailyPlanItems { get; set; }

        public virtual IDbSet<CutPlan> CutPlans { get; set; }

        public virtual IDbSet<EstimateConsumptione> EstimateConsumptions { get; set; }

        public virtual IDbSet<EmployeeMaster> EmployeeMasters { get; set; }

        public virtual IDbSet<ItemMaster> ItemMasters { get; set; }

        public virtual IDbSet<CustomeFiledSetup> CustomeFiledSetups { get; set; }
        public virtual IDbSet<AssetVerificationHeader> AssetVerificationHeaders { get; set; }

        public virtual IDbSet<AssetVerificationDetail> AssetVerificationDetails { get; set; }

        public virtual IDbSet<Asset> Assets { get; set; }

        public virtual IDbSet<FabricLedger> FabricLedgers { get; set; }

        public virtual IDbSet<DailyProductionSummary> DailyProductionSummarys { get; set; }

        public virtual IDbSet<IndividualProductionDetails> IndividualProductionDetails { get; set; }


        public virtual IDbSet<StockLedger> StockLedgers { get; set; }
    
        public virtual IDbSet<StockReceiveHeader> StockReceiveHeaders { get; set; }
        public virtual IDbSet<ReceiveNoteItem> ReceiveNoteItems { get; set; }

        public virtual IDbSet<SerialItem> SerialItems { get; set; }

        public virtual IDbSet<JobCardHeader> JobCardHeaders { get; set; }

        public virtual IDbSet<JobCardItem> JobCardItems { get; set; }


        public virtual IDbSet<RentMachine> RentMachines { get; set; }

        public virtual IDbSet<AssetLedger> AssetLedgers { get; set; }

        public virtual IDbSet<AssetTransferHeader> AssetTransferHeaders { get; set; }

        public virtual IDbSet<AssetTransferDetail> AssetTransferDetails { get; set; }

        public virtual IDbSet<AssetDisposalHeader> AssetDisposalHeaders { get; set; }

        public virtual IDbSet<AssetDisposalDetail> AssetDisposalDetails { get; set; }

        public virtual IDbSet<Award> Awards { get; set; }

        public virtual IDbSet<PastEmployeement> PastEmployeements { get; set; }

        public virtual IDbSet<Promotion> Promotions { get; set; }
        public virtual IDbSet<EventHeader> EventHeaders { get; set; }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Invitee> Invitees { get; set; }

        public virtual IDbSet<Employee> Employees { get; set; }

        public virtual IDbSet<Department> Departments { get; set; }

        public virtual IDbSet<DividingPlanHeader> DividingPlanHeaders { get; set; }

        public virtual IDbSet<DividingPlanItem> DividingPlanItems { get; set; }

        public virtual IDbSet<MachineRequirement> MachineRequirements { get; set; }

        public virtual IDbSet<MachineRequirementItem> MachineRequirementItems { get; set; }

        public virtual IDbSet<OperationPool> OperationPools { get; set; }
        public virtual IDbSet<Element> Elements { get; set; }

        public virtual IDbSet<MachineType> MachineTypes { get; set; }

        public virtual IDbSet<FolderDetail> FolderDetails { get; set; }

        public virtual IDbSet<FootDetail> FootDetails { get; set; }

        public virtual IDbSet<NeedleDetail> NeedleDetails { get; set; }

        public virtual IDbSet<ThreadDetail> ThreadDetails { get; set; }

        public virtual IDbSet<AttatchmentDetail> AttatchmentDetails { get; set; }
        public virtual IDbSet<WorkCycleImage> WorkCycleImages { get; set; }

        public virtual IDbSet<WorkCycleVideo> WorkCycleVideos { get; set; }
        

        public virtual IDbSet<LayoutHeader> LayoutHeaders { get; set; }
        public virtual IDbSet<LayoutItem> LayoutItems { get; set; }

        public virtual IDbSet<IssueNoteHeader> IssueNoteHeaders { get; set; }

        public virtual IDbSet<IssueNoteItem> IssueNoteItems { get; set; }

        public virtual IDbSet<CategorySetup> CategorySetups { get; set; }
        public virtual IDbSet<Files> Files { get; set; }





        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public ITrackERPDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ITrackERPDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ITrackERPDbContext since ABP automatically handles it.
         */
        public ITrackERPDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public ITrackERPDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
