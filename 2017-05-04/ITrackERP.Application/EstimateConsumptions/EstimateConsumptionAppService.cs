using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper.QueryableExtensions;
using ITrackERP.Company;

using Abp.Linq.Extensions;
using ITrackERP.EstimateConsumption.Dto;
using ITRACK.Cutting;

namespace ITrackERP.EstimateConsumption
{
    public class EstimateConsumptionAppService : ITrackERPAppServiceBase, IEstimateConsumptionAppService
    {
        private readonly IRepository<EstimateConsumptione, Guid> _estimateConsumptionRepository;

        public EstimateConsumptionAppService(IRepository<EstimateConsumptione, Guid> estimateconsumptionRepository)
        {
            _estimateConsumptionRepository = estimateconsumptionRepository;
        }

        public ListResultOutput<EstimateConsumptionDto> GetEstimateConsumption()
        {
            var estimateconsumptions = _estimateConsumptionRepository.GetAll().ToList();
            return new ListResultOutput<EstimateConsumptionDto>(estimateconsumptions.MapTo<List<EstimateConsumptionDto>>());
        }

        public EstimateConsumptionDetail GetDetail(EntityResultOutput<Guid> input)
        {
            var @estimateconsumption = _estimateConsumptionRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();
            if (@estimateconsumption == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @estimateconsumption.MapTo<EstimateConsumptionDetail>();

        }

        public async Task Create(CreateEstimateConsumptionDto input)
        {
            var @estimateconsumption = input.MapTo<EstimateConsumptione>();

            @estimateconsumption = EstimateConsumptione.Create(AbpSession.GetTenantId(), input.LayerNo,
                input.Date, input.NoOfPlys, input.ActualSinglePcsConsumption, input.ActualSinglePcsConsumption,
                input.TotalFabricPlan, input.TotalPcs, input.ActualFabric, input.Deference,input.StyleId);
            int i = 0;
            await _estimateConsumptionRepository.InsertAsync(@estimateconsumption);
        }

        public ListResultDto<EstimateConsumptionListDto> GetEstimateItems(GetEstimateConsumtionInput input)
        {
            var @items = _estimateConsumptionRepository.GetAll()
               .Include(x => x.Style)
               .WhereIf(true, Y => Y.Date >= input.From && Y.Date <= input.To)
               .OrderBy(x => x.CreationTime);




            return new ListResultDto<EstimateConsumptionListDto>(@items.ProjectTo<EstimateConsumptionListDto>().ToList());
        }
    }
}
