using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Cutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.DailyPlanHeaders.DTOs
{
    [AutoMap(typeof(DailyPlanHeader))]
    public class EditDailyPlanHeaderDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }
        public Nullable<DateTime> Date { get; set; }

        public string PlanBy { get; set; }

        public string Remark { get; set; }

        public string Status { get; set; }

        public string ApprovedBy { get; set; }
    }
}

