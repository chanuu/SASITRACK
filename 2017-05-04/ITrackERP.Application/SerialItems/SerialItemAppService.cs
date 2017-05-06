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
using Abp.Domain.Repositories;
using ITrackERP.Maintenance;
using Abp.Application.Services.Dto;
using ITrackERP.SerialItems.DTOs;

namespace ITrackERP.SerialItems
{
    public class SerialItemAppService : ITrackERPAppServiceBase, ISerialItemAppService
    {
        private readonly IRepository<SerialItem, Guid> _serialItemRepository;

        private readonly IRepository<ReceiveNoteItem, Guid> _receiveNoteItemRepository;

        public SerialItemAppService(IRepository<SerialItem, Guid> serialItemRepository, IRepository<ReceiveNoteItem, Guid> receiveNoteItemRepository)
        {
            _serialItemRepository = serialItemRepository;
            _receiveNoteItemRepository = receiveNoteItemRepository;
        }

        public ListResultOutput<SerialItemDto> GetSerialItem()
        {
            var serialItem = _serialItemRepository.GetAll();

            return new ListResultOutput<SerialItemDto>(serialItem.MapTo<List<SerialItemDto>>());
        }

        public ListResultOutput<SerialItemDto> GetSerialItemByItemCode(GetSerialItemByItemCodeInputDto input)
        {
            var serialItem = _serialItemRepository.GetAll()
                .WhereIf(true,x => x.ItemCode == input.ItemCode && x.Status == "Available");

            return new ListResultOutput<SerialItemDto>(serialItem.MapTo<List<SerialItemDto>>());
        }

        public SerialItemDto GetSerialItemByID(EntityRequestInput<Guid> input)
        {
            var @serialitem = _serialItemRepository.GetAll()

                .Where(Y => Y.Id == input.Id)
                .ToList().FirstOrDefault();

            return @serialitem.MapTo<SerialItemDto>();

        }

        public SerialItemDto GetDetailBySerialNo(SerialNoInputDto input)
        {
            var @serialitem = _serialItemRepository.GetAll()

                .Where(Y => Y.SerialNo == input.SerialNo)
                .ToList().FirstOrDefault();

            return @serialitem.MapTo<SerialItemDto>();

        }
        public async Task Update(EditSerialItemDto input)
        {
            var @serialItem = input.MapTo<SerialItem>();
            @serialItem.TenantId = AbpSession.GetTenantId();

            await _serialItemRepository.UpdateAsync(@serialItem);
        }

        public async Task UpdateSerialItemBySerialNo(SerialNoInputDto input)
        {
            var @serialitem = _serialItemRepository.GetAll().WhereIf(true, x => x.SerialNo == input.SerialNo).OrderByDescending(x => x.CreationTime).FirstOrDefault();

            @serialitem.Status = "Used";

            var serialItem = @serialitem.MapTo<SerialItem>();

            serialItem.TenantId = AbpSession.GetTenantId();

            await _serialItemRepository.UpdateAsync(serialItem);
        }
        public async Task UpdateSerialItemBySerialNo1(SerialNoInputDto input)
        {
            var @serialitem = _serialItemRepository.GetAll().WhereIf(true, x => x.SerialNo == input.SerialNo).OrderByDescending(x => x.CreationTime).FirstOrDefault();

            @serialitem.Status = "Available";

            var serialItem = @serialitem.MapTo<SerialItem>();

            serialItem.TenantId = AbpSession.GetTenantId();

            await _serialItemRepository.UpdateAsync(serialItem);
        }

        public async Task Create(CreateSerialItemDto input)
        {

            var _header = _receiveNoteItemRepository.Get(input.ReceiveNoteItemId);

            var @serialItem = input.MapTo<SerialItem>();

            @serialItem.TenantId = AbpSession.GetTenantId();

            @serialItem = SerialItem.Create(input.ItemCode, input.SerialNo, "Available");

            _header.SerialItems.Add(@serialItem);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(DeleteSerialItemDto input)
        {
            var @serialItem = input.MapTo<SerialItem>();

            await _serialItemRepository.DeleteAsync(@serialItem.Id);
        }
    }
}

