using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Asset_Transfer_Headers.DTOs;
using ITrackERP.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper.QueryableExtensions;
using Abp.Linq.Extensions;

namespace ITrackERP.Asset_Transfer_Headers
{
    public class AssetTransferHeaderAppService : ITrackERPAppServiceBase, IAssetTransferHeaderAppService
    {

        private readonly IRepository<AssetTransferHeader, Guid> _assetTransferHeaderRepository;

        private readonly IRepository<AssetTransferDetail, Guid> _assetTransferDetailRepository;

        public AssetTransferHeaderAppService(IRepository<AssetTransferHeader, Guid> assetTransferHeaderRepository, IRepository<AssetTransferDetail, Guid> assetTransferDetailRepository)
        {
            _assetTransferHeaderRepository = assetTransferHeaderRepository;
            _assetTransferDetailRepository = assetTransferDetailRepository;
        }

        public ListResultOutput<AssetTransferHeaderListDto> GetAssetTransferHeader()
        {
            var assettransferheader = _assetTransferHeaderRepository.GetAll();

            return new ListResultOutput<AssetTransferHeaderListDto>(assettransferheader.MapTo<List<AssetTransferHeaderListDto>>());
        }


        public AssetTransferDetailDto GetAssetTransferDetailsByID(EntityRequestInput<Guid> input)
        {
            var @assettransferdetail = _assetTransferDetailRepository.GetAll()

                .Where(Y => Y.Id == input.Id)
                .ToList().FirstOrDefault(); ;

            return @assettransferdetail.MapTo<AssetTransferDetailDto>();

        }

        public AssetTransferHeaderDto GetDetail(EntityRequestInput<Guid> input)
        {
            var @assettransferheader = _assetTransferHeaderRepository
                .GetAll()
                .Include(x => x.AssetTransferDetails)
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@assettransferheader == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @assettransferheader.MapTo<AssetTransferHeaderDto>();

        }

        public string GetTransferNoteNo()
        {
            var @assettransferheadercount = _assetTransferHeaderRepository
                .GetAll().Count();

            var @transfernoteno = "T" + (@assettransferheadercount + 1).ToString().PadLeft(7, '0');

            return @transfernoteno;
        }


        public async Task CreateHeader(CreateAssetTransferHeaderDto input)
        {
            var @assettransferheader = input.MapTo<AssetTransferHeader>();
            @assettransferheader = AssetTransferHeader.Create(AbpSession.GetTenantId(), GetTransferNoteNo(), input.RequisitionNo, input.Type, input.Date, input.FromLocation, input.ToLocation, input.TransferBy, "N/A", input.Remark, "Pending");           
            
            await _assetTransferHeaderRepository.InsertAsync(@assettransferheader);


        }

        public async Task UpdateHeader(EditAssetTransferHeaderDto input)
        {
            var @assettransferheader = input.MapTo<AssetTransferHeader>();
            @assettransferheader.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _assetTransferHeaderRepository.UpdateAsync(@assettransferheader);
        }
        
        public async Task DeleteHeader(DeleteAssetTransferHeaderDto input)
        {
            var @assettransferheader = input.MapTo<AssetTransferHeader>();
            await _assetTransferHeaderRepository.DeleteAsync(@assettransferheader.Id);
        }

        public async Task UpdateDetail(EditAssetTransferDetailDto input)
        {
            var @assettransferitem = input.MapTo<AssetTransferDetail>();
            @assettransferitem.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _assetTransferDetailRepository.UpdateAsync(@assettransferitem);
        }
        
        public async Task CreateDetail(CreateAssetTransferDetailDto input)
        {
            var _header = _assetTransferHeaderRepository.Get(input.AssetTransferHeaderId);

            var @assettransferdetail = input.MapTo<AssetTransferDetail>();

            @assettransferdetail.TenantId = AbpSession.GetTenantId();

            @assettransferdetail = AssetTransferDetail.Create(input.AssetNo, input.Description);

            _header.AssetTransferDetails.Add(@assettransferdetail);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteDetail(DeleteAssetTransferDetailDto input)
        {
            var @assettransferdetail = input.MapTo<AssetTransferDetail>();

            await _assetTransferDetailRepository.DeleteAsync(@assettransferdetail.Id);
        }
    }
}

