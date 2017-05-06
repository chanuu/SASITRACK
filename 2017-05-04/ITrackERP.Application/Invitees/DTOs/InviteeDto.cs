using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Invitees.DTOs
{

    [AutoMap(typeof(Invitee))]
    public class InviteeDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }

        public Guid EventHeaderId { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

    }
}
