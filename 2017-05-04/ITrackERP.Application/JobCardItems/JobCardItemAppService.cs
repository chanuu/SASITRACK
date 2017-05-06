using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.JobCardItems.DTOs;
using ITrackERP.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using AutoMapper.QueryableExtensions;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Linq.Extensions;
using System.Data.Entity;

namespace ITrackERP.JobCardItems
{
    public class JobCardItemAppService : ITrackERPAppServiceBase, IJobCardItemAppService
    {
        private readonly IRepository<JobCardItem, Guid> _jobCardItemRepository;

        private readonly IRepository<Maintenance.JobCardHeader, Guid> _jobCardHeaderRepository;

        private readonly IRepository<ReceiveNoteItem, Guid> _receiveNoteItemRepository;


        public JobCardItemAppService(IRepository<JobCardItem, Guid> jobCardItemRepository, IRepository<Maintenance.JobCardHeader, Guid> jobCardHeaderRepository, IRepository<ReceiveNoteItem, Guid> receiveNoteItemRepository)
        {
            _jobCardHeaderRepository = jobCardHeaderRepository;
            _jobCardItemRepository = jobCardItemRepository;
            _receiveNoteItemRepository = receiveNoteItemRepository;
        }

        public ListResultOutput<JobCardItemDto> GetJobCardItem()
        {
            var jobCardItem = _jobCardItemRepository.GetAll();

            return new ListResultOutput<JobCardItemDto>(jobCardItem.MapTo<List<JobCardItemDto>>());
        }

        public JobCardItemDto GetJobCardItemByID(EntityRequestInput<Guid> input)
        {
            var @jobCardItem = _jobCardItemRepository.GetAll()

                .Where(Y => Y.Id == input.Id)
                .ToList().FirstOrDefault();

            return @jobCardItem.MapTo<JobCardItemDto>();
        }

        public double GetJobCardHeaderTotalCost(EntityRequestInput<Guid> input)
        {
            double totalcost = _jobCardItemRepository.GetAll().Where(e => e.JobCardHeaderId == input.Id).Select(e => e.SubTotal).Sum();

            return totalcost;
        }
        public async Task Update(EditJobCardItemDto input)
        {
            var @jobCardItem = input.MapTo<JobCardItem>();
            @jobCardItem.TenantId = AbpSession.GetTenantId();

            await _jobCardItemRepository.UpdateAsync(@jobCardItem);
        }

        public async Task Create(CreateJobCardItemDto input)
        {

            var _header = _jobCardHeaderRepository.Get(input.JobCardHeaderId);

            var @receivenotebyitemcode = _receiveNoteItemRepository.GetAll().WhereIf(true, x => x.ItemCode == input.ItemCode).OrderByDescending(x => x.CreationTime).FirstOrDefault();
         
            var @jobCardItem = input.MapTo<JobCardItem>();

            @jobCardItem.TenantId = AbpSession.GetTenantId();

            @jobCardItem = JobCardItem.Create(AbpSession.GetTenantId(), input.ItemCode, input.SerialNo, input.Amount, @receivenotebyitemcode.PurchasePrice, @receivenotebyitemcode.PurchasePrice * Convert.ToInt32(input.Amount));

            _header.JobCardItems.Add(@jobCardItem);
          
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(DeleteJobCardItemDto input)
        {
            var @jobCardItem = input.MapTo<JobCardItem>();

            await _jobCardItemRepository.DeleteAsync(@jobCardItem.Id);
        }
    }
}

