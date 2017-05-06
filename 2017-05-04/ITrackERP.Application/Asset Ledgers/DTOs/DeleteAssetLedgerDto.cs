using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Asset_Ledgers.DTOs
{
    [AutoMap(typeof(AssetLedger))]
    public class DeleteAssetLedgerDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
