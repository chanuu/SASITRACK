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
    public class EditAwardDto : FullAuditedEntityDto<Guid>
      {
          public Guid EmployeeId { get; set; }

          public int TenantId { get; set; }
          public string AwardName { get; set; }

          public Nullable<DateTime> AwardDate { get; set; }

          public string Remark { get; set; }
      }
   
}

