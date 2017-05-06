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
    public class AssetDisposalHeader: FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public virtual string DisposalNoteNo { get; set; }
        public virtual string Type { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string DisposalBy { get; set; }
        public virtual string ApprovedBy { get; set; }
        public virtual string Remark { get; set; }
        public virtual string Status { get; set; }

        public virtual ICollection<AssetDisposalDetail> AssetDisposalDetails { get; set; }

        public static AssetDisposalHeader Create(int tenantId, string disposalNoteNo, DateTime date,
             string disposalBy, string approvedBy, string remark, string status)
        {
            var assetdisposal = new AssetDisposalHeader
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                DisposalNoteNo = disposalNoteNo,
                Date = date,
                Type = "DPN",
                DisposalBy = disposalBy,
                ApprovedBy = approvedBy,
                Remark = remark,
                Status = status

            };

            @assetdisposal.AssetDisposalDetails = new Collection<AssetDisposalDetail>();
            return @assetdisposal;

        }
    }
}

