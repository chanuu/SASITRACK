using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Assets.Dto;
using Abp.Web.Models;

namespace ITrackERP.Assets
{
    public interface IAssetAppService : IApplicationService
    {
        ListResultOutput<AssetListDto> GetAsset();

        AssetDetailOutputDto GetDetail(EntityResultOutput<Guid> input);

        ListResultOutput<AssetListDto> GetAssetByAssetUsedBy(AssetUsedByInputDto input);

        [WrapResult(WrapOnSuccess = false, WrapOnError = false)]
        ListResultOutput<AssetListDto> GetAssetByLocation(AssetSearchInputDto input);

        AssetDetailOutputDto GetDetailByAssetNo(AssetNoInputDto input);
        Task Create(CreateAssetDto input);

        Task Update(EditAssetDto input);

        Task DeleteAsset(DeleteAssetDto input);


    }
}
