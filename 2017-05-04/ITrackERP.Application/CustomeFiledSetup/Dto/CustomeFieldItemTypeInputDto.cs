using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.CustomeFiledSetup.Dto
{
    public class CustomeFieldItemTypeInputDto : FullAuditedEntityDto<Guid>
    {
        public string ItemType { get; set; }

    }
}
