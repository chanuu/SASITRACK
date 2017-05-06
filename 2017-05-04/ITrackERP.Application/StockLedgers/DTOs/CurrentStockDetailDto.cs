using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.StockLedgers.DTOs
{
    [AutoMap(typeof(StockLedger))]
    public class CurrentStockDetailDto : FullAuditedEntityDto<Guid>
    {
        public string ItemCode { get; set; }
        public int CurrentStock { get; set; }
    }
}
