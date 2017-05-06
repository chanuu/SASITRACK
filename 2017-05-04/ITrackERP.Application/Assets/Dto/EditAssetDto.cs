using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Assets.Dto
{
    [AutoMap(typeof(Asset))]
    public class EditAssetDto : FullAuditedEntityDto<Guid>
    {
        public Guid CustomeFiledSetupId { get; set; }
        public string AssetNo { get; set; }

        public string AssetName { get; set; }

        public string Description { get; set; }

        public string AlternetAsset { get; set; }

        public string AssetStatus { get; set; }

        public string WarrantyPeriod { get; set; }

        public string PurchaseLocation { get; set; }

        public string Location { get; set; }

        public string AssetUsedBy { get; set; }

        public string Category01 { get; set; }

        public string Category02 { get; set; }

        public string Category03 { get; set; }

        public string Category04 { get; set; }

        public string Category05 { get; set; }

        public string CustomField1 { get; set; }

        public string CustomField2 { get; set; }

        public string CustomField3 { get; set; }

        public string CustomField4 { get; set; }

        public string CustomField5 { get; set; }

        public string CustomField6 { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string PurchasePrice { get; set; }

        public string SupplierName { get; set; }

        public string DepreciationMode { get; set; }

        public string CurrentValue { get; set; }
    }
}
