using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Assets;
using ITrackERP.AssetVerificationDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Abp.Linq.Extensions;

namespace ITrackERP.AssetVerificationDetails
{
    public class AssetVerificationDetailAppService : ITrackERPAppServiceBase, IAssetVerificationDetailAppService
    {
        private readonly IRepository<AssetVerificationDetail, Guid> _assetVerificationDetailRepository;
        private readonly IRepository<AssetVerificationHeader, Guid> _assetVerificationHeaderRepository;

        public AssetVerificationDetailAppService(IRepository<AssetVerificationDetail, Guid> assetVerificationDetailRepository, IRepository<AssetVerificationHeader, Guid> assetVerificationHeaderRepository)
        {
            _assetVerificationDetailRepository = assetVerificationDetailRepository;
            _assetVerificationHeaderRepository = assetVerificationHeaderRepository;
        }
       
        public async Task Create(CreateAssetVerificationDetailDto input)
        {
            var assetVerificationHeader = _assetVerificationHeaderRepository.Get(input.AssetVerificationHeaderId);

            var assetVerificationDetail = input.MapTo<AssetVerificationDetail>();
            assetVerificationDetail = AssetVerificationDetail.Create(input.BarcodeId, input.AssetId, input.UsedBy, input.Condition, input.Remark);

            assetVerificationHeader.AssetVerificationDetails.Add(assetVerificationDetail);

            await CurrentUnitOfWork.SaveChangesAsync();

        }
    }
}
