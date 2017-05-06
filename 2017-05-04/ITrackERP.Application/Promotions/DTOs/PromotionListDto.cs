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
    public class GetPromotionInput
    {
        public Guid Id { get; set; }
    }

    [AutoMap(typeof(Promotion))]
    public class PromotionListDto : FullAuditedEntityDto<Guid>
    {
        public Guid EmployeeId { get; set; }

        public virtual string FromDesignation { get; set; }

        public virtual string ToDesignation { get; set; }

        public virtual Nullable<DateTime> PromotedDate { get; set; }

        public virtual string JobDescription { get; set; }

        public virtual string Remark { get; set; }
    }
}
