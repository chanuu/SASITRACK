using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Cutting;
using ITrackERP.IssueNoteItems.DTOs;
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


namespace ITrackERP.IssueNoteItems
{
    public class IssueNoteItemAppService: ITrackERPAppServiceBase, IIssueNoteItemAppService
    {
        private readonly IRepository<IssueNoteItem, Guid> _issueNoteItemRepository;

        private readonly IRepository<IssueNoteHeader, Guid> _issueNoteHeaderRepository;


        public IssueNoteItemAppService(IRepository<IssueNoteItem, Guid> issueNoteItemRepository, IRepository<IssueNoteHeader, Guid> issueNoteHeaderRepository)
        {
            _issueNoteItemRepository = issueNoteItemRepository;
            _issueNoteHeaderRepository = issueNoteHeaderRepository;
        }

        public ListResultOutput<IssueNoteItemDto> GetIssueNoteItem()
        {
            var issueNoteItem = _issueNoteItemRepository.GetAll();

            return new ListResultOutput<IssueNoteItemDto>(issueNoteItem.MapTo<List<IssueNoteItemDto>>());
        }

        public IssueNoteItemDto GetDetail(EntityRequestInput<Guid> input)
        {
            var @issueNoteItem = _issueNoteItemRepository.GetAll()

                .Where(Y => Y.Id == input.Id)
                .ToList().FirstOrDefault();

            return @issueNoteItem.MapTo<IssueNoteItemDto>();
        }

        public async Task Update(EditIssueNoteItemDto input)
        {
            var @issueNoteItem = input.MapTo<IssueNoteItem>();
            @issueNoteItem.TenantId = AbpSession.GetTenantId();

            await _issueNoteItemRepository.UpdateAsync(@issueNoteItem);
        }

        public async Task Create(CreateIssueNoteItemDto input)
        {

            var _header = _issueNoteHeaderRepository.Get(input.IssueNoteHeaderId);
        
            var @issueNoteItem = input.MapTo<IssueNoteItem>();

            @issueNoteItem.TenantId = AbpSession.GetTenantId();

            @issueNoteItem = IssueNoteItem.Create(AbpSession.GetTenantId(), input.CutNo, input.Color, input.Size,input.NoOfPlys, input.NoOfItem, input.PONo);

            _header.IssueNoteItems.Add(@issueNoteItem);
          
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(DeleteIssueNoteItemDto input)
        {
            var @issueNoteItem = input.MapTo<IssueNoteItem>();

            await _issueNoteItemRepository.DeleteAsync(@issueNoteItem.Id);
        }
    }
}

