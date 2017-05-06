using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Abp.Linq.Extensions;
using ITrackERP.Employees.DTOs;

namespace ITrackERP.Employees
{
    public class EmployeeAppService: ITrackERPAppServiceBase, IEmployeeAppService
   {
       private readonly IRepository<Employee, Guid> _employeeRepository;
       private readonly IRepository<Award, Guid> _awardRepository;
       private readonly IRepository<PastEmployeement, Guid> _pastEmployeementRepository;
       private readonly IRepository<Promotion, Guid> _promotionRepository;

       public EmployeeAppService(IRepository<Employee, Guid> employeeRepository,IRepository<Award, Guid> awardRepository, IRepository<PastEmployeement, Guid> pastEmployeementRepository, IRepository<Promotion, Guid> promotionRepository)
           
       {
           _employeeRepository = employeeRepository;
           _awardRepository = awardRepository;
           _pastEmployeementRepository = pastEmployeementRepository;
           _promotionRepository = promotionRepository;
       }


        public ListResultOutput<EmployeeListDto> GetEmployee()
        {
            var employee = _employeeRepository.GetAll();

            return new ListResultOutput<EmployeeListDto>(employee.MapTo<List<EmployeeListDto>>());
        }


        public EmployeeDto GetDetail(EntityRequestInput<Guid> input)
       {
           var @employee = _employeeRepository
               .GetAll()
               .Include(x => x.Awards)
               .Include(x => x.PastEmployeements)
               .Include(x => x.Promotions)

               .Where(e => e.Id == input.Id )
               .ToList().FirstOrDefault();

            if (@employee == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @employee.MapTo<EmployeeDto>();
        }

        public EmployeeDto GetDetailByFullName(EmployeeFullNameInputDto input)
        {
            var @employee = _employeeRepository
                .GetAll()
                .Include(x => x.Awards)
                .Include(x => x.PastEmployeements)
                .Include(x => x.Promotions)

                .Where(e => e.FullName == input.FullName)
                .ToList().FirstOrDefault();

            if (@employee == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @employee.MapTo<EmployeeDto>();
        }
     

        public async Task CreateEmployee(CreateEmployeeDto input)
       {
            var @employee = input.MapTo<Employee>();
           @employee = Employee.Create(AbpSession.GetTenantId(),input.FullName, input.NicNo, input.EPFNo, input.ETFNo, input.DateOfBirth.Value,input.Gender, input.MaritalStatus, input.Department, input.Designation, input.JobStatus, input.Address, input.MobileNo, input.LandNo, input.EmailAddress, input.EmergencyContactNo, input.EmergencyContactPerson, input.ImagePath);
            int i = 0;
            await _employeeRepository.InsertAsync(@employee);
        }

        public async Task UpdateEmployee(EditEmployeeDto input)
        {
            var @employee = input.MapTo<Employee>();
            @employee.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _employeeRepository.UpdateAsync(@employee);
        }

        public async Task DeleteEmployee(DeleteEmployeeDto input)
        {
            var @employee = input.MapTo<Employee>();
            await _employeeRepository.DeleteAsync(@employee.Id);
        }
       
      
    }
}
