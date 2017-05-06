using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.WorkCycleImages.DTOs
{

 [AutoMap(typeof(WorkCycleImage))]
    public class WorkCycleImageDto: FullAuditedEntityDto<Guid>
    {
        public string WorkCycleImagePath { get; set; }
        public string Remark { get; set; }
    }
}

 
   

