using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITrackERP.Assets;
using System.Collections.ObjectModel;

namespace ITrackERP.Master
{
    public class CustomeFiledSetup : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        public virtual string CustomFieldNo { get; set; }

        public virtual string ItemType { get; set; }

        public virtual string CustomeField1 { get; set; }

        public virtual string CustomeField2 { get; set; }

        public virtual string CustomeField3 { get; set; }

        public virtual string CustomeField4 { get; set; }

        public virtual string CustomeField5 { get; set; }

        public virtual string CustomeField6 { get; set; }

        public virtual int CodeLength { get; set; }

        public virtual bool ItemCodeGenerate { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<ItemMaster> ItemMasters { get; set; }


        public static CustomeFiledSetup Create(int tenantId, string customeFieldNo, string itemType,
            string customeField1, string customeField2, string customeField3, string customeField4, string customeField5,
            string customeField6, int codeLength, bool itemCodeGenerate)
        {
            var @customefieldsetup = new CustomeFiledSetup()
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                CustomFieldNo = customeFieldNo,
                ItemType = itemType,
                CustomeField1 = customeField1,
                CustomeField2 = customeField2,
                CustomeField3 = customeField3,
                CustomeField4 = customeField4,
                CustomeField5 = customeField5,
                CustomeField6 = customeField6,
                CodeLength = codeLength,
                ItemCodeGenerate = itemCodeGenerate,
            };
            @customefieldsetup.Assets = new Collection<Asset>();
            @customefieldsetup.ItemMasters = new Collection<ItemMaster>();
            return @customefieldsetup;
        }



    }
}
