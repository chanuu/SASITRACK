using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.CuttingRatios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CuttingRatios
{
   public interface ICuttingRatioAppService: IApplicationService
    {
        ListResultDto<CuttingRatioListDto> GetCuttingRatio();

        ListResultDto<CuttingRatioListDto> GetCuttingRatioByStyle(EntityRequestInput<Guid> input);

        CuttingRatioDetailsDto GetDetail(EntityRequestInput<Guid> input);

        Task Create(CreateCuttingRatioInputDto input);

        Task CreateItem(CreateCuttingRatioItemDto input);

    }
}
