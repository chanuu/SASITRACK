using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Assets;
using ITrackERP.Asset_Ledgers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using Abp.UI;

namespace ITrackERP.Asset_Ledgers
{
    public class AssetLedgerAppService : ITrackERPAppServiceBase, IAssetLedgerAppService
    {
        private readonly IRepository<AssetLedger, Guid> _assetLedgerRepository;
        public AssetLedgerAppService(IRepository<AssetLedger, Guid> assetLedgerRepository)
        {
            _assetLedgerRepository = assetLedgerRepository;
        }

        public ListResultOutput<AssetLedgerListDto> GetAssetLedgers() 
        {
            var assetledgers = _assetLedgerRepository.GetAll().ToList();

            return new ListResultOutput<AssetLedgerListDto>(assetledgers.MapTo<List<AssetLedgerListDto>>());
        }

       

        public AssetLedgerDetailOutputDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @assetledger = _assetLedgerRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@assetledger == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @assetledger.MapTo<AssetLedgerDetailOutputDto>();
        }


        public string GetTransactionID()
        {
            var @ledgercount = _assetLedgerRepository
                .GetAll().Count();

            var @transactionId = (@ledgercount + 1).ToString().PadLeft(7, '0');

            return @transactionId;
        }


        public async Task Create(CreateAssetLedgerDto input)
        {
            var @assetledger = input.MapTo<AssetLedger>();
            @assetledger = AssetLedger.Create(AbpSession.GetTenantId(), GetTransactionID(), input.Date.Value, input.AssetID,
                input.DocType, input.DocNo, input.AssetType, input.UsedBy, input.UsedByLocation, input.Status);
            await _assetLedgerRepository.InsertAsync(@assetledger);

        }

        public async Task Update(EditAssetLedgerDto input)
        {
            var @assetledger = input.MapTo<AssetLedger>();
            @assetledger.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _assetLedgerRepository.UpdateAsync(@assetledger);
        }

        public async Task UpdateAssetLedgerByDocNo(DocNoDto input)
        {         
            var @assetledgers = _assetLedgerRepository.GetAll().ToList().Where(e => e.DocNo == input.DocNo);

            foreach (var item in @assetledgers)
            {
                item.Status = "Approved";
                item.TenantId = AbpSession.GetTenantId();
                await _assetLedgerRepository.UpdateAsync(item);
            }          
        }
        public async Task DeleteAssetLedger(DeleteAssetLedgerDto input)
        {
            var @assetledger = input.MapTo<AssetLedger>();

            await _assetLedgerRepository.DeleteAsync(@assetledger.Id);
        }
    }
}
