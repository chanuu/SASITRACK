using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Cutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.DailyPlanItems.DTOs
{
    [AutoMap(typeof(DailyPlanItem))]
    public class CreateDailyPlanItemDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }
        public Guid DailyPlanHeaderId { get; set; }
        public string StyleNo { get; set; }

        public string PONo { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public string Length { get; set; }

        public int NoOfPlys { get; set; }

        public int NoOfItem { get; set; }
    }
}
