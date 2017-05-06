using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Employees.DTOs
{
     [AutoMap(typeof(Employee))]
    public class EmployeeFullNameInputDto : FullAuditedEntityDto<Guid>
    {
        public string FullName { get; set; }
    }
}
