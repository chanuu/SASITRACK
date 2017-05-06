using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CategorySetups.DTOs
{
    public class CategoryNameInputDto : FullAuditedEntityDto<Guid>
    {
        public string CategoryName { get; set; }
        public string LevelNo { get; set; }
    }
}
