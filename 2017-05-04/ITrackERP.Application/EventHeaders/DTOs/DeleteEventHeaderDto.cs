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
    public class DeleteEventHeaderDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
