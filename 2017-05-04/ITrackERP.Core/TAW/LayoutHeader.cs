using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.TAW
{
    public class LayoutHeader : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("DividingPlanHeaderId")]
        public virtual DividingPlanHeader DividingPlanHeader { get; set; }

        public virtual Guid DividingPlanHeaderId { get; set; }

        public virtual string LayoutJson { get; set; }
        public virtual string Remark { get; set; }
        
        public virtual ICollection<LayoutItem> LayoutItems { get; set; }


        public static LayoutHeader Create(string layoutJson, string remark)
        {
            var @layoutheader = new LayoutHeader
            {
                Id = Guid.NewGuid(),
                LayoutJson = layoutJson,
                Remark = remark,
            };

            @layoutheader.LayoutItems = new Collection<LayoutItem>();
            return @layoutheader;

        }
    }
}
