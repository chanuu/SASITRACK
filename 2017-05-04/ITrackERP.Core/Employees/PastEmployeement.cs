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
    public class PastEmployeement : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public virtual Guid EmployeeId { get; set; }

        public virtual string CompanyName { get; set; }

        public virtual string Designation { get; set; }

        public virtual Nullable<DateTime> FromDate { get; set; }

        public virtual Nullable<DateTime> ToDate { get; set; }

        public virtual string Remark { get; set; }

        public static PastEmployeement Create(string companyName, string designation, DateTime fromDate, DateTime toDate, string remark)
        {

            var @pastemployeement = new PastEmployeement
            {
                CompanyName = companyName,
                Designation = designation,
                FromDate = fromDate,
                ToDate = toDate,
                Remark = remark,
                Id = Guid.NewGuid()

            };

            return @pastemployeement;
        }
    }
}
