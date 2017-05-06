using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.TAW
{
    public class LayoutItem : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("LayoutHeaderId")]
        public virtual LayoutHeader LayoutHeader { get; set; }
        public virtual Guid LayoutHeaderId { get; set; }
        public virtual string Key { get; set; }
        public virtual string Size { get; set; }
        public virtual string Source { get; set; }
        public virtual string Position { get; set; }
        public virtual string Group { get; set; }

        public static LayoutItem Create(int tenantId, string key, string size, string source, string position, string group)
        {
            var @layoutitem = new LayoutItem
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Key = key,
                Size = size,
                Source = source,
                Position = position,
                Group =group,
            };

            return @layoutitem;

        }
    }
}
