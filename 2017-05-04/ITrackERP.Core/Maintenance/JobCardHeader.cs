using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Maintenance
{
    public class JobCardHeader : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public virtual string JobcardNo { get; set; }
        public virtual Nullable<DateTime> Date { get; set; }
        public virtual string AssetNo { get; set; }
        public virtual string Description { get; set; }
        public virtual double TotalCost { get; set; }
        public virtual string DoneBy { get; set; }
        public virtual string CheckedBy { get; set; }
        public virtual string Status { get; set; }
        public virtual string Remark { get; set; }

        public virtual ICollection<JobCardItem> JobCardItems { get; set; }

        public static JobCardHeader Create(int tenantId, string jobcardNo, DateTime date, string assetNo, string description, double totalCost, string doneBy, string checkedBy, string status, string remark)
        {
            var @jobCardHeader = new JobCardHeader
            {
                Id = Guid.NewGuid(),
                JobcardNo = jobcardNo,
                Date = date,
                AssetNo = assetNo,
                Description = description,
                TotalCost = totalCost,
                DoneBy = doneBy,
                CheckedBy = checkedBy,
                Status = status,
                Remark = remark,

            };
            @jobCardHeader.JobCardItems = new Collection<JobCardItem>();
            return @jobCardHeader;
        }
    }
}
