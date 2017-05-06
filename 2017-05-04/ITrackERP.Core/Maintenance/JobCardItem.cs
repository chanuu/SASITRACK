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
    public class JobCardItem : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("JobCardHeaderId")]
        public virtual JobCardHeader JobCardHeader { get; set; }
        public virtual Guid JobCardHeaderId { get; set; }
        public virtual string ItemCode { get; set; }
        public virtual string SerialNo { get; set; }
        public virtual int Amount { get; set; }
        public virtual double Price { get; set; }
        public virtual double SubTotal { get; set; }


        public static JobCardItem Create(int tenantId, string itemCode, string serialNo, int amount, double price, double subTotal)
        {
            var @jobCardItem = new JobCardItem
            {
                Id = Guid.NewGuid(),
                ItemCode = itemCode,
                SerialNo = serialNo,
                Amount = amount,
                Price = price,
                SubTotal = subTotal,

            };
            return @jobCardItem;
        }
    }
}


