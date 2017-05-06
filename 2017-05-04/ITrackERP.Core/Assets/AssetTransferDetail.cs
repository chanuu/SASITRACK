using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace ITrackERP.Assets
{
    public class AssetTransferDetail: FullAuditedEntity<Guid>, IMustHaveTenant
    {
         public virtual int TenantId { get; set; }

        [ForeignKey("AssetTransferHeaderId")]

        public virtual AssetTransferHeader AssetTransferHeader { get; set; }
        public virtual Guid AssetTransferHeaderId { get; set; }
        public virtual string AssetNo { get; set; }
        public virtual string Description { get; set; }


        public static AssetTransferDetail Create(string assetNo, string description)
        {
            var @assettransferItem = new AssetTransferDetail
            {
                Id = Guid.NewGuid(),
                AssetNo = assetNo,
                Description = description,
            };

            return @assettransferItem;
        }
       
    }
 
}
