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
    public class MachineRequirement : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("StyleId")]
        public virtual Style Style { get; set; }

        public virtual Guid StyleId { get; set; }

        public virtual string StyleNo { get; set; }

        public virtual string LineNo { get; set; }

        public virtual string Remark { get; set; }

        public virtual string LocationCode { get; set; }

        public virtual Nullable<DateTime> FromDate { get; set; }

        public virtual Nullable<DateTime> ToDate { get; set; }

        public virtual ICollection<MachineRequirementItem> MachineRequirementItems { get; set; }


        public static MachineRequirement Create(int tenantId, string styleNo, string lineNo, string remark,Nullable<DateTime> _from,Nullable<DateTime> _to, string locationCode, Guid styleId)
        {
            var @machinerequirement = new MachineRequirement
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                StyleNo = styleNo,
                LineNo =lineNo,
                Remark = remark,
                LocationCode =locationCode,
                StyleId = styleId,
                FromDate = _from,
                ToDate=_to
            };

            @machinerequirement.MachineRequirementItems = new Collection<MachineRequirementItem>();
            return @machinerequirement;



        }
    }
}
