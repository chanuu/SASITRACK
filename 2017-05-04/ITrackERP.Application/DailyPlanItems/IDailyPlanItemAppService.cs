using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.DailyPlanItems.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.DailyPlanItems
{
    public interface IDailyPlanItemAppService : IApplicationService
    {
        DailyPlanItemDto GetDetail(EntityResultOutput<Guid> input);

        Task Create(CreateDailyPlanItemDto input);

        Task Update(EditDailyPlanItemDto input);

        Task Delete(DeleteDailyPlanItemDto input);
    }
}
