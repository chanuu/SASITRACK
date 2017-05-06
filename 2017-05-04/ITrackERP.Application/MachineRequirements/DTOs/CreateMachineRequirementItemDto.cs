using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.MachineRequirements.DTOs
{
     [AutoMap(typeof(MachineRequirementItem))]
    public class CreateMachineRequirementItemDto : FullAuditedEntityDto<Guid>
    {
        public Guid MachineRequirementId { get; set; }

        public string MachineType { get; set; }
         
         [Required]
        public int Nos { get; set; }

         [MaxLength(100)]
        public string Remark { get; set; }
    }
}
