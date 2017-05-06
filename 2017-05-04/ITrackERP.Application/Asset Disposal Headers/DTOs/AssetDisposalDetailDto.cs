using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Asset_Disposal_Headers.DTOs
{
    [AutoMapFrom(typeof(AssetDisposalDetail))]
    public class AssetDisposalDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid AssetDisposalHeaderId { get; set; }
        public  string AssetNo { get; set; }
        public  string Description { get; set; }
    
    }
}
