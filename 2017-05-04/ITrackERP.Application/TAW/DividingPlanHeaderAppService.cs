using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.TAW;
using ITrackERP.TAWs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Abp.Linq.Extensions;
using Abp.AutoMapper;
using System.Data.Entity;
using ITrackERP.TAW.DTOs;

namespace ITrackERP.TAWs
{
    public class DividingPlanHeaderAppService : ITrackERPAppServiceBase, IDividingPlanHeaderAppService
    {
       private readonly IRepository<DividingPlanHeader, Guid> _dividingplanheaderRepository;
       private readonly IRepository<DividingPlanItem, Guid> _dividingplanitemRepository;

       public DividingPlanHeaderAppService(IRepository<DividingPlanHeader, Guid> dividingplaheaderRepository, IRepository<DividingPlanItem, Guid> dividingplanitemRepository)
           
       {
           _dividingplanheaderRepository = dividingplaheaderRepository;
           _dividingplanitemRepository = dividingplanitemRepository;
       }

       public ListResultOutput<DividingPlanHeaderListDto> GetDividingPlanHeader()
        {
            var dividingplanheader = _dividingplanheaderRepository.GetAll();

            return new ListResultOutput<DividingPlanHeaderListDto>(dividingplanheader.MapTo<List<DividingPlanHeaderListDto>>());
        }

      
       public DividingPlanItemDto GetDividingPlanHeaderItemByID(EntityRequestInput<Guid> input)
        {
            var @dividingplanheader = _dividingplanitemRepository.GetAll()

                .Where(Y => Y.Id == input.Id)
                .ToList().FirstOrDefault();

            return @dividingplanheader.MapTo<DividingPlanItemDto>();
        }

        public DividingPlanHeaderDto GetDetail(EntityRequestInput<Guid> input)
       {
           var @dividingplanheader = _dividingplanheaderRepository
               .GetAll()
               .Include(x => x.DividingPlanItems)

               .Where(e => e.Id == input.Id )
               .ToList().FirstOrDefault();

           if (@dividingplanheader == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @dividingplanheader.MapTo<DividingPlanHeaderDto>();
        }

        public async Task CreateHeader(CreateDividingPlanHeaderDto input)
       {
           var @dividingplanheader = input.MapTo<DividingPlanHeader>();
           
            @dividingplanheader = DividingPlanHeader.Create(AbpSession.GetTenantId(), input.LineNo, input.TotalEmployee, input.Target, input.ProductionPerHour, input.Remark, input.StyleId);
           
            int i = 0;
            await _dividingplanheaderRepository.InsertAsync(@dividingplanheader);
        }

        public async Task UpdateHeader(EditDividingPlanHeaderDto input)
        {
            var @dividingplaheader = input.MapTo<DividingPlanHeader>();
            @dividingplaheader.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _dividingplanheaderRepository.UpdateAsync(@dividingplaheader);
        }


        public async Task DeleteHeader(DeleteDividingPlanHeaderDto input)
        {
            var @dividingplaheader = input.MapTo<DividingPlanHeader>();
            await _dividingplanheaderRepository.DeleteAsync(@dividingplaheader.Id);
        }

        public async Task UpdateItem(EditDividingPlanItemDto input)
        {
            var @dividingplaheader = input.MapTo<DividingPlanItem>();
           @dividingplaheader.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _dividingplanitemRepository.UpdateAsync(@dividingplaheader);
        }

        public async Task CreateItem(CreateDividingPlanItemDto input)
        {
            var header = _dividingplanheaderRepository.Get(input.DividingPlanHeaderId);

            var @dividingplanitem = input.MapTo<DividingPlanItem>();

            @dividingplanitem.TenantId = AbpSession.GetTenantId();

            @dividingplanitem = DividingPlanItem.Create(input.OperationNo,input.OperationName,input.SMVType,input.MachineType,input.OperationRole,input.PartName,input.SMV,input.WorkstationNo,input.OpNo);
           
            header.DividingPlanItems.Add(@dividingplanitem);

            await CurrentUnitOfWork.SaveChangesAsync();
            
        }

        public async Task DeleteItem(DeleteDividingPlanItemDto input)
        {
            var @dividingplanitem = input.MapTo<DividingPlanItem>();

            await _dividingplanitemRepository.DeleteAsync(@dividingplanitem.Id);
        }
    }
}
