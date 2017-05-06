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
    public class MachineRequirementItem : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("MachineRequirementId")]
        public virtual MachineRequirement MachineRequirement { get; set; }

        public virtual Guid MachineRequirementId { get; set; }

        public virtual string MachineType { get; set; }

        public virtual int Nos { get; set; }

        public virtual string Remark { get; set; }

        public static MachineRequirementItem Create(string machineType, int nos, string remark)
        {

            var @machinerequirementitem = new MachineRequirementItem
            {
                MachineType = machineType,
                Nos = nos,
                Remark =remark,
                Id = Guid.NewGuid()

            };

            return @machinerequirementitem;
        }
    }
}
