using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITRACK.Company;
using ITRACK.Costing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Orders.Dto
{
    [AutoMapFrom(typeof(WorkOrderHeader))]
  public  class WorkOrderHeaderDtailsDto : FullAuditedEntityDto<Guid>
    {
        public string WorkOrderNo { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public string Remark { get; set; }

        public string StyleNo { get; set; }

        public ICollection<WorkOrderRatioDto> WorkOrderRatios { get; set; }
    }
}
