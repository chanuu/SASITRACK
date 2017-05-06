using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.TAWs.DTOs
{
    [AutoMap(typeof(DividingPlanItem))]
    public class CreateDividingPlanItemDto: FullAuditedEntityDto<Guid>
    {
        public Guid DividingPlanHeaderId { get; set; }
        public string OperationNo { get; set; }

        public string OperationName { get; set; }

        public string SMVType { get; set; }

        public string MachineType { get; set; }

        public string OperationRole { get; set; }

        public string PartName { get; set; }

        public double SMV { get; set; }

        public int WorkstationNo { get; set; }

        public int OpNo { get; set; }
    }
}
