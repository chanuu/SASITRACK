using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.ComlianceAndSafety;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CategorySetups.DTOs
{
     [AutoMap(typeof(CategorySetup))]
    public class CategorySetupDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string LevelNo { get; set; }
        public string CategoryName { get; set; }
        public string Remark { get; set; }
    }
}