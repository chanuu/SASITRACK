using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Maintenance
{
    public class SerialItem : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

         [ForeignKey("ReceiveNoteItemId")]
        public virtual ReceiveNoteItem ReceiveNoteItem { get; set; }
        public virtual Guid ReceiveNoteItemId { get; set; }

        public virtual string ItemCode { get; set; }         

        public virtual string SerialNo { get; set; }

        public virtual string Status { get; set; }

       public static SerialItem Create(string itemCode, string serialNo, string status)
       {
           var @serialItem = new SerialItem
           {
               Id = Guid.NewGuid(),
               ItemCode = itemCode,
               SerialNo = serialNo,
               Status = status,
           };
           
           return @serialItem;
       }
    }
}
