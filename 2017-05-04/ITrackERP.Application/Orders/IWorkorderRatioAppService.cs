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
    public interface IWorkorderRatioAppService : IApplicationService
    {
        Task CreateItem(WorkOrderRatioDto input);

        Task Update(WorkOrderRatioDto input);

        Task Delete(WorkOrderRatioDto input);

        WorkOrderRatioDto GetItemDetail(EntityRequestInput<Guid> input);

        

    }
}
