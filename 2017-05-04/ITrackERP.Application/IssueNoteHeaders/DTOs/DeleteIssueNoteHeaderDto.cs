using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Cutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.IssueNoteHeaders.DTOs
{
     [AutoMap(typeof(IssueNoteHeader))]
    public class DeleteIssueNoteHeaderDto : FullAuditedEntityDto<Guid>
    {
         public Guid Id { get; set; }
    }
}
