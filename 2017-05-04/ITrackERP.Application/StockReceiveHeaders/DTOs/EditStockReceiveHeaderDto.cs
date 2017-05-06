using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.StockReceiveHeaders.DTOs
{
    [AutoMap(typeof(StockReceiveHeader))]
    public class EditStockReceiveHeaderDto : FullAuditedEntityDto<Guid>
    {
        public int TenantId { get; set; }
        public string ReceiveNoteNo { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string Remark { get; set; }
        public string By { get; set; }

    }
}
