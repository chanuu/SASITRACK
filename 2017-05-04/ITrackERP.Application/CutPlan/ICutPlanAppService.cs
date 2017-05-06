using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.CutPlan.Dto;

namespace ITrackERP.CutPlan
{
    public interface ICutPlanAppService : IApplicationService
    {
        ListResultOutput<CutPlanDto> GetCutPlan();

        CutPlanDetailOutput GetDetail(EntityResultOutput<Guid> input);

        Task Create(CreateCutPlanInputDto input);
    }
}
