using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.MachineTypes.DTOs
{
    [AutoMapFrom(typeof(MachineType))]
    public class MachineTypeListDto : FullAuditedEntityDto<Guid>
    {
        public string MachineTypeName { get; set; }

        public string Category1 { get; set; }

        public string Category2 { get; set; }

        public string Remark { get; set; }

        public bool isProductionMachine { get; set; }
    }
}
