using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITrackERP.ComlianceAndSafety;

namespace ITrackERP.Files.DTOs
{
     [AutoMap(typeof(ITrackERP.ComlianceAndSafety.Files))]
    public class CreateFileDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }
        public Guid CustomeFiledSetupId { get; set; }   
        public string Type { get; set; }
        public string CustomField1 { get; set; }
        public string CustomField2 { get; set; }
        public string CustomField3 { get; set; }
        public string CustomField4 { get; set; }
        public string CustomField5 { get; set; }
        public string CustomField6 { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public string Category4 { get; set; }
        public string Category5 { get; set; }
        public string Path { get; set; }

    }
}




