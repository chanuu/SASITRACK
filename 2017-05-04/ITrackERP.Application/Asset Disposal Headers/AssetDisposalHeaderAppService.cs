using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Asset_Disposal_Headers.DTOs;
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

namespace ITrackERP.Asset_Disposal_Headers
{
    public class AssetDisposalHeaderAppService : ITrackERPAppServiceBase, IAssetDisposalHeaderAppService
    {

        private readonly IRepository<AssetDisposalHeader, Guid> _assetDisposalHeaderRepository;

        private readonly IRepository<AssetDisposalDetail, Guid> _assetDisposalDetailRepository;

        public AssetDisposalHeaderAppService(IRepository<AssetDisposalHeader, Guid> assetDisposalHeaderRepository, IRepository<AssetDisposalDetail, Guid> assetDisposalDetailRepository)
        {
            _assetDisposalHeaderRepository = assetDisposalHeaderRepository;
            _assetDisposalDetailRepository = assetDisposalDetailRepository;
        }

        public ListResultOutput<AssetDisposalHeaderListDto> GetAssetDisposalHeader()
        {
            var assetdisposalheader = _assetDisposalHeaderRepository.GetAll();

            return new ListResultOutput<AssetDisposalHeaderListDto>(assetdisposalheader.MapTo<List<AssetDisposalHeaderListDto>>());
        }



        public AssetDisposalDetailDto GetAssetDisposalDetailsByID(EntityRequestInput<Guid> input)
        {
            var @assetdisposaldetail = _assetDisposalDetailRepository.GetAll()

                .Where(Y => Y.Id == input.Id)
                .ToList().FirstOrDefault();

            return @assetdisposaldetail.MapTo<AssetDisposalDetailDto>();

        }

        public AssetDisposalHeaderDto GetDetail(EntityRequestInput<Guid> input)
        {
            var @assetdisposalheader = _assetDisposalHeaderRepository
                .GetAll()
                .Include(x => x.AssetDisposalDetails)


                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@assetdisposalheader == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @assetdisposalheader.MapTo<AssetDisposalHeaderDto>();

        }

        public string GetDisposalNoteNo()
        {
            var @assetdisposalheadercount = _assetDisposalHeaderRepository
                .GetAll().Count();

            var @disposalnoteno = "D"+ (@assetdisposalheadercount + 1).ToString().PadLeft(7, '0');

            return @disposalnoteno;
        }
        public async Task CreateHeader(CreateAssetDisposalHeaderDto input)
        {
            var @assetdisposalheader = input.MapTo<AssetDisposalHeader>();
            @assetdisposalheader = AssetDisposalHeader.Create(AbpSession.GetTenantId(), GetDisposalNoteNo(), input.Date, input.DisposalBy, "N/A", input.Remark, "Pending");
            
            int i = 0;
            await _assetDisposalHeaderRepository.InsertAsync(@assetdisposalheader);
        }

        public async Task UpdateHeader(EditAssetDisposalHeaderDto input)
        {
            var @assetdisposalheader = input.MapTo<AssetDisposalHeader>();
            @assetdisposalheader.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _assetDisposalHeaderRepository.UpdateAsync(@assetdisposalheader);
        }

        public async Task DeleteHeader(DeleteAssetDisposalHeaderDto input)
        {
            var @assetdisposalheader = input.MapTo<AssetDisposalHeader>();
            await _assetDisposalHeaderRepository.DeleteAsync(@assetdisposalheader.Id);
        }
        public async Task UpdateDetail(EditAssetDisposalDetailDto input)
        {

            var @assetdisposalitem = input.MapTo<AssetDisposalDetail>();
            @assetdisposalitem.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _assetDisposalDetailRepository.UpdateAsync(@assetdisposalitem);
        }

        public async Task CreateDetail(CreateAssetDisposalDetailDto input)
        {
            var _header = _assetDisposalHeaderRepository.Get(input.AssetDisposalHeaderId);

            var @assetdisposaldetail = input.MapTo<AssetDisposalDetail>();

            @assetdisposaldetail.TenantId = AbpSession.GetTenantId();

            @assetdisposaldetail = AssetDisposalDetail.Create(input.AssetNo, input.Description);

            _header.AssetDisposalDetails.Add(@assetdisposaldetail);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteDetail(DeleteAssetDisposalDetailDto input)
        {
            var @assetdisposaldetail = input.MapTo<AssetDisposalDetail>();

            await _assetDisposalDetailRepository.DeleteAsync(@assetdisposaldetail.Id);
        }
    }
}
