using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.MachineRequirements.DTOs
{
    [AutoMap(typeof(MachineRequirementItem))]
    public class EditMachineRequirementItemDto : FullAuditedEntityDto<Guid>
    {
        public Guid MachineRequirementId { get; set; }

        public int TenantId { get; set; }

        public string MachineType { get; set; }

        public int Nos { get; set; }

        public string Remark { get; set; }
    }
}
