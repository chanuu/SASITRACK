using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.JobCardHeaders.DTOs
{
    [AutoMap(typeof(Maintenance.JobCardHeader))]
    public class DeleteJobCardHeaderDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
