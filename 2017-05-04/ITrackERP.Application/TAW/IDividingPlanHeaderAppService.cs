using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.TAW.DTOs;
using ITrackERP.TAWs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.TAWs
{
    public interface IDividingPlanHeaderAppService : IApplicationService
    {
        ListResultOutput<DividingPlanHeaderListDto> GetDividingPlanHeader();

        DividingPlanHeaderDto GetDetail(EntityRequestInput<Guid> input);

        DividingPlanItemDto GetDividingPlanHeaderItemByID(EntityRequestInput<Guid> input);

        Task CreateHeader(CreateDividingPlanHeaderDto input);

        Task UpdateHeader(EditDividingPlanHeaderDto input);

        Task DeleteHeader(DeleteDividingPlanHeaderDto input);

        Task UpdateItem(EditDividingPlanItemDto input);

        Task CreateItem(CreateDividingPlanItemDto input);

        Task DeleteItem(DeleteDividingPlanItemDto input);
    }
}
