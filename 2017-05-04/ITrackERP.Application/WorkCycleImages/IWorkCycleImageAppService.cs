using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.WorkCycleImages.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.WorkCycleImages
{
    public interface IWorkCycleImageAppService : IApplicationService
    {
        WorkCycleImageDto GetWorkCycleImageDetailsByID(EntityRequestInput<Guid> input);

        Task UpdateWorkCycleImage(EditWorkCycleImageDto input);

        Task CreateWorkCycleImage(CreateWorkCycleImageDto input);

        Task DeleteWorkCycleImage(DeleteWorkCycleImageDto input);


    }

}
