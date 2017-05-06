using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Maintenance;
using ITrackERP.StockReceiveHeaders.DTOs;
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

namespace ITrackERP.StockReceiveHeaders
{
    public class StockReceiveHeaderAppService : ITrackERPAppServiceBase, IStockReceiveHeaderAppService
    {
        private readonly IRepository<StockReceiveHeader, Guid> _stockReceiveHeaderRepository;

        private readonly IRepository<ReceiveNoteItem, Guid> _receiveNoteItemRepository;

        public StockReceiveHeaderAppService(IRepository<StockReceiveHeader, Guid> stockReceiveHeaderRepository, IRepository<ReceiveNoteItem, Guid> receiveNoteItemRepository)
        {
            _stockReceiveHeaderRepository = stockReceiveHeaderRepository;
            _receiveNoteItemRepository = receiveNoteItemRepository;
        }

        public ListResultOutput<StockReceiveHeaderDto> GetStockReceiveHeader()
        {
            var stockReceiveHeader = _stockReceiveHeaderRepository.GetAll();

            return new ListResultOutput<StockReceiveHeaderDto>(stockReceiveHeader.MapTo<List<StockReceiveHeaderDto>>());
        }

        public StockReceiveHeaderListDto GetDetail(EntityResultOutput<Guid> input)
        {
            var @stockReceiveHeader = _stockReceiveHeaderRepository
                .GetAll()
                .Include(x => x.ReceiveNoteItems)
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@stockReceiveHeader == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @stockReceiveHeader.MapTo<StockReceiveHeaderListDto>();
        }
        public async Task Update(EditStockReceiveHeaderDto input)
        {
            var @stockReceiveHeader = input.MapTo<StockReceiveHeader>();
            @stockReceiveHeader.TenantId = AbpSession.GetTenantId();
          
            await _stockReceiveHeaderRepository.UpdateAsync(@stockReceiveHeader);
        }

        public string GetReceiveNoteNo()
        {
            var @stockreceiveheader = _stockReceiveHeaderRepository
                 .GetAll().OrderByDescending(x => x.CreationTime).FirstOrDefault();

            var receiveNoteNo = "SR-0000000";

            if (@stockreceiveheader != null)
            {
                var receivenoteno = @stockreceiveheader.ReceiveNoteNo;

                string[] words = receivenoteno.Split('-');

                receiveNoteNo = "SR-" + (Convert.ToInt32(words[1]) + 1).ToString().PadLeft(7, '0');
            }
            else
            {
                receiveNoteNo = "SR-0000001";
            }
            return receiveNoteNo;
        }
        public async Task Create(CreateStockReceiveHeaderDto input)
        {
            var @stockReceiveHeader = input.MapTo<StockReceiveHeader>();

            @stockReceiveHeader = StockReceiveHeader.Create(AbpSession.GetTenantId(), GetReceiveNoteNo(), input.Date.Value, input.Remark, input.By);

            await _stockReceiveHeaderRepository.InsertAsync(@stockReceiveHeader);

        }

        public async Task Delete(DeleteStockReceiveHeaderDto input)
        {
            var @stockReceiveHeader = input.MapTo<StockReceiveHeader>();

            await _stockReceiveHeaderRepository.DeleteAsync(@stockReceiveHeader.Id);
        }
    }
}
