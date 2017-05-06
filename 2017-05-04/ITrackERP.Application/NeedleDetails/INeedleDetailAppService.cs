using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.NeedleDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.NeedleDetails
{
    public interface INeedleDetailAppService : IApplicationService
    {
        NeedleDetailDto GetNeedleDetailsByID(EntityRequestInput<Guid> input);

        Task UpdateNeedleDetail(EditNeedleDetailDto input);

        Task CreateNeedleDetail(CreateNeedleDetailDto input);

        Task DeleteNeedleDetail(DeleteNeedleDetailDto input);


    }

}