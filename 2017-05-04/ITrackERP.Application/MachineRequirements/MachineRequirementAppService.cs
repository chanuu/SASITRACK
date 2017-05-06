using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.MachineRequirements.DTOs;
using ITrackERP.TAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.AutoMapper;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Abp.Linq.Extensions;
using Abp.Domain.Uow;

namespace ITrackERP.MachineRequirements
{
    public class MachineRequirementAppService: ITrackERPAppServiceBase, IMachineRequirementAppService
   {
       private readonly IRepository<MachineRequirement, Guid> _machineRequirementRepository;
       private readonly IRepository<MachineRequirementItem, Guid> _machineRequirementItemRepository;

       public MachineRequirementAppService(IRepository<MachineRequirement, Guid> machineRequirementRepository,IRepository<MachineRequirementItem, Guid> machineRequirementItemRepository)
           
       {
           _machineRequirementRepository = machineRequirementRepository;
           _machineRequirementItemRepository = machineRequirementItemRepository;
       }


        public ListResultOutput<MachineRequirementListDto> GetMachineRequirement()
        {
            var machinerequirement = _machineRequirementRepository.GetAll();

            return new ListResultOutput<MachineRequirementListDto>(machinerequirement.MapTo<List<MachineRequirementListDto>>());
        }


        public ListResultOutput<MachineRequirementItemListDto> GetMachineRequirementItems(MachineRequirementIdInputDto input)
        {
            var machinerequirementitem = _machineRequirementItemRepository.GetAll()

              .Where(Y => Y.MachineRequirementId == input.MachineRequirementId)
              .ToList();

            return new ListResultOutput<MachineRequirementItemListDto>(machinerequirementitem.MapTo<List<MachineRequirementItemListDto>>());
        }

        public MachineRequirementItemDto GetMachineRequirementItemByID(EntityRequestInput<Guid> input)
        {
            var @machinerequirement = _machineRequirementItemRepository.GetAll()
              
                .Where(Y => Y.Id == input.Id)
                .ToList().FirstOrDefault();
            
            return @machinerequirement.MapTo<MachineRequirementItemDto>();
        }
     
        public ListResultOutput<MachineRequrementItemByStyleDto> GetMachineRequirementItemByDate(filterInput input)
        {
            var @machinerequirement = _machineRequirementRepository.GetAll()

              .Include(x => x.MachineRequirementItems)
              .WhereIf(true, Y => Y.FromDate <= input.From && Y.ToDate >= input.From)
                .ToList();

            return new ListResultOutput<MachineRequrementItemByStyleDto>(@machinerequirement.MapTo<List<MachineRequrementItemByStyleDto>>());
          
        }


        public MachineRequirementDto GetDetail(EntityRequestInput<Guid> input)
       {
            
            var @machinerequirement = _machineRequirementRepository
               .GetAll()
               .Include(x => x.MachineRequirementItems)
               .Where(e => e.Id == input.Id )
               .ToList().FirstOrDefault();

            if (@machinerequirement == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @machinerequirement.MapTo<MachineRequirementDto>();

        }

        public async Task DuplicateEvent(CreateMachineRequirementDto input)
        {
            var @machinerequirement = input.MapTo<MachineRequirement>();

            @machinerequirement = MachineRequirement.Create(AbpSession.GetTenantId(), input.StyleNo, input.LineNo, input.Remark, input.FromDate, input.ToDate, input.LocationCode, input.StyleId);

            await _machineRequirementRepository.InsertAsync(@machinerequirement);

            await CurrentUnitOfWork.SaveChangesAsync();

            var @styleloading= _machineRequirementRepository
              .GetAll()
              .Include(x => x.MachineRequirementItems)
              .Where(e => e.Id == input.Id)
              .ToList().FirstOrDefault();

              var @lastcreatedevent = _machineRequirementRepository
               .GetAll()
               .OrderByDescending(x => x.CreationTime)
               .ToList().FirstOrDefault();

              var header = _machineRequirementRepository.Get(@lastcreatedevent.Id);


            foreach (var item in @styleloading.MachineRequirementItems)
            {
                var @machinerequirementitem = MachineRequirementItem.Create(item.MachineType, item.Nos, item.Remark);

                @machinerequirementitem.TenantId = AbpSession.GetTenantId();

                @machinerequirementitem.MachineRequirementId = @lastcreatedevent.Id;

                header.MachineRequirementItems.Add(machinerequirementitem);

                await CurrentUnitOfWork.SaveChangesAsync();
            }
            
        }
        public async Task CreateHeader(CreateMachineRequirementDto input)
       {
            var @machinerequirement = input.MapTo<MachineRequirement>();
               
            @machinerequirement = MachineRequirement.Create(AbpSession.GetTenantId(),input.StyleNo, input.LineNo, input.Remark,input.FromDate,input.ToDate, input.LocationCode,input.StyleId);
            
            await _machineRequirementRepository.InsertAsync(@machinerequirement);
        }

        public async Task UpdateHeader(EditMachineRequirementDto input)
        {
            var @machinerequirement= input.MapTo<MachineRequirement>();
            @machinerequirement.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _machineRequirementRepository.UpdateAsync(@machinerequirement);
        }

        public async Task DeleteHeader(DeleteMachineRequirementDto input)
        {
            var @machinerequirement = input.MapTo<MachineRequirement>();
            await _machineRequirementRepository.DeleteAsync(@machinerequirement.Id);
        }
        public async Task UpdateItem(EditMachineRequirementItemDto input)
        {
            var @machinerequirement = input.MapTo<MachineRequirementItem>();
            @machinerequirement.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _machineRequirementItemRepository.UpdateAsync(@machinerequirement);
        }

        public async Task CreateItem(CreateMachineRequirementItemDto input)
        {
            var header = _machineRequirementRepository.Get(input.MachineRequirementId);

            var @machinerequirementitem = input.MapTo<MachineRequirementItem>();

            @machinerequirementitem.TenantId = AbpSession.GetTenantId();

            @machinerequirementitem = MachineRequirementItem.Create(input.MachineType, input.Nos,input.Remark);

            header.MachineRequirementItems.Add(machinerequirementitem);
            
            await CurrentUnitOfWork.SaveChangesAsync();
        }
        public async Task DeleteItem(DeleteMachineRequirementItemDto input)
        {
            var @machinerequirementitem = input.MapTo<MachineRequirementItem>();

            await _machineRequirementItemRepository.DeleteAsync(@machinerequirementitem.Id);
        }
    }
}
