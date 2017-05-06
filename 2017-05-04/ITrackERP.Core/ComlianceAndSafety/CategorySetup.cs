using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.ComlianceAndSafety
{
    public class CategorySetup : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public virtual string Type { get; set; }
        public virtual string Name { get; set; }
        public virtual string LevelNo { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual string Remark { get; set; }

        public static CategorySetup Create(int tenantId, string type, string name, string levelNo, string categoryName, string remark)
        {
            var @categorysetup = new CategorySetup
            {
                Id = Guid.NewGuid(),
                Type = type,
                Name = name,
                LevelNo = levelNo,
                CategoryName = categoryName,
                Remark = remark,

            };
            return @categorysetup;
        }
    }
}


