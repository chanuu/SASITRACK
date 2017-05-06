using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Departments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Departments
{
    public interface IDepartmentAppService : IApplicationService
    {
        ListResultOutput<DepartmentDto> GetDepartments();

        DepartmentDto GetDetail(EntityResultOutput<Guid> input);

        DepartmentDto GetDetailByLineNo(LineNoInputDto input);
        Task Create(CreateDepartmentDto input);

        Task Update(EditDepartmentDto input);

        Task Delete(DeleteDepartmentDto input);
    }
}
