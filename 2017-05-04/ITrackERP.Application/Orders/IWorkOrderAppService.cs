using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Orders
{
   public interface IWorkOrderAppService : IApplicationService
    {
        
 
        ListResultOutput<WorkOrderDto> GetWorkOrder();
        WorkOrderHeaderDtailsDto GetDetail(EntityRequestInput<Guid> input);

        ListResultOutput<WorkOrderRatioDto> GetDetailByStyle(EntityRequestInput<Guid> input);

        Task Create(CreateWorkOrderDto input);

        Task CreateItem(WorkOrderRatioDto input);

        Task Update(EditWorkOrderDto input);

        int GetOrderQty(WorkOrderDto input);


    }
}
