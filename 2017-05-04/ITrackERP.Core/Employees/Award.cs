using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Employees
{
    public class Award : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public virtual Guid EmployeeId { get; set; }

        public virtual string AwardName { get; set; }

        public virtual Nullable<DateTime> AwardDate { get; set; }

        public virtual string Remark { get; set; }

        public static Award Create(string awardName, DateTime awardDate, string remark)
        {

            var @award = new Award
            {
                AwardName = awardName,
                AwardDate = awardDate,
                Remark = remark,
                Id = Guid.NewGuid()

            };

            return @award;
        }
    }
}
