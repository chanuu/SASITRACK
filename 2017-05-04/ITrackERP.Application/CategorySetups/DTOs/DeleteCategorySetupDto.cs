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
    public class DeleteCategorySetupDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
