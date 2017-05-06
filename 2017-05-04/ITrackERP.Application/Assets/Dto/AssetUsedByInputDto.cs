using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Assets.Dto
{
     [AutoMapFrom(typeof(Asset))]
    public class AssetUsedByInputDto : FullAuditedEntityDto<Guid>
    {
         public string AssetUsedBy { get; set; }
    }
}
