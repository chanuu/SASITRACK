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
     [AutoMap(typeof(Element))]
    public class EditElementDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public string Category { get; set; }
        public string Path { get; set; }

    }
 }