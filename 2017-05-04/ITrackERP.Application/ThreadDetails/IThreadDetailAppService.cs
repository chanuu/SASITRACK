using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.ThreadDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.ThreadDetails
{
    public interface IThreadDetailAppService : IApplicationService
    {
        ThreadDetailDto GetThreadDetailsByID(EntityRequestInput<Guid> input);

        Task UpdateThreadDetail(EditThreadDetailDto input);

        Task CreateThreadDetail(CreateThreadDetailDto input);

        Task DeleteThreadDetail(DeleteThreadDetailDto input);


    }

}

