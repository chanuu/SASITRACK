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
    public class LayoutItemDto : FullAuditedEntityDto<Guid>
    {
        public Guid LayoutHeaderId { get; set; }
        public string Key { get; set; }
        public string Size { get; set; }
        public string Source { get; set; }
        public string Position { get; set; }
        public string Group { get; set; }
    }
}

