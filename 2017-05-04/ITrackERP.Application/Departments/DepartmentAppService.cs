using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Departments.DTOs;
using ITrackERP.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using Abp.UI;

namespace ITrackERP.Departments
{
    public class DepartmentAppService : ITrackERPAppServiceBase, IDepartmentAppService
    {
        private readonly IRepository<Department, Guid> _departmentRepository;

        public DepartmentAppService(IRepository<Department, Guid> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public ListResultOutput<DepartmentDto> GetDepartments() 
        {
            var departments = _departmentRepository.GetAll()
                .OrderBy(x=>x.Remark)
                .ToList();

             

            return new ListResultOutput<DepartmentDto>(departments.MapTo<List<DepartmentDto>>());
        }

        public DepartmentDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @department = _departmentRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@department == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @department.MapTo<DepartmentDto>();
        }

    
        public DepartmentDto GetDetailByLineNo(LineNoInputDto input)
        {
            var @department = _departmentRepository
                 .GetAll()
                 .Where(e => e.Name == input.Name)
                 .ToList().FirstOrDefault();

            return @department.MapTo<DepartmentDto>();
        }

        public async Task Create(CreateDepartmentDto input)
        {
            var @department = input.MapTo<Department>();
            @department = Department.Create(AbpSession.GetTenantId(), input.Name, input.BarcodeNo, input.Length, input.Width, input.Remark);
            await _departmentRepository.InsertAsync(@department);

        }

        public async Task Update(EditDepartmentDto input)
        {
            var @department = input.MapTo<Department>();
            @department.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _departmentRepository.UpdateAsync(@department);
        }
        public async Task Delete(DeleteDepartmentDto input)
        {
            var @department = input.MapTo<Department>();

            await _departmentRepository.DeleteAsync(@department.Id);
        }

    }
}
