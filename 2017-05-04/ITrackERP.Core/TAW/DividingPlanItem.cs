using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.TAW
{
    public class DividingPlanItem : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("DividingPlanHeaderId")]
        public virtual DividingPlanHeader DividingPlanHeader { get; set; }

        public virtual Guid DividingPlanHeaderId { get; set; }

        public virtual string OperationNo { get; set; }

        public virtual string OperationName { get; set; }

        public virtual string SMVType { get; set; }

        public virtual string MachineType { get; set; }

        public virtual string OperationRole { get; set; }

        public virtual string PartName { get; set; }

        public virtual double SMV { get; set; }

        public virtual int WorkstationNo { get; set; }

        public virtual int OpNo { get; set; }


        public static DividingPlanItem Create(string operationNo, string operationName, string sMVType, string machineType, string operationRole, string partName, double sMV, int workstationNo, int opNo)
        {

            var @dividingplanitem = new DividingPlanItem
            {
                OperationNo = operationNo,
                OperationName = operationName,
                SMVType = sMVType,
                MachineType = machineType,
                OperationRole = operationRole,
                PartName = partName,
                SMV = sMV,
                WorkstationNo = workstationNo,
                OpNo = opNo,
                Id = Guid.NewGuid()

            };

            return @dividingplanitem;
        }
    }
}
