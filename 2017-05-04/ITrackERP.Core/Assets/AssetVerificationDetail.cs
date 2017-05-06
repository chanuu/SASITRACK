using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Assets
{
    public class AssetVerificationDetail : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("AssetVerificationHeaderId")]

        public virtual AssetVerificationHeader AssetVerificationHeader { get; set; }
        public virtual Guid AssetVerificationHeaderId { get; set; }
        public virtual string BarcodeId { get; set; }
        public virtual string AssetId { get; set; }
        public virtual string UsedBy { get; set; }
        public virtual string Condition { get; set; }
        public virtual string Remark { get; set; }

        public static AssetVerificationDetail Create(string barcodeId, string assetId, string usedBy, string condition, string remark)
        {
            var assetVerificationDetail = new AssetVerificationDetail
            {
                Id = Guid.NewGuid(),
                BarcodeId = barcodeId,
                AssetId = assetId,
                UsedBy = usedBy,
                Condition = condition,
                Remark = remark,
            };

            return assetVerificationDetail;
        }
    }
}
