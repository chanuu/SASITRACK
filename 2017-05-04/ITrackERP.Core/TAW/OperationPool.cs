using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.TAW
{
    public class OperationPool : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        public virtual string OperationCode { get; set; }

        public virtual string OperationName { get; set; }

        public virtual string MachineType { get; set; }

        public virtual double SMV { get; set; }

        public virtual string SMVType { get; set; }

        public virtual string Remark { get; set; }

        public virtual string PartName { get; set; }

        public virtual string OperationRole { get; set; }

        public virtual string OperationGrade { get; set; }

        public virtual string MachineSpeed { get; set; }

        public virtual string SeamLength { get; set; }

        public virtual string SeamAllowance { get; set; }

        public virtual string SPI { get; set; }

        public virtual ICollection<FolderDetail> FolderDetails { get; set; }

        public virtual ICollection<FootDetail> FootDetails { get; set; }

        public virtual ICollection<NeedleDetail> NeedleDetails { get; set; }
        public virtual ICollection<ThreadDetail> ThreadDetails { get; set; }

        public virtual ICollection<AttatchmentDetail> AttatchmentDetails { get; set; }

        public virtual ICollection<WorkCycleImage> WorkCycleImages { get; set; }
        public virtual ICollection<WorkCycleVideo> WorkCycleVideos { get; set; }


        public static OperationPool Create(int tenantId, string operationCode, string operationName, string machineType, double sMV,
         string sMVType, string remark, string partName, string operationRole, string operationGrade, string machineSpeed, string seamLength, string seamAllowance, string sPI)
        {
            var @operationpool = new OperationPool
            {
                Id = Guid.NewGuid(),
                OperationCode = operationCode,
                OperationName = operationName,
                MachineType = machineType,
                SMV = sMV,
                SMVType =sMVType,
                Remark = remark,
                PartName = partName,
                OperationRole = operationRole,
                OperationGrade = operationGrade,
                MachineSpeed = machineSpeed,
                SeamLength = seamLength,
                SeamAllowance = seamAllowance,
                SPI = sPI,

            };
            @operationpool.FolderDetails = new Collection<FolderDetail>();
            @operationpool.FootDetails = new Collection<FootDetail>();
            @operationpool.NeedleDetails = new Collection<NeedleDetail>();
            @operationpool.ThreadDetails = new Collection<ThreadDetail>();
            @operationpool.AttatchmentDetails = new Collection<AttatchmentDetail>();
            @operationpool.WorkCycleImages = new Collection<WorkCycleImage>();
            @operationpool.WorkCycleVideos = new Collection<WorkCycleVideo>();
            return @operationpool;
        }


    }
}
