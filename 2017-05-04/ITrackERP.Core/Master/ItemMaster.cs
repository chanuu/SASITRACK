using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ITrackERP.Maintenance;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITrackERP.Master
{
    public class ItemMaster : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [ForeignKey("CustomeFiledSetupId")]
        public virtual CustomeFiledSetup CustomeFiledSetup { get; set; }
        public virtual Guid CustomeFiledSetupId { get; set; }

        public virtual string ItemType { get; set; }

        public virtual string ItemNo { get; set; }

        public virtual string CustomField1 { get; set; }

        public virtual string CustomField2 { get; set; }

        public virtual string CustomField3 { get; set; }

        public virtual string CustomField4 { get; set; }

        public virtual string CustomField5 { get; set; }

        public virtual string CustomField6 { get; set; }

        public virtual string Supplier { get; set; }

        public virtual string Uom { get; set; }

        public virtual string Status { get; set; }

        public virtual int MaxQty { get; set; }

        public virtual int ReOrderQty { get; set; }

        public virtual int MinimumQty { get; set; }

        public virtual bool BatchItem { get; set; }

        public virtual bool ServiceItem { get; set; }

        public virtual bool ShowInFrontEnd { get; set; }

        public virtual bool Discount { get; set; }

        public virtual bool CustomerReturnOrder { get; set; }

        public virtual bool SerialItem { get; set; }

        public virtual string Image { get; set; }

        public static ItemMaster Create(int tenantId, string itemType, string itemNo, string customField1, string customField2, string customField3, string customField4, string customField5, string customField6, string supplier,
            string uom, string status, int maxQty, int reOrderQty, int minimumQty, bool batchItem, bool serviceItem, bool showInFrontEnd, bool discount, bool customerReturnOrder, bool serialItem, string image)

        {
            var @itemmaster = new ItemMaster()
            {
                Id = Guid.NewGuid(),
                TenantId = tenantId,
                ItemType = itemType,
                ItemNo = itemNo,
                CustomField1 = customField1,
                CustomField2 = customField2,
                CustomField3 = customField3,
                CustomField4 = customField4,
                CustomField5 = customField5,
                CustomField6 = customField6,
                Supplier = supplier,
                Uom = uom,
                Status = status,
                MaxQty = maxQty,
                ReOrderQty = reOrderQty,
                MinimumQty = minimumQty,
                BatchItem = batchItem,
                ServiceItem = serviceItem,
                ShowInFrontEnd = showInFrontEnd,
                Discount = discount,
                CustomerReturnOrder = customerReturnOrder,
                SerialItem = serialItem,
                Image = image
            };

            return @itemmaster;
        }
    }
}
