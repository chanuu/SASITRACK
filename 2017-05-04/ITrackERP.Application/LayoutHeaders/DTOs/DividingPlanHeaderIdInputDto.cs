using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.LayoutHeaders.DTOs
{
     [AutoMap(typeof(LayoutHeader))]
    public class DividingPlanHeaderIdInputDto : FullAuditedEntityDto<Guid>
    {
        public Guid DividingPlanHeaderId { get; set; }
    }
}