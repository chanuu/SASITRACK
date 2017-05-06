using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.TAW
{
    public class MachineType : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        public virtual string MachineTypeName { get; set; }

        public virtual string Category1 { get; set; }

        public virtual string Category2 { get; set; }

        public virtual string Remark { get; set; }

        public virtual bool isProductionMachine { get; set; }

        public static MachineType Create(int tenantId, string machineTypeName, string category1, string category2, string remark)
        {
            var @machinetype = new MachineType
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                MachineTypeName = machineTypeName,
                Category1 = category1,
                Category2 = category2,
                Remark = remark,
                isProductionMachine = false
            };


            return @machinetype;



        }

    }
}
