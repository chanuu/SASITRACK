using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using AutoMapper.QueryableExtensions;
using ITrackERP.JobCardHeaders.DTOs;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Linq.Extensions;
using System.Data.Entity;
using AutoMapper;

namespace ITrackERP.JobCardHeader
{
    public class JobCardHeaderAppService : ITrackERPAppServiceBase, IJobCardHeaderAppService
    {

        private readonly IRepository<Maintenance.JobCardHeader, Guid> _jobCardHeaderRepository;

        private readonly IRepository<JobCardItem, Guid> _jobCardItemRepository;
       
        public JobCardHeaderAppService(IRepository<Maintenance.JobCardHeader, Guid> jobCardHeaderRepository, IRepository<JobCardItem, Guid> jobCardItemRepository)
        {
            _jobCardHeaderRepository = jobCardHeaderRepository;
            _jobCardItemRepository = jobCardItemRepository;
        }

        public ListResultOutput<JobCardHeaderDto> GetJobCardHeader()
        {
            var jobcardheader = _jobCardHeaderRepository.GetAll();
            
            return new ListResultOutput<JobCardHeaderDto>(jobcardheader.MapTo<List<JobCardHeaderDto>>());
        }


        public JobCardHeaderListDto GetDetail(EntityRequestInput<Guid> input)
        {
            var @jobcardheader = _jobCardHeaderRepository
                .GetAll()
                .Include(x => x.JobCardItems)


                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@jobcardheader == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @jobcardheader.MapTo<JobCardHeaderListDto>();

        }

        
        public ListResultOutput<JobCardHeaderListDto> GetJobCardHeadersByDateRangeAndAssetNo(JobCardHeaderInputDto input)
        {
            var @jobcardheader = _jobCardHeaderRepository.GetAll()
                .Include(x => x.JobCardItems)
                .Where(Y => Y.AssetNo == input.AssetNo)
                .WhereIf(true, Y => Y.Date >= input.From && Y.Date <= input.To)
                .OrderBy(x => x.CreationTime);

            return new ListResultOutput<JobCardHeaderListDto>(jobcardheader.MapTo<List<JobCardHeaderListDto>>());
        }

        public ListResultOutput<JobCardHeaderListDto> GetJobCardHeadersByDateRange(JobCardHeaderInputDto input)
        {
            var @jobcardheader = _jobCardHeaderRepository.GetAll()
                .Include(x => x.JobCardItems)
                .WhereIf(true, Y => Y.Date >= input.From && Y.Date <= input.To && Y.Status == "Approved")
                .OrderBy(x => x.CreationTime);

            return new ListResultOutput<JobCardHeaderListDto>(jobcardheader.MapTo<List<JobCardHeaderListDto>>());
        }
        
        public ListResultOutput<JobCardHeaderListDto> GetJobCardHeadersByDateRangeAndDoneBy(JobCardHeaderInputDto input)
        {
            var @jobcardheader = _jobCardHeaderRepository.GetAll()
                .Include(x => x.JobCardItems)
                .Where(x=> x.DoneBy == input.DoneBy)
                .WhereIf(true, Y => Y.Date >= input.From && Y.Date <= input.To)
                .OrderBy(x => x.CreationTime);

            return new ListResultOutput<JobCardHeaderListDto>(jobcardheader.MapTo<List<JobCardHeaderListDto>>());
        }
        public string GetJobCardNo()
        {
            var @jobcardheader = _jobCardHeaderRepository
                 .GetAll().OrderByDescending(x => x.CreationTime).FirstOrDefault();

            var jobCardNo = "J-0000000";
            if (@jobcardheader != null)
            {

                var jobcardno = @jobcardheader.JobcardNo;

                string[] words = jobcardno.Split('-');

                jobCardNo = "J-" + (Convert.ToInt32(words[1]) + 1).ToString().PadLeft(7, '0');
            }
            else
            {
                jobCardNo = "J-0000001";
            }
            return jobCardNo;
        }

        public async Task Create(CreateJobCardHeaderDto input)
        {
            var @jobcardheader = input.MapTo<Maintenance.JobCardHeader>();

            @jobcardheader = Maintenance.JobCardHeader.Create(AbpSession.GetTenantId(), GetJobCardNo(), input.Date.Value, input.AssetNo, input.Description, input.TotalCost, input.DoneBy, "N/A", "Pending", input.Remark);

            int i = 0;
            await _jobCardHeaderRepository.InsertAsync(@jobcardheader);
        }

        public async Task Update(EditJobCardHeaderDto input)
        {
            var @jobcardheader = input.MapTo<Maintenance.JobCardHeader>();
            @jobcardheader.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _jobCardHeaderRepository.UpdateAsync(@jobcardheader);
        }

        public async Task Delete(DeleteJobCardHeaderDto input)
        {
            var @jobcardheader = input.MapTo<Maintenance.JobCardHeader>();
            await _jobCardHeaderRepository.DeleteAsync(@jobcardheader.Id);
        }
    }
}