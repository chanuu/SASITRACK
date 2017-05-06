using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ITrackERP.Maintenance;
using ITrackERP.SerialItems.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITrackERP.ReceiveNoteItems.DTOs
{
      [AutoMapFrom(typeof(ReceiveNoteItem))]
    public class ReceiveNoteItemListDto : FullAuditedEntityDto<Guid>
    {
        public Guid ItemMasterId { get; set; }
        public Guid StockReceiveHeaderId { get; set; }
        public string ItemCode { get; set; }
        public double PurchasePrice { get; set; }
        public int Nos { get; set; }
        public bool isIncludeSerials { get; set; }

        public ICollection<SerialItemDto> SerialItems { get; set; }
    }
}
