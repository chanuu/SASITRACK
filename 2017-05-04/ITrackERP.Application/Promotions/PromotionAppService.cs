using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Employees;
using ITrackERP.Promotions.DTOs;
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

namespace ITrackERP.Promotions
{
    public class PromotionAppService : ITrackERPAppServiceBase, IPromotionAppService
    {
        private readonly IRepository<Employee, Guid> _employeeRepository;
        private readonly IRepository<Promotion, Guid> _promotionRepository;

        public PromotionAppService(IRepository<Employee, Guid> employeeRepository, IRepository<Promotion, Guid> promotionRepository)
        {
            _employeeRepository = employeeRepository;
            _promotionRepository = promotionRepository;
        }
     
        public PromotionDto GetPromotionByID(EntityRequestInput<Guid> input)
        {
            var @employee = _promotionRepository.GetAll()

                .Where(Y => Y.Id == input.Id)
                .ToList().FirstOrDefault(); ;

            return @employee.MapTo<PromotionDto>();

        }
        public async Task UpdatePromotion(EditPromotionDto input)
        {
            var @employee = input.MapTo<Promotion>();
            @employee.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _promotionRepository.UpdateAsync(@employee);
        }



        public async Task CreatePromotion(CreatePromotionDto input)
        {
            var header = _employeeRepository.Get(input.EmployeeId);

            var @employeepromotion = input.MapTo<Promotion>();

            @employeepromotion.TenantId = AbpSession.GetTenantId();

            @employeepromotion = Promotion.Create(input.FromDesignation, input.ToDesignation, input.PromotedDate.Value, input.JobDescription, input.Remark);

            header.Promotions.Add(@employeepromotion);

            await CurrentUnitOfWork.SaveChangesAsync();
        }



        public async Task DeletePromotion(DeletePromotionDto input)
        {
            var @promotion = input.MapTo<Promotion>();

            await _promotionRepository.DeleteAsync(@promotion.Id);
        }
    }
}
