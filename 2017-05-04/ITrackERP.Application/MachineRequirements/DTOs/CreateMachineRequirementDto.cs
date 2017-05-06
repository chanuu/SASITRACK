using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.MachineRequirements.DTOs
{
    [AutoMap(typeof(MachineRequirement))]
    public class CreateMachineRequirementDto : FullAuditedEntity<Guid>
    {
        public virtual Guid Id { get; set; }

        public virtual Guid StyleId { get; set; }

        public string StyleNo { get; set; }

        public string LineNo { get; set; }

        public string Remark { get; set; }

        public Nullable<DateTime> FromDate { get; set; }

        public Nullable<DateTime> ToDate { get; set; }

        public string LocationCode { get; set; }
    }
}
