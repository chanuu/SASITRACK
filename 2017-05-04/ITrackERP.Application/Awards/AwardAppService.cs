using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Awards.DTOs;
using ITrackERP.Employees;
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

namespace ITrackERP.Awards
{
    public class AwardAppService : ITrackERPAppServiceBase, IAwardAppService
    {
       private readonly IRepository<Employee, Guid> _employeeRepository;
       private readonly IRepository<Award, Guid> _awardRepository;

       public AwardAppService(IRepository<Employee, Guid> employeeRepository,IRepository<Award, Guid> awardRepository)
           
       {
           _employeeRepository = employeeRepository;
           _awardRepository = awardRepository;
       }

          
       public AwardDto GetAwardByID(EntityRequestInput<Guid> input)
       {
           var @employee = _awardRepository.GetAll()

               .Where(Y => Y.Id == input.Id)
               .ToList().FirstOrDefault(); ;

           return @employee.MapTo<AwardDto>();

       }

       public async Task CreateAward(CreateAwardDto input)
       {
           var header = _employeeRepository.Get(input.EmployeeId);

           var @employeeaward = input.MapTo<Award>();

           @employeeaward.TenantId = AbpSession.GetTenantId();

           @employeeaward = Award.Create(input.AwardName, input.AwardDate.Value, input.Remark);

           header.Awards.Add(@employeeaward);

           await CurrentUnitOfWork.SaveChangesAsync();
       }

       public async Task UpdateAward(EditAwardDto input)
       {
           var @employee = input.MapTo<Award>();
           @employee.TenantId = AbpSession.GetTenantId();
           int i = 0;
           await _awardRepository.UpdateAsync(@employee);
       }

       public async Task DeleteAward(DeleteAwardDto input)
       {
           var @award = input.MapTo<Award>();

           await _awardRepository.DeleteAsync(@award.Id);
       }


    }
}
