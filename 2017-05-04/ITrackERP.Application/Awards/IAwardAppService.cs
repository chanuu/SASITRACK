using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.Awards.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Awards
{
    public interface IAwardAppService : IApplicationService
    {
        AwardDto GetAwardByID(EntityRequestInput<Guid> input);

        Task UpdateAward(EditAwardDto input);

        Task CreateAward(CreateAwardDto input);

        Task DeleteAward(DeleteAwardDto input);

    }
}
