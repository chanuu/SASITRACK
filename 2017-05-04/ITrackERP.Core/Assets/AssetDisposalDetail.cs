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
    public class AssetDisposalDetail: FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("AssetDisposalHeaderId")]

        public virtual AssetDisposalHeader AssetDisposalHeader { get; set; }
        public virtual Guid AssetDisposalHeaderId { get; set; }
        public virtual string AssetNo { get; set; }
        public virtual string Description { get; set; }

        public static AssetDisposalDetail Create(string assetNo, string description)
        {
            var @assetdisposalItem = new AssetDisposalDetail
            {
                Id = Guid.NewGuid(),
                AssetNo = assetNo,
                Description = description,
            };

            return @assetdisposalItem;
        }
    }
}
