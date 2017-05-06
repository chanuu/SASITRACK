using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.JobCardItems.DTOs
{
     [AutoMap(typeof(JobCardItem))]
    public class DeleteJobCardItemDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}

