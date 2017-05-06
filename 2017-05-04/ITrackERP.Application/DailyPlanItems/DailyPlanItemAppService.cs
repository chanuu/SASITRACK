using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ITrackERP.Cutting;
using ITrackERP.DailyPlanItems.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using AutoMapper.QueryableExtensions;
using Abp.Linq.Extensions;

namespace ITrackERP.DailyPlanItems
{
    public class DailyPlanItemAppService : ITrackERPAppServiceBase, IDailyPlanItemAppService
    {
        private readonly IRepository<DailyPlanItem, Guid> _dailyPlanItemRepository;
        private readonly IRepository<DailyPlanHeader, Guid> _dailyPlanHeaderRepository;

        public DailyPlanItemAppService(IRepository<DailyPlanItem, Guid> dailyPlanItemRepository, IRepository<DailyPlanHeader, Guid> dailyPlanHeaderRepository)
        {
            _dailyPlanItemRepository = dailyPlanItemRepository;
            _dailyPlanHeaderRepository = dailyPlanHeaderRepository;
        }

        public ListResultOutput<DailyPlanItemListDto> GetAll() 
        {
            var documents = _dailyPlanItemRepository.GetAll().ToList();

            return new ListResultOutput<DailyPlanItemListDto>(documents.MapTo<List<DailyPlanItemListDto>>());
        }

        public DailyPlanItemDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @dailyPlanItem = _dailyPlanItemRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@dailyPlanItem == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @dailyPlanItem.MapTo<DailyPlanItemDto>();
        }

        public async Task Create(CreateDailyPlanItemDto input)
        {
            var @DailyPlanHeader = _dailyPlanHeaderRepository.Get(input.DailyPlanHeaderId);

            var @dailyPlanItem = input.MapTo<DailyPlanItem>();
            @dailyPlanItem = DailyPlanItem.Create(AbpSession.GetTenantId(), input.StyleNo, input.PONo, input.Color, input.Size, input.Length, input.NoOfPlys, input.NoOfItem);

            @DailyPlanHeader.DailyPlanItems.Add(@dailyPlanItem);

            await CurrentUnitOfWork.SaveChangesAsync();

        }

        public async Task Update(EditDailyPlanItemDto input)
        {
            var @dailyPlanItem = input.MapTo<DailyPlanItem>();
            @dailyPlanItem.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _dailyPlanItemRepository.UpdateAsync(@dailyPlanItem);
        }
        public async Task Delete(DeleteDailyPlanItemDto input)
        {
            var @dailyPlanItem = input.MapTo<DailyPlanItem>();

            await _dailyPlanItemRepository.DeleteAsync(@dailyPlanItem.Id);
        }

    }
}
