using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ITrackERP.CutPlan.Dto
{
    [AutoMapFrom(typeof(Company.CutPlan))]
    public class CutPlanDto : FullAuditedEntityDto<Guid>
    {
        public string CutPlanNo { get; set; }

        public DateTime Date { get; set; }

        public string FabricType { get; set; }

        public string Color { get; set; }

        public string NoOfplys { get; set; }

        public int Total { get; set; }

        public string LineNo { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public string TableNo { get; set; }

        public string TeamLeader { get; set; }

        public string Status { get; set; }


    }
}
