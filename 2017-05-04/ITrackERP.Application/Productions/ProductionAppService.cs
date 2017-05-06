using Abp.Domain.Repositories;
using ITrackERP.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using ITrackERP.Productions.DTOs;
using Abp.Collections.Extensions;
using Abp.AutoMapper;

namespace ITrackERP.Productions
{
  public  class ProductionAppService: ITrackERPAppServiceBase, IProductionAppService
    {
        private readonly IRepository<DailyProductionSummary, Guid> _productionRepository;
        

        public ProductionAppService(IRepository<DailyProductionSummary, Guid> productionRepository)

        {
            _productionRepository = productionRepository;
           
        }

        public ListResultDto<ProductionSummaryDto> GetProductionSummary(ProductionFilter input)
        {
           

            var @list = _productionRepository.GetAll()
                  .WhereIf(true, x => x.Date.Year == input.Date.Year && x.Date.Month==input.Date.Month && x.Date.Day == input.Date.Day )

                   .ToList();

            return new ListResultOutput<ProductionSummaryDto>(@list.MapTo<List<ProductionSummaryDto>>());



        }
    }
}
