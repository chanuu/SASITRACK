using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Files1.DTOs
{
    public class FileTypeInputDto : FullAuditedEntityDto<Guid>
    {
        public Guid CustomeFiledSetupId { get; set; }
    }
}
