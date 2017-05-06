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
    public class DailyPlanItem : FullAuditedEntity<Guid>, IMustHaveTenant
    {

        public virtual int TenantId { get; set; }

        [ForeignKey("DailyPlanHeaderId")]
        public virtual DailyPlanHeader DailyPlanHeader { get; set; }
        public virtual Guid DailyPlanHeaderId { get; set; }
        public virtual string StyleNo { get; set; }

        public virtual string PONo { get; set; }

        public virtual string Color { get; set; }

        public virtual string Size { get; set; }

        public virtual string Length { get; set; }

        public virtual int NoOfPlys { get; set; }

        public virtual int NoOfItem { get; set; }

        public static DailyPlanItem Create(int tenantId, string styleNo, string pONo, string color, string size, string length, int noOfPlys, int noOfItem)
        {
            var @dailyPlanItem = new DailyPlanItem
            {
                Id = Guid.NewGuid(),
                StyleNo = styleNo,
                PONo = pONo,
                Color = color,
                Size = size,
                Length = length,
                NoOfPlys = noOfPlys,
                NoOfItem = noOfItem,

            };
            return @dailyPlanItem;
        }
    }
}