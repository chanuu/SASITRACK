using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.Maintenance
{
    public class StockLedger : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public virtual string ItemCode { get; set; }
        public virtual Nullable<DateTime> Date { get; set; }
        public virtual string TransactionType { get; set; }
        public virtual string DocNo { get; set; }
        public virtual int UsedStock { get; set; }
        public virtual int BalanceStock { get; set; }
        public virtual string Status { get; set; }
        public static StockLedger Create(int tenantId, string itemCode, DateTime date, string transactionType, string docNo, int usedStock, int balanceStock, string status)
        {
            var @StockLedger = new StockLedger
            {
                Id = Guid.NewGuid(),
                ItemCode = itemCode,
                Date = date,
                TransactionType = transactionType,
                DocNo = docNo,
                UsedStock = usedStock,
                BalanceStock = balanceStock,
                Status = status,
            };

            return @StockLedger;
        }
    }
}

