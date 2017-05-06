using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Files.DTOs
{
    [AutoMap(typeof(ITrackERP.ComlianceAndSafety.Files))]
    public class DeleteFileDto : FullAuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
    }
}
