using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.ComlianceAndSafety
{
    public class Files : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public virtual Guid CustomeFiledSetupId { get; set; }     
        public virtual string Type { get; set; }
        public virtual string CustomField1 { get; set; }
        public virtual string CustomField2 { get; set; }
        public virtual string CustomField3 { get; set; }
        public virtual string CustomField4 { get; set; }
        public virtual string CustomField5 { get; set; }
        public virtual string CustomField6 { get; set; }
        public virtual string Category1 { get; set; }
        public virtual string Category2 { get; set; }
        public virtual string Category3 { get; set; }
        public virtual string Category4 { get; set; }
        public virtual string Category5 { get; set; }
        public virtual string Path { get; set; }

        public static Files Create(int tenantId, Guid customeFiledSetupId, string type, string customField1, string customField2, string customField3, string customField4, string customField5, string customField6, string category1, string category2, string category3, string category4, string category5, string path)
        {
            var @file = new Files
            {
                Id = Guid.NewGuid(),
                CustomeFiledSetupId = customeFiledSetupId,
                Type = type,
                CustomField1 = customField1,
                CustomField2 = customField2,
                CustomField3 = customField3,
                CustomField4 = customField4,
                CustomField5 = customField5,
                CustomField6 = customField6,
                Category1 = category1,
                Category2 = category2,
                Category3 = category3,
                Category4 = category4,
                Category5 = category5,
                Path = path,

            };
            return @file;
        }
    }
}



