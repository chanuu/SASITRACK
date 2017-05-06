using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Asset_Transfer_Headers.DTOs
{
     [AutoMap(typeof(AssetTransferDetail))]
  public  class CreateAssetTransferDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid AssetTransferHeaderId { get; set; }
        public string AssetNo { get; set; }
        public string Description { get; set; }
    }
}
