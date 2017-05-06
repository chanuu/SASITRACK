using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.LayoutHeaders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.LayoutHeaders
{
    public interface ILayoutHeaderAppService : IApplicationService
    {
        ListResultOutput<LayoutHeaderListDto> GetLayoutHeader();

        LayoutHeaderDto GetDetail(EntityRequestInput<Guid> input);

        LayoutHeaderDto GetDetailByDividingPlanHeaderId(DividingPlanHeaderIdInputDto input);
        bool HeaderIdCheck(DividingPlanHeaderIdInputDto input);
        Task Create(CreateLayoutHeaderDto input);

        Task Update(EditLayoutHeaderDto input);

        Task Delete(DeleteLayoutHeaderDto input);

    }

}

