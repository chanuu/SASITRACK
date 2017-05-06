using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Asset_Ledgers.DTOs
{
     [AutoMap(typeof(AssetLedger))]
    public class DocNoDto : FullAuditedEntityDto<Guid>
    {      
        public string DocNo { get; set; }
    }
}
