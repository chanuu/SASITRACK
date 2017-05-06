using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using ITrackERP.EmployeeMaster.Dto;

namespace ITrackERP.EmployeeMaster
{
    public class EmployeeMasterAppService : ITrackERPAppServiceBase, IEmployeeMasterAppService
    {
        private readonly IRepository<Master.EmployeeMaster, Guid> _employeemasterRepository;

        public EmployeeMasterAppService(IRepository<Master.EmployeeMaster, Guid> employeemasterRepository)
        {
            _employeemasterRepository = employeemasterRepository;
        }

        public ListResultOutput<EmployeeListDto> GetEmployeeMaster()
        {
            var employeemasters = _employeemasterRepository.GetAll();

            return new ListResultOutput<EmployeeListDto>(employeemasters.MapTo<List<EmployeeListDto>>());
        }

        public EmployeeMasterDetailOutput GetDetail(EntityRequestInput<Guid> input)
        {
            var @employeemaster = _employeemasterRepository
                .GetAll()

                .Where(e => e.Id == input.Id)

                .ToList().FirstOrDefault();

            if (@employeemaster == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @employeemaster.MapTo<EmployeeMasterDetailOutput>();
        }

        public async Task Create(CreateEmployeeMasterInputDto input)
        {
            var @employeemaster = input.MapTo<Master.EmployeeMaster>();
            @employeemaster = Master.EmployeeMaster.Create(AbpSession.GetTenantId(), input.FullName, input.NicNo,
                input.EPFNo, input.ETFNo, input.DateOfBirth, input.Gender, input.MaritalStatus, input.Department,
                input.Designation, input.JobStatus, input.EmailAddress, input.MobileNo, input.LandNo, input.EmailAddress,
                input.EmergencyContactNo, input.EmergencyContactPerson);
            int i = 0;
            await _employeemasterRepository.InsertAsync(@employeemaster);
        }
    }

}