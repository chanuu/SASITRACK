using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Promotions.DTOs
{
    [AutoMap(typeof(Promotion))]
    public class EditPromotionDto : FullAuditedEntityDto<Guid>
    {
        public Guid EmployeeId { get; set; }

        public int TenantId { get; set; }
        public string FromDesignation { get; set; }

        public string ToDesignation { get; set; }

        public Nullable<DateTime> PromotedDate { get; set; }

        public string JobDescription { get; set; }

        public string Remark { get; set; }

    }
}
