using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

using ITrackERP.CuttingMasters.Dto;
using ITrackERP.CuttingRatios.Dto;
using ITrackERP.IssueNoteItems.DTOs;

namespace ITrackERP.CuttingMasters
{
    public interface ICuttingMasterAppService : IApplicationService
    {
        ListResultDto<CuttingMasterDto> GetCuttingMaster();

        ListResultDto<CuttingMasterDto> GetActiveCuttingMaster();

        Task DeleteItem(createCuttingItemDto input);

        ListResultDto<CuttingItemListDto> GetCuttingItems(GetCuttingItemInput input);

        cuttingItemDetailsDto GetItemDetail(EntityRequestInput<Guid> input);

        ListResultDto<CuttingItemListDto> GetCuttingItemsGroupByStyle(GetCuttingItemInput input);

        ListResultDto<CuttingSummaryDto> GetCuttingSummary(GetCuttingItemInput input);

        Task UpdateItem(createCuttingItemDto input);

        CuttingMasterDto GetDetail(EntityRequestInput<Guid> input);

       
        ListResultDto<CuttingItemListDto> GetCuttingItemByID(EntityRequestInput<Guid> input);

        Task Create(CreateCuttingMasterDto input);

        Task Update(EditCuttingMasterDto input);

        Task Finalized(EntityRequestInput<Guid> input);

        Task Update(EditCuttingItemDto input);

        Task CreateItem(CreateCuttingItemDto input);
    }
}
