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
using ITrackERP.CutPlan.Dto;
using ITrackERP.Styles.Dto;

namespace ITrackERP.CutPlan
{
    public class CutPlanAppService : ITrackERPAppServiceBase, ICutPlanAppService
    {
        private readonly IRepository<Company.CutPlan, Guid> _cutplanRepository;

        public CutPlanAppService(IRepository<Company.CutPlan, Guid> cutplanRepository)
        {
            _cutplanRepository = cutplanRepository;
        }

        public ListResultOutput<CutPlanDto> GetCutPlan()
        {
            var cutplans = _cutplanRepository.GetAll().ToList();

            return new ListResultOutput<CutPlanDto>(cutplans.MapTo<List<CutPlanDto>>());
        }

        public CutPlanDetailOutput GetDetail(EntityResultOutput<Guid> input)
        {
            var @cutplan = _cutplanRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();
            if (@cutplan == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @cutplan.MapTo<CutPlanDetailOutput>();

        }

        public async Task Create(CreateCutPlanInputDto input)
        {
            var @cutplan = input.MapTo<Company.CutPlan>();
            @cutplan = Company.CutPlan.Create(AbpSession.GetTenantId(),input.CutPlanNo, input.Date, input.FabricType, input.Color,
                input.NoOfplys, input.Total, input.LineNo, input.Start, input.End, input.TableNo, input.TeamLeader,
                input.Status);
            int i = 0;
            await _cutplanRepository.InsertAsync(@cutplan);
        }
    }
}
