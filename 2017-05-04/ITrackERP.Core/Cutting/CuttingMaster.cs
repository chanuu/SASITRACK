using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITRACK.Company;


namespace ITrackERP.Company
{
    public class CuttingMaster : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("StyleId")]
        public virtual Style Style { get; set; }

        public virtual Guid StyleId { get; set; }

        public virtual string StyleNo { get; set; }

        public virtual string CuttingMasterNo { get; set; }

        public virtual string ItemType { get; set; }


        public virtual bool isCuttingStarted { get; set; }

        public virtual Nullable<DateTime> CuttingStartedDate { get; set; }

        public virtual bool isCuttingFinised { get; set; }

        public virtual Nullable<DateTime> CuttingFinishedDate { get; set; }

        public virtual string  Remark { get; set; }

        public virtual string Status { get; set; }

        public virtual ICollection<CuttingItem> CuttingItems { get; set; }

        public static CuttingMaster Create(int tenantId, string cuttingMasterNo, string itemType, string remark, string status, Guid styleId,string styleNo)
        {
            var @cuttingmaster = new CuttingMaster
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                CuttingMasterNo = cuttingMasterNo,
                ItemType = itemType,
                Remark = remark,
                Status = status,
                StyleId = styleId,
                StyleNo = styleNo,
                isCuttingStarted = false,
                CuttingStartedDate = null,
                isCuttingFinised = false,
                CuttingFinishedDate = null
            };

            @cuttingmaster.CuttingItems = new Collection<CuttingItem>();
            return cuttingmaster;



        }

    }
}
