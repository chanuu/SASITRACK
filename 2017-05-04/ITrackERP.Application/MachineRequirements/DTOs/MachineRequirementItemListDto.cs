using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.MachineRequirements.DTOs
{
    public class GetMachinerequirementItemInput
    {
        public Guid Id { get; set; }
    }

    [AutoMap(typeof(MachineRequirementItem))]
    public class MachineRequirementItemListDto : FullAuditedEntity<Guid>
    {
        public string MachineRequirementId { get; set; }

        public string MachineType { get; set; }

        public int Nos { get; set; }

        public string Remark { get; set; }
    }
}
