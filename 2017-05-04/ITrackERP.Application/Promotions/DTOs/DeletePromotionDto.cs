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
    public class DeletePromotionDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}

