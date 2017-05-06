using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.SerialItems.DTOs
{
     [AutoMap(typeof(SerialItem))]
    public class SerialNoInputDto : FullAuditedEntityDto<Guid>
    {
         public string SerialNo { get; set; }
    }
}
