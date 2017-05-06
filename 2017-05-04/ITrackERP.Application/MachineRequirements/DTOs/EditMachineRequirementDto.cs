using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.MachineRequirements.DTOs
{
    [AutoMap(typeof(MachineRequirement))]
    public class EditMachineRequirementDto : FullAuditedEntityDto<Guid>
    {
        public string StyleId { get; set; }

        public string StyleNo { get; set; }

        public string LineNo { get; set; }

        public string Remark { get; set; }

        public Nullable<DateTime> FromDate { get; set; }

        public Nullable<DateTime> ToDate { get; set; }

        public string LocationCode { get; set; }


    }
}
