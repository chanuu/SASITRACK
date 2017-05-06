using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.DailyPlanHeaders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.DailyPlanHeaders
{
    public interface IDailyPlanHeaderAppService : IApplicationService
    {
        ListResultOutput<DailyPlanHeaderListDto> GetAll();

        DailyPlanHeaderDto GetDetail(EntityResultOutput<Guid> input);

        Task Create(CreateDailyPlanHeaderDto input);

        Task Update(EditDailyPlanHeaderDto input);

        Task Delete(DeleteDailyPlanHeaderDto input);
    }
}

