using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.LayoutItems.DTOs
{
    [AutoMap(typeof(LayoutItem))]
    public class DeleteLayoutItemDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}

