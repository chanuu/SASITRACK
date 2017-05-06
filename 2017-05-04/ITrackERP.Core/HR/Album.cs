using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.HR
{
    public class Album : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("EventHeaderId")]
        public virtual EventHeader EventHeader { get; set; }

        public virtual Guid EventHeaderId { get; set; }

        public virtual string Name { get; set; }
        public virtual string Url { get; set; }

        public static Album Create(int tenantId, string name, string url)
        {
            var @album = new Album
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                Name = name,
                Url = url
            };

            return @album;

        }
    }
}
