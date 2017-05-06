using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Departments.DTOs
{
    [AutoMap(typeof(Department))]
    public class CreateDepartmentDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string BarcodeNo { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public string Remark { get; set; }
    }
}
