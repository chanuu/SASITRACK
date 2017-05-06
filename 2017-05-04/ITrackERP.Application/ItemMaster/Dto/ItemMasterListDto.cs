using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ITrackERP.ItemMaster.Dto
{
    [AutoMapFrom(typeof(Master.ItemMaster))]
    public class ItemMasterListDto : FullAuditedEntityDto<Guid>
    {
        public Guid CustomeFiledSetupId { get; set; }
        public string ItemType { get; set; }

        public string ItemNo { get; set; }

        public string CustomField1 { get; set; }

        public string CustomField2 { get; set; }

        public string CustomField3 { get; set; }

        public string CustomField4 { get; set; }

        public string CustomField5 { get; set; }

        public string CustomField6 { get; set; }

        public string Supplier { get; set; }

        public string Uom { get; set; }

        public string Status { get; set; }

        public int MaxQty { get; set; }

        public int ReOrderQty { get; set; }

        public int MinimumQty { get; set; }

        public bool BatchItem { get; set; }

        public bool ServiceItem { get; set; }

        public bool ShowInFrontEnd { get; set; }

        public bool Discount { get; set; }

        public bool CustomerReturnOrder { get; set; }

        public bool SerialItem { get; set; }

        public string Image { get; set; }

    }
}
