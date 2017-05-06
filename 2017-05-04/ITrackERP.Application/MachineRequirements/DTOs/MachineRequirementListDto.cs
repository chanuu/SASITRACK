using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.MachineRequirements.DTOs
{
    [AutoMap(typeof(MachineRequirement))]
    public class MachineRequirementListDto: FullAuditedEntity<Guid>
    {
        public virtual Guid StyleId { get; set; }

        public string StyleNo { get; set; }

        public string LineNo { get; set; }

        public string Remark { get; set; }

        public virtual Nullable<DateTime> FromDate { get; set; }

        public virtual Nullable<DateTime> ToDate { get; set; }

        public string LocationCode { get; set; }
    
    }
}
