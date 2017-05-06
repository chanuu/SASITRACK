using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ITrackERP.Cutting;
using ITrackERP.IssueNoteHeaders.DTOs;
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
using AutoMapper;

namespace ITrackERP.IssueNoteHeaders
{
    public class IssueNoteHeaderAppService: ITrackERPAppServiceBase, IIssueNoteHeaderAppService
    {

        private readonly IRepository<IssueNoteHeader, Guid> _issueNoteHeaderRepository;

        private readonly IRepository<IssueNoteItem, Guid> _issueNoteItemRepository;

        public IssueNoteHeaderAppService(IRepository<IssueNoteHeader, Guid> issueNoteHeaderRepository, IRepository<IssueNoteItem, Guid> issueNoteItemRepository)
        {
            _issueNoteHeaderRepository = issueNoteHeaderRepository;
            _issueNoteItemRepository = issueNoteItemRepository;
        }

        public ListResultOutput<IssueNoteHeaderDto> GetIssueNoteHeader()
        {
            var issuenoteheader = _issueNoteHeaderRepository.GetAll();

            return new ListResultOutput<IssueNoteHeaderDto>(issuenoteheader.MapTo<List<IssueNoteHeaderDto>>());
        }


        public IssueNoteHeaderListDto GetDetail(EntityRequestInput<Guid> input)
        {
            var @issuenote = _issueNoteHeaderRepository
                .GetAll()
                .Include(x => x.IssueNoteItems)
                .Where(e => e.Id == input.Id)
                .ToList().FirstOrDefault();

            if (@issuenote == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return @issuenote.MapTo<IssueNoteHeaderListDto>();

        }


        public string GetIssueNoteNo()
        {
            var @issuenote = _issueNoteHeaderRepository
                 .GetAll().OrderByDescending(x => x.CreationTime).FirstOrDefault();

            var issueNoteNo = "I-0000000";
            if (@issuenote != null)
            {

                var issuenoteno = @issuenote.IssueNoteNo;

                string[] words = issuenoteno.Split('-');

                issueNoteNo = "I-" + (Convert.ToInt32(words[1]) + 1).ToString().PadLeft(7, '0');
            }
            else
            {
                issueNoteNo = "I-0000001";
            }
            return issueNoteNo;
        }

        public async Task Create(CreateIssueNoteHeaderDto input)
        {
            var @issuenote = input.MapTo<IssueNoteHeader>();

            @issuenote = IssueNoteHeader.Create(AbpSession.GetTenantId(), input.StyleId, input.StyleNo, GetIssueNoteNo(),input.IssueTo, input.IssueType, input.IssuedBy, input.Remark);

            int i = 0;
            await _issueNoteHeaderRepository.InsertAsync(@issuenote);
        }

        public async Task Update(EditIssueNoteHeaderDto input)
        {
            var @issuenoteheader = input.MapTo<IssueNoteHeader>();
            @issuenoteheader.TenantId = AbpSession.GetTenantId();
            int i = 0;
            await _issueNoteHeaderRepository.UpdateAsync(@issuenoteheader);
        }

        public async Task Delete(DeleteIssueNoteHeaderDto input)
        {
            var @issuenoteheader = input.MapTo<IssueNoteHeader>();
            await _issueNoteHeaderRepository.DeleteAsync(@issuenoteheader.Id);
        }
    }
}