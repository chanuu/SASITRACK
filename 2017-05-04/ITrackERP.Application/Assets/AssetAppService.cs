using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using ITrackERP.Assets.Dto;

namespace ITrackERP.Assets
{
    public class AssetAppService : ITrackERPAppServiceBase, IAssetAppService
    {
        private readonly IRepository<Asset, Guid> _assetRepository;

        public AssetAppService(IRepository<Asset, Guid> assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public ListResultOutput<AssetListDto> GetAsset()
        {
            var assets = _assetRepository.GetAll().ToList();

            return new ListResultOutput<AssetListDto>(assets.MapTo<List<AssetListDto>>());
        }

        public AssetDetailOutputDto GetDetailByAssetNo(AssetNoInputDto input)
        {
            var @asset = _assetRepository
                .GetAll()
                .Where(e => e.AssetNo == input.AssetNo)
                .ToList().FirstOrDefault();

            return @asset.MapTo<AssetDetailOutputDto>();
        }

        public ListResultOutput<AssetListDto> GetAssetByAssetUsedBy(AssetUsedByInputDto input)
        {

            int tenantId = AbpSession.GetTenantId();

            var assets = _assetRepository.GetAll()
                 .Where(x => x.AssetUsedBy == input.AssetUsedBy && x.TenantId == tenantId)
                 .ToList();

            return new ListResultOutput<AssetListDto>(assets.MapTo<List<AssetListDto>>());
        }
        public ListResultOutput<AssetListDto> GetAssetByLocation(AssetSearchInputDto input)
        {
            var assets = _assetRepository.GetAll()
                .Where(x => x.Location == input.Location)
                .ToList();

            return new ListResultOutput<AssetListDto>(assets.MapTo<List<AssetListDto>>());
        }

        public AssetDetailOutputDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @asset = _assetRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@asset == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @asset.MapTo<AssetDetailOutputDto>();
        }

       
        public async Task Create(CreateAssetDto input)
        {
            var @asset = input.MapTo<Asset>();
            @asset = Asset.Create(AbpSession.GetTenantId(), input.AssetNo, input.AssetName, input.Description,
                input.AlternetAsset, input.AssetStatus, input.WarrantyPeriod, input.PurchaseLocation, input.Location,
                input.AssetUsedBy, input.Category01, input.Category02, input.Category03, input.Category04,
                input.Category05, input.CustomField1, input.CustomField2, input.CustomField3, input.CustomField4,
                input.CustomField5, input.CustomField6, input.PurchaseDate, input.PurchasePrice, input.SupplierName,
                input.DepreciationMode, input.CurrentValue,input.CustomeFiledSetupId);
            await _assetRepository.InsertAsync(@asset);
        }

        public async Task Update(EditAssetDto input)
        {
            var @asset = input.MapTo<Asset>();
            @asset.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _assetRepository.UpdateAsync(@asset);
        }
        public async Task DeleteAsset(DeleteAssetDto input)
        {
            var @asset = input.MapTo<Asset>();

            await _assetRepository.DeleteAsync(@asset.Id);
        }
    }
}
