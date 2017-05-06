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
    public class DeleteAssetTransferDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
