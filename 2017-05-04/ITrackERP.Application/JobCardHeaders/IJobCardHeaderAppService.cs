using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.JobCardHeaders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.JobCardHeader
{
    public interface IJobCardHeaderAppService : IApplicationService
    {
        ListResultOutput<JobCardHeaderDto> GetJobCardHeader();
        JobCardHeaderListDto GetDetail(EntityRequestInput<Guid> input);

        ListResultOutput<JobCardHeaderListDto> GetJobCardHeadersByDateRangeAndAssetNo(JobCardHeaderInputDto input);

        ListResultOutput<JobCardHeaderListDto> GetJobCardHeadersByDateRange(JobCardHeaderInputDto input);

        ListResultOutput<JobCardHeaderListDto> GetJobCardHeadersByDateRangeAndDoneBy(JobCardHeaderInputDto input);

        Task Create(CreateJobCardHeaderDto input);

        Task Update(EditJobCardHeaderDto input);

        Task Delete(DeleteJobCardHeaderDto input);
    }
}