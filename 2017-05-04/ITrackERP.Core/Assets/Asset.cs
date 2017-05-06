using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using ITrackERP.Master;

namespace ITrackERP.Assets
{
    public class Asset : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("CustomeFiledSetupId")]
        public virtual CustomeFiledSetup CustomeFiledSetup { get; set; }
        public virtual Guid CustomeFiledSetupId { get; set; }

        public virtual string AssetNo { get; set; }

        public virtual string AssetName { get; set; }

        public virtual string Description { get; set; }

        public virtual string AlternetAsset { get; set; }

        public virtual string AssetStatus { get; set; }

        public virtual string WarrantyPeriod { get; set; }

        public virtual string PurchaseLocation { get; set; }

        public virtual string Location { get; set; }

        public virtual string AssetUsedBy { get; set; }

        public virtual string Category01 { get; set; }

        public virtual string Category02 { get; set; }

        public virtual string Category03 { get; set; }

        public virtual string Category04 { get; set; }

        public virtual string Category05 { get; set; }

        public virtual string CustomField1 { get; set; }

        public virtual string CustomField2 { get; set; }

        public virtual string CustomField3 { get; set; }

        public virtual string CustomField4 { get; set; }

        public virtual string CustomField5 { get; set; }

        public virtual string CustomField6 { get; set; }

        public virtual DateTime PurchaseDate { get; set; }

        public virtual string PurchasePrice { get; set; }

        public virtual string SupplierName { get; set; }

        public virtual string DepreciationMode { get; set; }

        public virtual string CurrentValue { get; set; }


        public static Asset Create(int tenantId, string assetNo, string assetName, string description,
           string alternetAsset, string assetStatus, string warrantyPeriod, string purchaseLocation,
           string location, string assetUsedBy, string category01, string category02, string category03,
           string category04, string category05, string customField1,
           string customField2, string customField3, string customField4, string customField5, string customField6,
           DateTime purchaseDate, string purchasePrice, string supplierName,
           string depreciationMode, string currentValue,Guid custuomfiledId)
        {
            var @asset = new Asset
            {
                Id = Guid.NewGuid(),
                AssetNo = assetNo,
                AssetName = assetName,
                Description = description,
                AlternetAsset = alternetAsset,
                AssetStatus = assetStatus,
                WarrantyPeriod = warrantyPeriod,
                PurchaseLocation = purchaseLocation,
                Location = location,
                AssetUsedBy = assetUsedBy,
                Category01 = category01,
                Category02 = category02,
                Category03 = category03,
                Category04 = category04,
                Category05 = category05,
                CustomField1 = customField1,
                CustomField2 = customField2,
                CustomField3 = customField3,
                CustomField4 = customField4,
                CustomField5 = customField5,
                CustomField6 = customField6,
                PurchaseDate = purchaseDate,
                PurchasePrice = purchasePrice,
                SupplierName = supplierName,
                DepreciationMode = depreciationMode,
                CurrentValue = currentValue,
                CustomeFiledSetupId = custuomfiledId


            };

            return @asset;
        }



    }
}
