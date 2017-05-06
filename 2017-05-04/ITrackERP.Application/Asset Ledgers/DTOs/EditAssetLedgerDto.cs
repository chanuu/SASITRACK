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
    [AutoMapFrom(typeof(AssetLedger))]
    public class EditAssetLedgerDto : FullAuditedEntityDto<Guid>
    {
        public string TransactionID { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string AssetID { get; set; }

        public string DocType { get; set; }

        public string DocNo { get; set; }

        public string AssetType { get; set; }

        public string UsedBy { get; set; }

        public string UsedByLocation { get; set; }
        public string Status { get; set; }
    }
}
