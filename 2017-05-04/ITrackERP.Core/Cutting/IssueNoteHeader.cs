using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITRACK.Company;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Cutting
{
    public class IssueNoteHeader : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }


        [ForeignKey("StyleId")]
        public virtual Style Style { get; set; }
        public virtual Guid StyleId { get; set; }
        public virtual string StyleNo { get; set; }
        public virtual string IssueNoteNo { get; set; }
        public virtual string IssueTo { get; set; }
        public virtual string IssueType { get; set; }
        public virtual string IssuedBy { get; set; }
        public virtual string Remark { get; set; }

        public virtual ICollection<IssueNoteItem> IssueNoteItems { get; set; }

        public static IssueNoteHeader Create(int tenantId, Guid styleId, string styleNo, string issueNoteNo, string issueTo, string issueType, string issuedBy, string remark)
        {
            var @issueNote = new IssueNoteHeader
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                StyleId = styleId,
                StyleNo = styleNo,
                IssueNoteNo = issueNoteNo,
                IssueTo = issueTo,
                IssueType = issueType,
                IssuedBy = issuedBy,               
                Remark = remark
            };

            @issueNote.IssueNoteItems = new Collection<IssueNoteItem>();
            return @issueNote;

        }
    }
}
