using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.ItemMaster.Dto
{
    [AutoMap(typeof(Master.ItemMaster))]
    public class ItemCodeInputDto : FullAuditedEntityDto<Guid>
    {
        public string ItemNo { get; set; }
    }
}
