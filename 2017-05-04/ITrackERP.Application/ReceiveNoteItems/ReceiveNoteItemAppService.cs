using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Maintenance;
using ITrackERP.ReceiveNoteItems.DTOs;
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

namespace ITrackERP.ReceiveNoteItems
{
    public class ReceiveNoteItemAppService : ITrackERPAppServiceBase, IReceiveNoteItemAppService
    {
       
        private readonly IRepository<StockReceiveHeader, Guid> _stockReceiveHeaderRepository;

        private readonly IRepository<ReceiveNoteItem, Guid> _receiveNoteItemRepository;

        public ReceiveNoteItemAppService(IRepository<ReceiveNoteItem, Guid> receiveNoteItemRepository, IRepository<StockReceiveHeader, Guid> stockReceiveHeaderRepository)
        {
            _receiveNoteItemRepository = receiveNoteItemRepository;
            _stockReceiveHeaderRepository = stockReceiveHeaderRepository;
        }

        
        public ReceiveNoteItemDto GetReceiveNoteItemsByID(EntityRequestInput<Guid> input)
        {
            var @receivenoteitem = _receiveNoteItemRepository.GetAll()

                .Where(Y => Y.Id == input.Id)
                .ToList().FirstOrDefault();

            return @receivenoteitem.MapTo<ReceiveNoteItemDto>();

        }

        public ReceiveNoteItemListDto GetDetail(EntityRequestInput<Guid> input)
        {
            var @receiveNoteItem = _receiveNoteItemRepository
                .GetAll()
                .Include(x => x.SerialItems)
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@receiveNoteItem == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @receiveNoteItem.MapTo<ReceiveNoteItemListDto>();

        }

        public async Task Update(EditReceiveNoteItemDto input)
        {
            var @receiveNoteItem = input.MapTo<ReceiveNoteItem>();
            @receiveNoteItem.TenantId = AbpSession.GetTenantId();

            await _receiveNoteItemRepository.UpdateAsync(@receiveNoteItem);
        }

        public async Task Create(CreateReceiveNoteItemDto input)
        {
           var _header = _stockReceiveHeaderRepository.Get(input.StockReceiveHeaderId);
     
            var @receiveNoteItem = input.MapTo<ReceiveNoteItem>();    

            @receiveNoteItem.TenantId = AbpSession.GetTenantId();

            @receiveNoteItem.ItemMasterId = input.ItemMasterId;

            @receiveNoteItem = ReceiveNoteItem.Create(input.ItemCode, input.PurchasePrice, input.Nos, input.isIncludeSerials);

            _header.ReceiveNoteItems.Add(@receiveNoteItem);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(DeleteReceiveNoteItemDto input)
        {
            var @receiveNoteItem = input.MapTo<ReceiveNoteItem>();

            await _receiveNoteItemRepository.DeleteAsync(@receiveNoteItem.Id);
        }
    }
}

