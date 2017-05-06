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
    public class SerialItemListDto : FullAuditedEntityDto<Guid>
    {
        public Guid ReceiveNoteItemId { get; set; }
        public string ItemCode { get; set; }      
        public string SerialNo { get; set; }
        public string Status { get; set; }
    }
}

