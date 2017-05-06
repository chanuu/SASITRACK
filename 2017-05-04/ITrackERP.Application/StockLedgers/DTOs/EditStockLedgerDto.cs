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
    public class EditStockLedgerDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }
        public string ItemCode { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string TransactionType { get; set; }
        public string DocNo { get; set; }
        public int UsedStock { get; set; }
        public int BalanceStock { get; set; }
        public string Status { get; set; }
    }
}
