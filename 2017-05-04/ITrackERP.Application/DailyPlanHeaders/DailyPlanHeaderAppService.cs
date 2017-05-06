using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ITrackERP.Cutting;
using ITrackERP.DailyPlanHeaders.DTOs;
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

namespace ITrackERP.DailyPlanHeaders
{
    public class DailyPlanHeaderAppService : ITrackERPAppServiceBase, IDailyPlanHeaderAppService
    {
        private readonly IRepository<DailyPlanHeader, Guid> _dailyPlanHeaderRepository;

        public DailyPlanHeaderAppService(IRepository<DailyPlanHeader, Guid> dailyPlanHeaderRepository)
        {
            _dailyPlanHeaderRepository = dailyPlanHeaderRepository;
        }

        public ListResultOutput<DailyPlanHeaderListDto> GetAll() 
        {
            var dailyPlanHeaders = _dailyPlanHeaderRepository.GetAll().ToList();

            return new ListResultOutput<DailyPlanHeaderListDto>(dailyPlanHeaders.MapTo<List<DailyPlanHeaderListDto>>());
        }

        public DailyPlanHeaderDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @dailyPlanHeader = _dailyPlanHeaderRepository
                .GetAll()
                .Include(x => x.DailyPlanItems)
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@dailyPlanHeader == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @dailyPlanHeader.MapTo<DailyPlanHeaderDto>();
        }

        public async Task Create(CreateDailyPlanHeaderDto input)
        {
            var @dailyPlanHeader = input.MapTo<DailyPlanHeader>();
            @dailyPlanHeader = DailyPlanHeader.Create(AbpSession.GetTenantId(), input.Date.Value, input.PlanBy, input.Remark, input.Status, input.ApprovedBy);
            await _dailyPlanHeaderRepository.InsertAsync(@dailyPlanHeader);

        }

        public async Task Update(EditDailyPlanHeaderDto input)
        {
            var @dailyPlanHeader = input.MapTo<DailyPlanHeader>();
            @dailyPlanHeader.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _dailyPlanHeaderRepository.UpdateAsync(@dailyPlanHeader);
        }
        public async Task Delete(DeleteDailyPlanHeaderDto input)
        {
            var @dailyPlanHeader = input.MapTo<DailyPlanHeader>();

            await _dailyPlanHeaderRepository.DeleteAsync(@dailyPlanHeader.Id);
        }

    }
}
