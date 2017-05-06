using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Elements.DTOs
{
     [AutoMapFrom(typeof(Element))]
    public class CategoryInputDto : FullAuditedEntityDto<Guid>
    {
        public string Category { get; set; }
    }
}
