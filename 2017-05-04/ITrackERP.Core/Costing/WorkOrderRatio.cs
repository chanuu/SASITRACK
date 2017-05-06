using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace ITRACK.Costing
{
    public class WorkOrderRatio : FullAuditedEntity<Guid>,IMustHaveTenant
    {
        public int TenantId { get; set; }

        [ForeignKey("WorkOrderHeaderId")]

        public virtual WorkOrderHeader WorkOrderHeader { get; set; }
        public virtual Guid WorkOrderHeaderId { get; set; }

        public virtual string Color { get; set; }

        public virtual string Size { get; set; }

        public virtual string Length { get; set; }

        public virtual int Quantity { get; set; }

        public static WorkOrderRatio Create(int tenantId, Guid workorderHeaderId,string color,string size,string length,int quantity)
        {
          var  @workorderItem = new WorkOrderRatio
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Color = color,
                Size = size,
                Length = length,
                Quantity = quantity,
                WorkOrderHeaderId = workorderHeaderId

            };

            return @workorderItem;
        }

        
    }
}
