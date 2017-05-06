using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.EstimateConsumption.Dto;

namespace ITrackERP.EstimateConsumption
{
   public interface IEstimateConsumptionAppService : IApplicationService
   {
       ListResultOutput<EstimateConsumptionDto> GetEstimateConsumption();

       EstimateConsumptionDetail GetDetail(EntityResultOutput<Guid> input);

       Task Create(CreateEstimateConsumptionDto input);

        ListResultDto<EstimateConsumptionListDto> GetEstimateItems(GetEstimateConsumtionInput input);
    }
}
