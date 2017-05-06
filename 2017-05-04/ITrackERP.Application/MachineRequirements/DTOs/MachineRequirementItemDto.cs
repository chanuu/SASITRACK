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
    public class MachineRequirementItemDto : FullAuditedEntityDto<Guid>
    {
     
        public string MachineType { get; set; }

        public int Nos { get; set; }

        public string Remark { get; set; }
    }
}
