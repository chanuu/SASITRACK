using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Cutting
{
    public class DailyPlanHeader : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public virtual Nullable<DateTime> Date { get; set; }

        public virtual string PlanBy { get; set; }

        public virtual string Remark { get; set; }

        public virtual string Status { get; set; }

        public virtual string ApprovedBy { get; set; }

        public virtual ICollection<DailyPlanItem> DailyPlanItems { get; set; }

        public static DailyPlanHeader Create(int tenantId, DateTime date, string planBy, string remark, string status, string approvedBy)
        {
            var @dailyPlanHeader = new DailyPlanHeader
            {
                Id = Guid.NewGuid(),
                Date = date,
                PlanBy = planBy,
                Remark = remark,
                Status = status,
                ApprovedBy = approvedBy,

            };
            @dailyPlanHeader.DailyPlanItems = new Collection<DailyPlanItem>();
            return @dailyPlanHeader;
        }
    }
}

