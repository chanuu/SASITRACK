using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.WorkCycleVideos.DTOs
{
    [AutoMap(typeof(WorkCycleVideo))]
    public class CreateWorkCycleVideoDto : FullAuditedEntityDto<Guid>
    {
        public Guid OperationPoolId { get; set; }
        public string WorkCycleVideoPath { get; set; }
        public string Remark { get; set; }
    }
}
