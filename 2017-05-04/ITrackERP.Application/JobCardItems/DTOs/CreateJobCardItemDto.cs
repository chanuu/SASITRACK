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

    public class CreateJobCardItemDto : FullAuditedEntityDto<Guid>
    {
        public Guid JobCardHeaderId { get; set; }
        public string ItemCode { get; set; }
        public string SerialNo { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double SubTotal { get; set; }
    }
}
