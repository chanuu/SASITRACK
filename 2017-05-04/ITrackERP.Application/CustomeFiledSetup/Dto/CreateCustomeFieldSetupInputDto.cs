using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace ITrackERP.CustomeFiledSetups.Dto
{
    [AutoMap(typeof(Master.CustomeFiledSetup))]
    public class CreateCustomeFieldSetupInputDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }

        public string CustomFieldNo { get; set; }

        public string ItemType { get; set; }

        public string CustomeField1 { get; set; }

        public string CustomeField2 { get; set; }

        public string CustomeField3 { get; set; }

        public string CustomeField4 { get; set; }

        public string CustomeField5 { get; set; }

        public string CustomeField6 { get; set; }

        public int CodeLength { get; set; }

        public bool ItemCodeGenerate { get; set; }
    }
}
