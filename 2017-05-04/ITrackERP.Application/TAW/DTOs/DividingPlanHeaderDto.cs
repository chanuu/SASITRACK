using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.TAWs.DTOs
{
    [AutoMapFrom(typeof(DividingPlanHeader))]
    public class DividingPlanHeaderDto : FullAuditedEntityDto<Guid>
    {
        public string LineNo { get; set; }

        public int TotalEmployee { get; set; }

        public int Target { get; set; }

        public int ProductionPerHour { get; set; }

        public string Remark { get; set; }
      
        public Guid StyleId { get; set; }

        public ICollection<DividingPlanItemDto> DividingPlanItems { get; set; }
    }
}
