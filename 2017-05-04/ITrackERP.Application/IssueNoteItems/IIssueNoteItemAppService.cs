using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.IssueNoteItems.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.IssueNoteItems
{
    public interface IIssueNoteItemAppService : IApplicationService
    {
        ListResultOutput<IssueNoteItemDto> GetIssueNoteItem();
        IssueNoteItemDto GetDetail(EntityRequestInput<Guid> input);
        Task Create(CreateIssueNoteItemDto input);

        Task Update(EditIssueNoteItemDto input);

        Task Delete(DeleteIssueNoteItemDto input);
    }
}