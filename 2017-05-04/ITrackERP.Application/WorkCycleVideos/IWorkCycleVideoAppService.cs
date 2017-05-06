using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.WorkCycleVideos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.WorkCycleVideos
{
    public interface IWorkCycleVideoAppService : IApplicationService
    {
        WorkCycleVideoDto GetWorkCycleVideoDetailsByID(EntityRequestInput<Guid> input);

        Task UpdateWorkCycleVideo(EditWorkCycleVideoDto input);

        Task CreateWorkCycleVideo(CreateWorkCycleVideoDto input);

        Task DeleteWorkCycleVideo(DeleteWorkCycleVideoDto input);


    }

}
