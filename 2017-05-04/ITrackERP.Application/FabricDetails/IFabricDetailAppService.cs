using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.FabricDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.FabricDetails
{
    public interface IFabricDetailAppService : IApplicationService
    {
        ListResultDto<FabricDetailListDto> GetFabricDetails(GetFabricDetailInput input);

        ListResultDto<FabricDetailListDto> GetFabricDetailsByID(EntityRequestInput<Guid> input);

        Task CreateDetail(CreateFabricDetailDto input);

        Task UpdateDetail(EditFabricDetailDto input);

        Task DeleteDetail(DeleteFabricDetailDto input);
    }
}
