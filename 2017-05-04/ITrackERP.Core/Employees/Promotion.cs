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
    public class Promotion : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public virtual Guid EmployeeId { get; set; }

        public virtual string FromDesignation { get; set; }

        public virtual string ToDesignation { get; set; }

        public virtual Nullable<DateTime> PromotedDate { get; set; }

        public virtual string JobDescription { get; set; }

        public virtual string Remark { get; set; }

        public static Promotion Create(string fromDesignation, string toDesignation, DateTime promotedDate, string jobDescription,string remark)
        {

            var @promotion = new Promotion
            {
                FromDesignation = fromDesignation,
                ToDesignation = toDesignation,
                PromotedDate = promotedDate,
                JobDescription = jobDescription,
                Remark = remark,
                Id = Guid.NewGuid()

            };

            return @promotion;
        }

    }
}
