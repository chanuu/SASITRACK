using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Asset_Transfer_Headers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Asset_Transfer_Headers
{
    public interface IAssetTransferHeaderAppService : IApplicationService
    {
        ListResultOutput<AssetTransferHeaderListDto> GetAssetTransferHeader();

        AssetTransferHeaderDto GetDetail(EntityRequestInput<Guid> input);

        AssetTransferDetailDto GetAssetTransferDetailsByID(EntityRequestInput<Guid> input);

        
        Task CreateHeader(CreateAssetTransferHeaderDto input);

        Task UpdateHeader(EditAssetTransferHeaderDto input);

        Task DeleteHeader(DeleteAssetTransferHeaderDto input);

        Task UpdateDetail(EditAssetTransferDetailDto input);

        Task CreateDetail(CreateAssetTransferDetailDto input);

        Task DeleteDetail(DeleteAssetTransferDetailDto input);

    }
}
