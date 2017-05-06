using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Cutting
{
    public class IssueNoteItem : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("IssueNoteHeaderId")]
        public virtual IssueNoteHeader IssueNoteHeader { get; set; }
        public virtual Guid IssueNoteHeaderId { get; set; }
        public virtual string CutNo { get; set; }
        public virtual string Color { get; set; }
        public virtual string Size { get; set; }
        public virtual string NoOfPlys { get; set; }
        public virtual string NoOfItem { get; set; }
        public virtual string PONo { get; set; }

        public static IssueNoteItem Create(int tenantId, string cutNo, string color, string size, string noOfPlys, string noOfItem, string pONo)
        {
            var @issueNoteItem = new IssueNoteItem
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                CutNo = cutNo,
                Color = color,
                Size = size,
                NoOfPlys = noOfPlys,
                NoOfItem = noOfItem,
                PONo = pONo
            };

            return @issueNoteItem;



        }

    }
}
