using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITRACK.Company;
using System.Collections.ObjectModel;

namespace ITrackERP.Assets
{
    public class AssetTransferHeader : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public virtual string TransferNoteNo { get; set; }
        public virtual string RequisitionNo { get; set; }
        public virtual string Type { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string FromLocation { get; set; }
        public virtual string ToLocation { get; set; }
        public virtual string TransferBy { get; set; }
        public virtual string ApprovedBy { get; set; }
        public virtual string Remark { get; set; }
        public virtual string Status { get; set; }

        public virtual ICollection<AssetTransferDetail> AssetTransferDetails { get; set; }

        public static AssetTransferHeader Create(int tenantId, string transferNoteNo, string requisitionNo, string type, DateTime date, string fromLocation, string toLocation,
             string transferBy, string approvedBy, string remark, string status)
        {
            var assettransfer = new AssetTransferHeader
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                TransferNoteNo = transferNoteNo,
                RequisitionNo = requisitionNo,
                Type = type,
                Date = date,
                FromLocation = fromLocation,
                ToLocation = toLocation,
                TransferBy = transferBy,
                ApprovedBy = approvedBy,
                Remark = remark,
                Status = status

            };

            @assettransfer.AssetTransferDetails = new Collection<AssetTransferDetail>();
            return @assettransfer;

        }

    }
  
}
