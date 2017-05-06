using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.AssetVerificationDetails.DTOs
{
     [AutoMap(typeof(AssetVerificationDetail))]
    public class CreateAssetVerificationDetailDto : FullAuditedEntityDto<Guid>
    {
        public Guid AssetVerificationHeaderId { get; set; }
        public string BarcodeId { get; set; }
        public string AssetId { get; set; }
        public string UsedBy { get; set; }
        public string Condition { get; set; }
        public string Remark { get; set; }
    }
}
