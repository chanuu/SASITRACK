using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.JobCardItems.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.JobCardItems
{
    public interface IJobCardItemAppService : IApplicationService
    {
        ListResultOutput<JobCardItemDto> GetJobCardItem();
        JobCardItemDto GetJobCardItemByID(EntityRequestInput<Guid> input);

        double GetJobCardHeaderTotalCost(EntityRequestInput<Guid> input);
        Task Create(CreateJobCardItemDto input);

        Task Update(EditJobCardItemDto input);

        Task Delete(DeleteJobCardItemDto input);
    }
}