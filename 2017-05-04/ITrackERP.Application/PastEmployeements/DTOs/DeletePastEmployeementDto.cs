using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.PastEmployeements.DTOs
{

    [AutoMap(typeof(PastEmployeement))]
    public class DeletePastEmploymentDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
