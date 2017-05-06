using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ITrackERP.IssueNoteHeaders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.IssueNoteHeaders
{
    public interface IIssueNoteHeaderAppService : IApplicationService
    {
        ListResultOutput<IssueNoteHeaderDto> GetIssueNoteHeader();
        IssueNoteHeaderListDto GetDetail(EntityRequestInput<Guid> input);

        Task Create(CreateIssueNoteHeaderDto input);

        Task Update(EditIssueNoteHeaderDto input);

        Task Delete(DeleteIssueNoteHeaderDto input);
    }
}
