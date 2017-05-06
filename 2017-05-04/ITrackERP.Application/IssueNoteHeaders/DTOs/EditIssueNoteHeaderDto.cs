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
    public class EditIssueNoteHeaderDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }
        public Guid StyleId { get; set; }
        public string StyleNo { get; set; }
        public string IssueNoteNo { get; set; }
        public string IssueTo { get; set; }
        public string IssueType { get; set; }
        public string IssuedBy { get; set; }
        public string Remark { get; set; }
    }
}
