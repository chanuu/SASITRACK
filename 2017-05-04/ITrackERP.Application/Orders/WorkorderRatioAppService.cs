using Abp.AutoMapper;
using ITRACK.Costing;
using ITrackERP.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Runtime.Session;
using Abp.Domain.Repositories;

namespace ITrackERP.Orders
{
   public class WorkorderRatioAppService : ITrackERPAppServiceBase, IWorkorderRatioAppService
    {
        private readonly IRepository<WorkOrderRatio, Guid> _workorderRatioRepository;


        public WorkorderRatioAppService(IRepository<WorkOrderRatio, Guid> workOrderRatioRepository)
        {
            _workorderRatioRepository = workOrderRatioRepository;
        }

        public async Task CreateItem(WorkOrderRatioDto input)
        {
            var @workorder = input.MapTo<WorkOrderRatio>();
            @workorder = WorkOrderRatio.Create(AbpSession.GetTenantId(), input.WorkOrderHeaderId, input.Color, input.Size, input.Length, input.Quantity);
           
            await _workorderRatioRepository.InsertAsync(@workorder);
        }


        public WorkOrderRatioDto GetItemDetail(EntityRequestInput<Guid> input)
        {
            var @Item = _workorderRatioRepository.GetAll()

                .Where(Y => Y.Id == input.Id)
                .ToList().FirstOrDefault();

            return @Item.MapTo<WorkOrderRatioDto>();
        }

       public async Task Delete(WorkOrderRatioDto input)
        {
            var item = _workorderRatioRepository.Get(input.Id);

            await _workorderRatioRepository.DeleteAsync(item);
        }

        public async Task Update(WorkOrderRatioDto input)
        {
            var item = _workorderRatioRepository.Get(input.Id);
            item.Color = input.Color;
            item.Size = input.Size;
            item.Length = input.Length;
            item.Quantity = input.Quantity; 
            await _workorderRatioRepository.UpdateAsync(item);
        }
    }
}
