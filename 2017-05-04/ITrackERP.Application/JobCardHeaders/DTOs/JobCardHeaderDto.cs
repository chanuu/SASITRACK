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
    public class JobCardHeaderDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }
        public string JobcardNo { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string AssetNo { get; set; }
        public string Description { get; set; }
        public double TotalCost { get; set; }
        public string DoneBy { get; set; }
        public string CheckedBy { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }

    }
 }