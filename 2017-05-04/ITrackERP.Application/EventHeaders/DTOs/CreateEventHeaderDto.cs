using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.EventHeaders.DTOs
{
      [AutoMap(typeof(EventHeader))]
    public class CreateEventHeaderDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Type { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string Frequency { get; set; }
        public Nullable<DateTime> ExpectedDate { get; set; }
         
        public string Department { get; set; }

        public string Venue { get; set; }

    }
}
