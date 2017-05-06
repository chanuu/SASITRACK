using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Assets
{
    public class AssetVerificationHeader : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public virtual string AssetVerificationNo { get; set; }
        public virtual Nullable<DateTime> Date { get; set; }
        public virtual string LocationCode { get; set; }
        public virtual string ApprovedBy { get; set; }
        public virtual Nullable<DateTime> ApprovedAt { get; set; }

        public virtual ICollection<AssetVerificationDetail> AssetVerificationDetails { get; set; }

        public static AssetVerificationHeader Create(int tenantId, string assetVerificationNo, DateTime date, string locationCode, string approvedBy)
        {
            var assetVerificationHeader = new AssetVerificationHeader
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                AssetVerificationNo= assetVerificationNo,
                Date = date,
                LocationCode = locationCode,
                ApprovedBy = approvedBy,
              //  ApprovedAt = approvedAt,
            };

            assetVerificationHeader.AssetVerificationDetails = new Collection<AssetVerificationDetail>();
            return assetVerificationHeader;

        }

    }
}
