using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Employees.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Employees
{
    public interface IEmployeeAppService: IApplicationService
    {
        ListResultOutput<EmployeeListDto> GetEmployee();

        EmployeeDto GetDetail(EntityRequestInput<Guid> input);

        EmployeeDto GetDetailByFullName(EmployeeFullNameInputDto input);
        Task CreateEmployee(CreateEmployeeDto input);

        Task UpdateEmployee(EditEmployeeDto input);

        Task DeleteEmployee(DeleteEmployeeDto input);
    
    }
}
