using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Awards.DTOs
{
    [AutoMap(typeof(Award))]
    public class DeleteAwardDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
