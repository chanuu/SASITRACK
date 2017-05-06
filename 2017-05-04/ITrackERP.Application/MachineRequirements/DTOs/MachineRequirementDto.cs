
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
    [AutoMapFrom(typeof(MachineRequirement))]
    public class MachineRequirementDto : FullAuditedEntityDto<Guid>
    {
        public virtual Guid StyleId { get; set; }

        public virtual string StyleNo { get; set; }

        public virtual string LineNo { get; set; }

        public virtual string Remark { get; set; }

        public virtual Nullable<DateTime> FromDate { get; set; }

        public virtual Nullable<DateTime> ToDate { get; set; }

        public virtual string LocationCode { get; set; }


        public ICollection<MachineRequirementItemDto> MachineRequirementItems { get; set; }
    }
}
