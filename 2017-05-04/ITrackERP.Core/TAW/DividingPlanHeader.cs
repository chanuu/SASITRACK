using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITRACK.Company;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.TAW
{
    public class DividingPlanHeader : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("StyleId")]
        public virtual Style Style { get; set; }

        public virtual Guid StyleId { get; set; }

        public virtual string LineNo { get; set; }

        public virtual int TotalEmployee { get; set; }

        public virtual int Target { get; set; }

        public virtual int ProductionPerHour { get; set; }

        public virtual string Remark { get; set; }

        public virtual ICollection<DividingPlanItem> DividingPlanItems { get; set; }
        public virtual ICollection<LayoutHeader> LayoutHeaders { get; set; }

        public static DividingPlanHeader Create(int tenantId, string lineNo, int totalEmployee, int target, int productionPerHour, string remark, Guid styleId)
        {
            var @dividingplanheader = new DividingPlanHeader
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                LineNo = lineNo,
                TotalEmployee = totalEmployee,
                Remark = remark,
                Target = target,
                StyleId = styleId,
                ProductionPerHour = productionPerHour,
            };

            @dividingplanheader.DividingPlanItems = new Collection<DividingPlanItem>();
            return @dividingplanheader;



        }

    }
}
