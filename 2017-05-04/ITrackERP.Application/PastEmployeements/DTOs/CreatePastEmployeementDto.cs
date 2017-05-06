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
    public class CreatePastEmployeementDto : FullAuditedEntityDto<Guid>
    {
        public Guid EmployeeId { get; set; }

        public int TenantId { get; set; }
        public string CompanyName { get; set; }

        public string Designation { get; set; }

        public Nullable<DateTime> FromDate { get; set; }

        public Nullable<DateTime> ToDate { get; set; }

        public string Remark { get; set; }
    }
}
