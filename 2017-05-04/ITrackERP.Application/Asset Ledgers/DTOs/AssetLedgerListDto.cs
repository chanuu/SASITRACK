using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITrackERP.Assets;


namespace ITrackERP.Asset_Ledgers.DTOs
{
    [AutoMapFrom(typeof(AssetLedger))]
    public class AssetLedgerListDto : FullAuditedEntityDto<Guid>
    {
        public  string TransactionID { get; set; }
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
