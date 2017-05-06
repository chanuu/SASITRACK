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
    public class ReceiveNoteItem : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        public virtual Guid ItemMasterId { get; set; }

        [ForeignKey("StockReceiveHeaderId")]
        public virtual StockReceiveHeader StockReceiveHeader { get; set; }
        public virtual Guid StockReceiveHeaderId { get; set; }
        public virtual string ItemCode { get; set; }             
        public virtual double PurchasePrice { get; set; }
        public virtual int Nos { get; set; }

        public virtual bool isIncludeSerials { get; set; }

        public virtual ICollection<SerialItem> SerialItems { get; set; }

        public static ReceiveNoteItem Create(string itemCode, double purchasePrice, int nos, bool isIncludeSerials)
        {
            var @receiveNoteItem = new ReceiveNoteItem
            {
                Id = Guid.NewGuid(),
                ItemCode = itemCode,
                PurchasePrice = purchasePrice,
                Nos =nos,
                isIncludeSerials = isIncludeSerials
            };
            @receiveNoteItem.SerialItems = new Collection<SerialItem>();
            return @receiveNoteItem;
        }
    }
}
