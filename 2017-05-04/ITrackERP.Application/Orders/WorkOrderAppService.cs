using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using ITRACK.Costing;
using System.Data.Entity;


namespace ITrackERP.Orders.Dto
{
    public  class WorkOrderAppService : ITrackERPAppServiceBase, IWorkOrderAppService
    {
        private readonly IRepository<WorkOrderHeader, Guid> _workorderRepository;

        private readonly IRepository<WorkOrderRatio, Guid> _workorderRatioRepository;


        public WorkOrderAppService(IRepository<WorkOrderHeader, Guid> workOrderRepository, IRepository<WorkOrderRatio, Guid> workOrderRatioRepository)
        {
            _workorderRepository = workOrderRepository;
            _workorderRatioRepository = workOrderRatioRepository;
        }

        public ListResultOutput<WorkOrderDto> GetWorkOrder()
        {
            var workorders = _workorderRepository.GetAll().ToList();
               

            return new ListResultOutput<WorkOrderDto>(
                workorders.MapTo<List<WorkOrderDto>>()
                );
        }


        public WorkOrderHeaderDtailsDto GetDetail(EntityRequestInput<Guid> input)
        {
            var workorder = _workorderRepository
               .GetAll()

               .Include(x => x.WorkOrderRatios)

               .Include(x=>x.Style)

               .OrderBy(x => x.CreationTime)

               .Where(e => e.Id == input.Id)

               .ToList().FirstOrDefault();

            if (@workorder == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
           return @workorder.MapTo<WorkOrderHeaderDtailsDto>();

        }


        public int GetOrderQty(WorkOrderDto input)
        {
         var item =   _workorderRepository
               .GetAll()

               .Include(x => x.WorkOrderRatios)

               

               .OrderBy(x => x.CreationTime)

               .Where(e => e.StyleNo == input.StyleNo)

               .ToList().FirstOrDefault();
            int _sum = 0;

            if (item != null)
            {
                foreach (var line in item.WorkOrderRatios)
                {
                    _sum = _sum + line.Quantity;
                }
                return _sum;
            }
            else
            {
                return 0;
            }

           
        }

        public ListResultOutput<WorkOrderRatioDto> GetDetailByStyle(EntityRequestInput<Guid> input)
        {
            var workorder = _workorderRatioRepository
               .GetAll()

               .OrderBy(x => x.CreationTime)

               .Where(e => e.WorkOrderHeader.StyleId == input.Id)

               .ToList();

            if (@workorder == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return new ListResultOutput<WorkOrderRatioDto>(
                workorder.MapTo<List<WorkOrderRatioDto>>()
                );

        }




        public async Task Create(CreateWorkOrderDto input)
        {
            var @workorder = input.MapTo<WorkOrderHeader>();
            @workorder = WorkOrderHeader.Create(AbpSession.GetTenantId(), input.WorkOrderNo, input.StartDate, input.EndDate,
                input.Status, input.Priority, input.Remark, input.StyleId,input.StyleNo);
            int i = 0;
            await _workorderRepository.InsertAsync(@workorder);
        }


        public async Task CreateItem(WorkOrderRatioDto input)
        {
           var workorder = _workorderRepository.Get(input.WorkOrderHeaderId);

            var @workOrderItem = input.MapTo<WorkOrderRatio>();

           workorder.WorkOrderRatios.Add(@workOrderItem);

            await CurrentUnitOfWork.SaveChangesAsync();
        }


        public async Task Update(EditWorkOrderDto input)
        {
            var @order = input.MapTo<WorkOrderHeader>();
            @order.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _workorderRepository.UpdateAsync(@order);
        }

    }

   
}
