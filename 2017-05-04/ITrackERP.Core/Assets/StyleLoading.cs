using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITRACK.Company;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Assets
{
    public class StyleLoading : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("StyleId")]

        public virtual Style Style { get; set; }

        public virtual Guid StyleId { get; set; }

        public virtual string StyleNo { get; set; }

        public virtual string LineNo { get; set; }

        public virtual Nullable<DateTime> FromDate { get; set; }

        public virtual Nullable<DateTime> ToDate { get; set; }       
        public virtual string Remark { get; set; }

        public static StyleLoading Create(string styleNo, string lineNo, DateTime fromDate, DateTime toDate, string remark)
        {
            var @styleloading = new StyleLoading
            {
                Id = Guid.NewGuid(),
                StyleNo = styleNo,
                LineNo = lineNo,
                FromDate = fromDate,
                ToDate = toDate,
                Remark = remark,
            };

            return @styleloading;
        }

    }
}
