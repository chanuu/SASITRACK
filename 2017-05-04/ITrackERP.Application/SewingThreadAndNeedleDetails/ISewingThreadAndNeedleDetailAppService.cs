using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.SewingThreadAndNeedleDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.SewingThreadAndNeedleDetails
{
    public interface ISewingThreadAndNeedleDetailAppService : IApplicationService
    {
        ListResultDto<SewingThreadAndNeedleDetailListDto> GetSewingThreadAndNeedleDetails(GetSewingThreadAndNeedleDetailInput input);

        ListResultDto<SewingThreadAndNeedleDetailListDto> GetSewingThreadAndNeedleDetailsByID(EntityRequestInput<Guid> input);

        Task CreateDetail(CreateSewingThreadAndNeedleDetailDto input);

        Task UpdateDetail(EditSewingThreadAndNeedleDetailDto input);

        Task DeleteDetail(DeleteSewingThreadAndNeedleDetailDto input);
    }
}