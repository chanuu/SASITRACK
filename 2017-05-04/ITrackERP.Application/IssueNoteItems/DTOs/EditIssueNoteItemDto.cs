using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Cutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.IssueNoteItems.DTOs
{
      [AutoMap(typeof(IssueNoteItem))]
    public class EditIssueNoteItemDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }
        public Guid IssueNoteHeaderId { get; set; }
        public string CutNo { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string NoOfPlys { get; set; }
        public string NoOfItem { get; set; }
        public string PONo { get; set; }
    }
}
