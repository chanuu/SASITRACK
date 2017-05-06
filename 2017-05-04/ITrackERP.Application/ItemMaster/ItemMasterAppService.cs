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
using ITrackERP.ItemMaster.Dto;
using System.Data.Entity;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Abp.Linq.Extensions;

namespace ITrackERP.ItemMaster
{
    public class ItemMasterAppService : ITrackERPAppServiceBase, IItemMasterAppService
    {
        private readonly IRepository<Master.ItemMaster, Guid> _itemmasterRepository;

        private readonly IRepository<Master.CustomeFiledSetup, Guid> _customefieldsetupRepository;


        public ItemMasterAppService(IRepository<Master.ItemMaster, Guid> itemmasterRepository, IRepository<Master.CustomeFiledSetup, Guid> customefieldsetupRepository)
        {
            _itemmasterRepository = itemmasterRepository;
            _customefieldsetupRepository = customefieldsetupRepository;
        }

        public ListResultOutput<ItemMasterListDto> GetItemMaster()
        {
            var itemmasters = _itemmasterRepository.GetAll();
            return new ListResultOutput<ItemMasterListDto>(itemmasters.MapTo<List<ItemMasterListDto>>());
        }

        public ItemMasterDetailOutputDto GetDetail(EntityRequestInput<Guid> input)
        {
            var @itemmasters = _itemmasterRepository

                .GetAll()

                .Where(e => e.Id == input.Id)

                .ToList().FirstOrDefault();

            if (@itemmasters == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @itemmasters.MapTo<ItemMasterDetailOutputDto>();
        }


        public ItemMasterDetailOutputDto GetDetailByItemCode(ItemCodeInputDto input)
        {
            var @itemmasters = _itemmasterRepository

                .GetAll()

                .Where(e => e.ItemNo == input.ItemNo)

                .ToList().FirstOrDefault();
         
            return @itemmasters.MapTo<ItemMasterDetailOutputDto>();
        }

        public async Task Create(CreateItemMasterInputDto input)
        {
            var _header = _customefieldsetupRepository.Get(input.CustomeFiledSetupId);

            var @itemmaster = input.MapTo<Master.ItemMaster>();

            @itemmaster.TenantId = AbpSession.GetTenantId();

            @itemmaster = Master.ItemMaster.Create(AbpSession.GetTenantId(), input.ItemType, input.ItemNo, input.CustomField1, input.CustomField2, input.CustomField3, input.CustomField4, input.CustomField5, input.CustomField6, input.Supplier, "Nos", "Active", input.MaxQty, input.ReOrderQty, input.MinimumQty, input.BatchItem, input.ServiceItem, input.ShowInFrontEnd, input.Discount, input.CustomerReturnOrder, input.SerialItem, input.Image);
            
            _header.ItemMasters.Add(@itemmaster);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task Update(EditItemMasterInputDto input)
        {
            var @itemmaster = input.MapTo<Master.ItemMaster>();
            @itemmaster.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _itemmasterRepository.UpdateAsync(@itemmaster);
        }
        public async Task Delete(DeleteItemMasterInputDto input)
        {
            var @itemmaster = input.MapTo<Master.ItemMaster>();

            await _itemmasterRepository.DeleteAsync(@itemmaster.Id);
        }

    }
}


