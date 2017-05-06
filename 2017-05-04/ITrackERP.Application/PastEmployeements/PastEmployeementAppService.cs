using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Employees;
using ITrackERP.PastEmployeements.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.UI;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Abp.Linq.Extensions;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Runtime.Session;

namespace ITrackERP.PastEmployeements
{
    public class PastEmployeementAppService : ITrackERPAppServiceBase, IPastEmployeementAppService
    {
        private readonly IRepository<Employee, Guid> _employeeRepository;
        private readonly IRepository<PastEmployeement, Guid> _pastEmployeementRepository;
        public PastEmployeementAppService(IRepository<Employee, Guid> employeeRepository, IRepository<PastEmployeement, Guid> pastEmployeementRepository)
        {
            _employeeRepository = employeeRepository;
            _pastEmployeementRepository = pastEmployeementRepository;
        }

       
        public PastEmployeementDto GetPastEmployeementByID(EntityRequestInput<Guid> input)
        {
            var @employee = _pastEmployeementRepository.GetAll()

                .Where(Y => Y.Id == input.Id)
                .ToList().FirstOrDefault(); ;

            return @employee.MapTo<PastEmployeementDto>();

        }

        public async Task CreatePastEmployeement(CreatePastEmployeementDto input)
        {
            var header = _employeeRepository.Get(input.EmployeeId);

            var @employeepastemployeement = input.MapTo<PastEmployeement>();

            @employeepastemployeement.TenantId = AbpSession.GetTenantId();

            @employeepastemployeement = PastEmployeement.Create(input.CompanyName, input.Designation, input.FromDate.Value, input.ToDate.Value, input.Remark);

            header.PastEmployeements.Add(@employeepastemployeement);

            await CurrentUnitOfWork.SaveChangesAsync();

        }
        public async Task UpdatePastEmployeement(EditPastEmployeementDto input)
        {
            var @employee = input.MapTo<PastEmployeement>();
            @employee.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _pastEmployeementRepository.UpdateAsync(@employee);
        }


        public async Task DeletePastEmployment(DeletePastEmploymentDto input)
        {
            var @pastemployment = input.MapTo<PastEmployeement>();

            await _pastEmployeementRepository.DeleteAsync(@pastemployment.Id);
        }

    }
}
