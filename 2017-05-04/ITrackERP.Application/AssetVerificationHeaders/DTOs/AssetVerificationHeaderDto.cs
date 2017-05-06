using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Assets;
using ITrackERP.AssetVerificationDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.AssetVerificationHeaders.DTOs
{
      [AutoMap(typeof(AssetVerificationHeader))]
    public class AssetVerificationHeaderDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }
        public string AssetVerificationNo { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string LocationCode { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<DateTime> ApprovedAt { get; set; }
        public ICollection<AssetVerificationDetailDto> AssetVerificationDetails { get; set; }
    }
}
