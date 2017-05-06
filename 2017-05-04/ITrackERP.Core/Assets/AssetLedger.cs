using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Assets
{
    public class AssetLedger : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public virtual string TransactionID { get; set; }
        public virtual Nullable<DateTime> Date { get; set; }
        public virtual string AssetID { get; set; }

        public virtual string DocType { get; set; }

        public virtual string DocNo { get; set; }

        public virtual string AssetType { get; set; }

        public virtual string UsedBy { get; set; }
        public virtual string UsedByLocation { get; set; }

        public virtual string Status { get; set; }

        public static AssetLedger Create(int tenantId, string transactionID, DateTime date, string assetID,
           string docType, string docNo, string assetType, string usedBy, string usedByLocation, string status)
        {
            var assetledger = new AssetLedger
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                TransactionID = transactionID,
                Date = date,
                AssetID = assetID,
                DocType = docType,
                DocNo = docNo,
                AssetType = assetType,
                UsedBy = usedBy,
                UsedByLocation = usedByLocation,
                Status = status
            };

            return @assetledger;
        }

    }
}
