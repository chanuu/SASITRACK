using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CategorySetups.DTOs
{
    public class CategoryTypeInputDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string LevelNo { get; set; }
    }
}
