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
    public class GetAwardInput
    {
        public Guid Id { get; set; }
    }

    [AutoMap(typeof(Award))]
    public class AwardListDto : FullAuditedEntityDto<Guid>
    {
        public Guid EmployeeId { get; set; }

        public string AwardName { get; set; }

        public Nullable<DateTime> AwardDate { get; set; }

        public string Remark { get; set; }
    }
}
