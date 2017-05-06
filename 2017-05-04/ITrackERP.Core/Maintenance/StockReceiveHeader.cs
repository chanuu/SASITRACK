using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITrackERP.Master;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Maintenance
{
    public class StockReceiveHeader : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }       
        public virtual string ReceiveNoteNo { get; set; }
        public virtual Nullable<DateTime> Date { get; set; }
        public virtual string Remark { get; set; }
        public virtual string By { get; set; }
        public virtual ICollection<ReceiveNoteItem> ReceiveNoteItems { get; set; }

        public static StockReceiveHeader Create(int tenantId, string receiveNoteNo, DateTime date, string remark, string by)
        {
            var @stockReceiveHeader = new StockReceiveHeader
            {
                Id = Guid.NewGuid(),
                ReceiveNoteNo = receiveNoteNo,
                Date = date,
                Remark = remark,
                By = by,
            };
            @stockReceiveHeader.ReceiveNoteItems = new Collection<ReceiveNoteItem>();
            return @stockReceiveHeader;
        }
    }
}
