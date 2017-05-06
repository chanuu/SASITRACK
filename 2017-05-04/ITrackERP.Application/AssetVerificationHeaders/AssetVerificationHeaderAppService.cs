using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using ITrackERP.Assets;
using ITrackERP.AssetVerificationHeaders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using AutoMapper;


namespace ITrackERP.AssetVerificationHeaders
{
    public class AssetVerificationHeaderAppService : ITrackERPAppServiceBase, IAssetVerificationHeaderAppService
    {
        private readonly IRepository<AssetVerificationHeader, Guid> _assetVerificationHeaderRepository;

        public AssetVerificationHeaderAppService(IRepository<AssetVerificationHeader, Guid> assetVerificationHeaderRepository)
        {
            _assetVerificationHeaderRepository = assetVerificationHeaderRepository;
        }

        public ListResultOutput<AssetVerificationHeaderListDto> GetAll()
        {
            var assetVerificationHeaders = _assetVerificationHeaderRepository.GetAll().ToList();

            return new ListResultOutput<AssetVerificationHeaderListDto>(assetVerificationHeaders.MapTo<List<AssetVerificationHeaderListDto>>());
        }

        public AssetVerificationHeaderDto GetDetail(EntityResultOutput<Guid> input)
        {
            var assetVerificationHeader = _assetVerificationHeaderRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (assetVerificationHeader == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return assetVerificationHeader.MapTo<AssetVerificationHeaderDto>();
        }

        public string GetAssetVerificationNo()
        {
            var @assetverificationheadercount = _assetVerificationHeaderRepository
                .GetAll().Count();

            var @assetverificationno = "V0000001";

            if (@assetverificationheadercount != 0)
            {
                @assetverificationno = "V" + (@assetverificationheadercount + 1).ToString().PadLeft(7, '0');
            }
            else
            {
                @assetverificationno = "V0000001";
            }
            return @assetverificationno;
        }

        public async Task Create(CreateAssetVerificationHeaderDto input)
        {
            var assetVerificationHeader = input.MapTo< AssetVerificationHeader>();
            assetVerificationHeader = AssetVerificationHeader.Create(AbpSession.GetTenantId(), GetAssetVerificationNo(), input.Date.Value, input.LocationCode, input.ApprovedBy);
            await _assetVerificationHeaderRepository.InsertAsync(assetVerificationHeader);

        }
        public async Task Update(EditAssetVerificationHeaderDto input)
        {
            var assetVerificationHeader = input.MapTo<AssetVerificationHeader>();
            assetVerificationHeader.TenantId = AbpSession.GetTenantId();
            await _assetVerificationHeaderRepository.UpdateAsync(assetVerificationHeader);
        }
    }
}
